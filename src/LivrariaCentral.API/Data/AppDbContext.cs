using Microsoft.EntityFrameworkCore;
using LivrariaCentral.API.Models;

namespace LivrariaCentral.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Livro> Livros { get; set; }
}