using LivrariaCentral.API.Data;
using LivrariaCentral.API.Models;
using Microsoft.AspNetCore.Authorization; // <--- Necessário
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaCentral.API.Controllers;

[ApiController]
[Route("api/vendas")]
[Authorize] // <--- Protege a rota e habilita pegar o nome do usuário
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
                // LOG DE AVISO COM USUÁRIO
                _logger.LogWarning("Usuário {User} tentou vender livro inexistente. ID: {Id}", User.Identity?.Name, novaVenda.LivroId);
                return NotFound("Livro não encontrado.");
            }

            if (livro.Estoque < novaVenda.Quantidade)
            {
                // LOG DE ESTOQUE COM USUÁRIO
                _logger.LogWarning("Estoque insuficiente na venda de {User}. Livro: {Titulo}, Pedido: {Qtd}, Estoque: {Estoque}", User.Identity?.Name, livro.Titulo, novaVenda.Quantidade, livro.Estoque);
                return BadRequest($"Estoque insuficiente. Restam apenas {livro.Estoque} unidades.");
            }

            novaVenda.ValorTotal = livro.Preco * novaVenda.Quantidade;
            novaVenda.DataVenda = DateTime.UtcNow;

            _context.Vendas.Add(novaVenda);
            livro.Estoque -= novaVenda.Quantidade;
            
            await _context.SaveChangesAsync();

            // LOG DE SUCESSO COM NOME DO USUÁRIO
            _logger.LogInformation("Venda realizada por [{User}]: Livro {Titulo}, Qtd {Qtd}, Total R$ {Valor}", User.Identity?.Name, livro.Titulo, novaVenda.Quantidade, novaVenda.ValorTotal);

            return Ok(new { mensagem = "Venda realizada com sucesso!", novoEstoque = livro.Estoque });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro crítico na venda de {User} para livro {Id}", User.Identity?.Name, novaVenda.LivroId);
            return StatusCode(500, "Erro interno ao processar venda.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetVendas()
    {
        // LOG DE CONSULTA AO HISTÓRICO
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