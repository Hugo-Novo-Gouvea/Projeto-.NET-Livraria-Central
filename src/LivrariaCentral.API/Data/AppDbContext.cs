using Microsoft.EntityFrameworkCore;
using LivrariaCentral.API.Models;

namespace LivrariaCentral.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Define que a classe Livro será uma tabela chamada "Livros"
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}