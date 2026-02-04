using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LivrariaCentral.API.Data;
using LivrariaCentral.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LivrariaCentral.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger; // <--- Logger adicionado

    public AuthController(AppDbContext context, IConfiguration configuration, ILogger<AuthController> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(UsuarioDTO request)
    {
        string senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

        var novoUsuario = new Usuario
        {
            Email = request.Email,
            SenhaHash = senhaHash,
            Nome = "Administrador"
        };

        _context.Usuarios.Add(novoUsuario);
        await _context.SaveChangesAsync();

        // Log de registro (Opcional, mas útil)
        _logger.LogInformation("Novo usuário registrado: {Email}", request.Email);

        return Ok("Usuário criado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsuarioDTO request)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
        
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
        {
            // LOG DE FALHA (Segurança)
            _logger.LogWarning("Tentativa de login falhou para o email: {Email}", request.Email);
            return BadRequest("Email ou senha inválidos.");
        }

        string token = GerarToken(usuario);

        // LOG DE SUCESSO (Rastreabilidade)
        _logger.LogInformation("Usuário [{Nome}] ({Email}) realizou login com sucesso.", usuario.Nome, usuario.Email);

        return Ok(new { token = token });
    }

    private string GerarToken(Usuario usuario)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}