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
        // O Banco de Dados faz as contas (muito mais rápido que trazer tudo para o C# somar)
        var totalLivros = await _context.Livros.CountAsync();
        var valorEstoque = await _context.Livros.SumAsync(l => l.Preco * l.Estoque);
        var estoqueBaixo = await _context.Livros.CountAsync(l => l.Estoque < 5);
        
        // Retorna um objeto anônimo (JSON) com os dados calculados
        return Ok(new 
        {
            TotalLivros = totalLivros,
            ValorEstoque = valorEstoque,
            EstoqueBaixo = estoqueBaixo,
            // VendasHoje = 0 (Deixaremos zerado até implementarmos a tabela de Vendas)
        });
    }
}