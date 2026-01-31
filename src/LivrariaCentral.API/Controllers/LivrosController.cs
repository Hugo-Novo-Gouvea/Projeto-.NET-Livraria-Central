using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivrariaCentral.API.Data;
using LivrariaCentral.API.Models;

namespace LivrariaCentral.API.Controllers;

[Route("api/[controller]")]  // A rota será: api/livros
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeção de Dependência do Banco de Dados
    public LivrosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/livros (Listar todos)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
    {
        return await _context.Livros.ToListAsync();
    }

    // GET: api/livros/5 (Pegar um específico)
    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetLivro(int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
        {
            return NotFound();
        }

        return livro;
    }

    // POST: api/livros (Criar novo)
    [HttpPost]
    public async Task<ActionResult<Livro>> PostLivro(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        // Retorna código 201 (Created) e o link para acessar o item criado
        return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
    }

    // PUT: api/livros/5 (Atualizar)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLivro(int id, Livro livro)
    {
        if (id != livro.Id)
        {
            return BadRequest();
        }

        _context.Entry(livro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Livros.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/livros/5 (Apagar)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLivro(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null)
        {
            return NotFound();
        }

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}