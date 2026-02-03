using LivrariaCentral.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaCentral.API.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("resumo")]
    public async Task<IActionResult> GetResumo()
    {
        // O Banco de Dados faz as contas (muito mais rápido que o C#)
        var totalLivros = await _context.Livros.CountAsync();
        var valorEstoque = await _context.Livros.SumAsync(l => l.Preco * l.Estoque);
        var estoqueBaixo = await _context.Livros.CountAsync(l => l.Estoque < 5);
        
        // Retorna um objeto anônimo (JSON)
        return Ok(new 
        {
            TotalLivros = totalLivros,
            ValorEstoque = valorEstoque,
            EstoqueBaixo = estoqueBaixo,
            // Simula dados de vendas (pois ainda não temos tabela de vendas)
            VendasHoje = 0 
        });
    }
}