using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivrariaCentral.API.Data;
using LivrariaCentral.API.Models;
using Microsoft.AspNetCore.Authorization; // <--- Necessário para pegar o User.Identity

namespace LivrariaCentral.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] // <--- Protege a rota e habilita pegar o nome do usuário
public class LivrosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<LivrosController> _logger; // <--- Logger adicionado

    public LivrosController(AppDbContext context, ILogger<LivrosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/livros
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
    {
        return await _context.Livros.ToListAsync();
    }

    // GET: api/livros/5
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

    // POST: api/livros
    [HttpPost]
    public async Task<ActionResult<Livro>> PostLivro(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        // LOG DE CADASTRO
        _logger.LogInformation("Livro '{Titulo}' cadastrado por: {Usuario}", livro.Titulo, User.Identity?.Name);

        return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
    }

    // PUT: api/livros/5
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
            // LOG DE ATUALIZAÇÃO
            _logger.LogInformation("Livro '{Titulo}' (ID: {Id}) atualizado por: {Usuario}", livro.Titulo, id, User.Identity?.Name);
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

    // DELETE: api/livros/5
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

        // LOG DE EXCLUSÃO
        _logger.LogInformation("Livro '{Titulo}' (ID: {Id}) excluído por: {Usuario}", livro.Titulo, id, User.Identity?.Name);

        return NoContent();
    }
}