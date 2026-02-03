namespace LivrariaCentral.Web.Models;

public class VendaHistorico
{
    public int Id { get; set; }
    public DateTime DataVenda { get; set; }
    public string LivroTitulo { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
}