namespace LivrariaCentral.API.Models;

public class Livro
{
    public int Id { get; set; } // O EF Core entende automaticamente que "Id" é a Chave Primária
    public string Titulo { get; set; } = string.Empty; // Inicializa vazio para evitar erros de Nulo
    public string Autor { get; set; } = string.Empty;
    public decimal Preco { get; set; } // Decimal é o tipo correto para dinheiro (evita erros de arredondamento)
    public int Estoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow; // Pega a hora universal (padrão mundial)
}