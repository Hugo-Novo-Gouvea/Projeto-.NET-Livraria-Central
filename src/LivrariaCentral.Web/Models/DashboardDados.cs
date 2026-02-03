namespace LivrariaCentral.Web.Models;

public class DashboardDados
{
    public int TotalLivros { get; set; }
    public decimal ValorEstoque { get; set; }
    public int EstoqueBaixo { get; set; }
    public int VendasHoje { get; set; } // Futuro
}