using LivrariaCentral.API.Data;
using LivrariaCentral.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaCentral.API.Controllers;

[ApiController]
[Route("api/vendas")]
public class VendasController : ControllerBase
{
    private readonly AppDbContext _context;

    public VendasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RealizarVenda([FromBody] Venda novaVenda)
    {
        // 1. Busca o livro no banco
        var livro = await _context.Livros.FindAsync(novaVenda.LivroId);
        if (livro == null) return NotFound("Livro não encontrado.");

        // 2. Valida se tem estoque suficiente
        if (livro.Estoque < novaVenda.Quantidade)
        {
            return BadRequest($"Estoque insuficiente. Restam apenas {livro.Estoque} unidades.");
        }

        // 3. Cria o registro da venda
        novaVenda.ValorTotal = livro.Preco * novaVenda.Quantidade;
        novaVenda.DataVenda = DateTime.UtcNow;
        _context.Vendas.Add(novaVenda);

        // 4. ATUALIZA O ESTOQUE DO LIVRO (Baixa automática)
        livro.Estoque -= novaVenda.Quantidade;
        
        // 5. Salva tudo numa única transação
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Venda realizada com sucesso!", novoEstoque = livro.Estoque });
    }
}