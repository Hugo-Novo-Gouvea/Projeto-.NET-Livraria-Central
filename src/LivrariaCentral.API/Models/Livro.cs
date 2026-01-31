namespace LivrariaCentral.API.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}