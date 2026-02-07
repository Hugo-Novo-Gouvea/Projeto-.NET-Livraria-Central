using LivrariaCentral.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LivrariaCentral.API.Controllers;

[ApiController]
[Route("api/relatorios")]
public class RelatoriosController : ControllerBase
{
    private readonly AppDbContext _context;

    public RelatoriosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("estoque")]
    public async Task<IActionResult> GerarRelatorioEstoque()
    {
        var livros = await _context.Livros.ToListAsync();

        // --- DESENHANDO O PDF COM QUESTPDF ---
        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                // 1. Cabeçalho
                page.Header()
                    .Text("Relatório de Estoque - Livraria Central")
                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                // 2. Conteúdo (Tabela)
                page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                {
                    // Definição das colunas
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50); // ID
                        columns.RelativeColumn();   // Título (ocupa o resto)
                        columns.ConstantColumn(80); // Estoque
                        columns.ConstantColumn(100); // Preço
                    });

                    // Cabeçalho da Tabela
                    table.Header(header =>
                    {
                        header.Cell().Text("#").Bold();
                        header.Cell().Text("Título").Bold();
                        header.Cell().Text("Estoque").Bold();
                        header.Cell().Text("Preço").Bold();
                    });

                    // Linhas da Tabela (Dados)
                    foreach (var livro in livros)
                    {
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(livro.Id.ToString());
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(livro.Titulo);
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(livro.Estoque.ToString());
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"R$ {livro.Preco:F2}");
                    }
                });

                // 3. Rodapé (Paginação)
                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                    });
            });
        });

        // --- GERANDO O ARQUIVO ---
        var stream = new MemoryStream();
        pdf.GeneratePdf(stream);
        stream.Position = 0;

        // Devolve o arquivo com o tipo MIME correto (application/pdf)
        return File(stream, "application/pdf", "RelatorioEstoque.pdf");
    }
}