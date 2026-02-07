using LivrariaCentral.API.Data;
using LivrariaCentral.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LivrariaCentral.API.Controllers;

[ApiController]
[Route("api/vendas")]
[Authorize]
public class VendasController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<VendasController> _logger;

    public VendasController(AppDbContext context, ILogger<VendasController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> RealizarVenda(Venda novaVenda)
    {
        try
        {
            var livro = await _context.Livros.FindAsync(novaVenda.LivroId);
            
            if (livro == null) 
            {
                _logger.LogWarning("Usuário {User} tentou vender livro inexistente (ID {Id}).", User.Identity?.Name, novaVenda.LivroId);
                return NotFound("Livro não encontrado.");
            }

            if (livro.Estoque < novaVenda.Quantidade)
            {
                _logger.LogWarning("Estoque insuficiente. Vendedor: {User}, Livro: {Titulo}", User.Identity?.Name, livro.Titulo);
                return BadRequest($"Estoque insuficiente.");
            }

            novaVenda.ValorTotal = livro.Preco * novaVenda.Quantidade;
            novaVenda.DataVenda = DateTime.UtcNow;

            _context.Vendas.Add(novaVenda);
            livro.Estoque -= novaVenda.Quantidade;
            
            await _context.SaveChangesAsync();

            // LOG DE SUCESSO
            _logger.LogInformation("Venda por [{User}]: Livro '{Titulo}', Qtd {Qtd}, Total {Total}", User.Identity?.Name, livro.Titulo, novaVenda.Quantidade, novaVenda.ValorTotal);

            return Ok(new { mensagem = "Venda realizada com sucesso!", novoEstoque = livro.Estoque });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro crítico na venda de {User}", User.Identity?.Name);
            return StatusCode(500, "Erro interno.");
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetVendas()
    {
        _logger.LogInformation("Usuário [{User}] consultou o Histórico de Vendas.", User.Identity?.Name);
        
        var historico = await _context.Vendas
            .Join(_context.Livros,
                venda => venda.LivroId,
                livro => livro.Id,
                (venda, livro) => new 
                {
                    Id = venda.Id,
                    DataVenda = venda.DataVenda,
                    LivroTitulo = livro.Titulo,
                    Quantidade = venda.Quantidade,
                    ValorTotal = venda.ValorTotal
                })
            .OrderByDescending(v => v.DataVenda)
            .ToListAsync();

        return Ok(historico);
    }
}