namespace LivrariaCentral.API.Models;

public class Venda
{
    public int Id { get; set; }
    public int LivroId { get; set; } // Referência: Qual livro foi vendido
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataVenda { get; set; } = DateTime.UtcNow;
}