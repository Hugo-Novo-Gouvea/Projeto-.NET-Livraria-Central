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

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(UsuarioDTO request)
    {
        // Criptografa a senha antes de salvar
        string senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

        var novoUsuario = new Usuario
        {
            Email = request.Email,
            SenhaHash = senhaHash,
            Nome = "Administrador"
        };

        _context.Usuarios.Add(novoUsuario);
        await _context.SaveChangesAsync();

        return Ok("Usuário criado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsuarioDTO request)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
        
        // Verifica se usuário existe e se a senha bate com o hash
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
        {
            return BadRequest("Email ou senha inválidos.");
        }

        // Se passou, gera o Token JWT
        string token = GerarToken(usuario);
        return Ok(new { token = token });
    }

    private string GerarToken(Usuario usuario)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!); // <--- Exclamação aqui
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8), // Token vale por 8 horas
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}