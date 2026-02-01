 # 📚 Livraria Central API - Documentação Técnica

 ### Projeto de estudo utilizando .NET 10, Entity Framework Core e PostgreSQL.

 **Objetivo:** Criar uma aplicação web onde o usuário faça a gestão de uma livraria.

 ---

 ## 🚀 Sessão 1: Configuração do Ambiente

 ### 1. Infraestrutura
 - Banco de Dados: PostgreSQL 18. (Necessita Instalar)
 - Versão do .NET SDK: 10.0.102. (Necessita Instalar)
 - .NET WebApi.
 - .NET Blazor.

 ---

 ## 🚀 Sessão 2: Criação da API

 ### 1. Criação da pasta Source

(Todos os comandos a seguir são utilizados )

 Criação da pasta "src" na raiz para organizar o código fonte.

 ```bash
 mkdir src
 cd src
 ```

 ### 2. Estrutura inicial da API
 Comando .NET para criação de um novo projeto WebApi.

 ```bash
 dotnet new webapi -n LivrariaCentral.API
 cd LivrariaCentral.API
 ```

 ### 3. Instalação de Pacotes
 Versões gerenciadas automaticamente pelo .NET SDK 10.

 ```bash
 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
 ```

 > **Obs:** Caso esteja utilizando o .NET SDK 9, adicione ` --version 9.0.0` ao final de cada linha.

 ---

 ## 🚀 Sessão 3: Configuração da API

 ### 1. Modelagem de Dados (Code-First)

 Acesse a pasta do projeto API e crie as pastas organizacionais.

 ```bash
 mkdir Models
 mkdir Data
 ```

 ### 2. Entidade
 **Arquivo: `Models/Livro.cs`**

 Representa a entidade de negócio "Livro". O Entity Framework usará esta classe para criar a tabela `Livros` no banco de dados, onde cada propriedade se tornará uma coluna (ex: `Titulo` vira `varchar`, `Preco` vira `numeric`).

 ```csharp
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
 ```

 > **Nota:** Alguns projetos optam por utilizar "Entities" em vez de "Models" no nome da pasta.

 ### 3. Contexto de Banco de Dados
 **Arquivo: `Data/AppDbContext.cs`**

 Atua como a ponte principal entre o código C# e o PostgreSQL. Ele herda de `DbContext` e é responsável por gerenciar a conexão, mapear as classes para tabelas e traduzir as consultas LINQ para comandos SQL.

 ```csharp
 using Microsoft.EntityFrameworkCore;
 using LivrariaCentral.API.Models;

 namespace LivrariaCentral.API.Data;

 public class AppDbContext : DbContext
 {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

      Define que a classe Livro será uma tabela chamada "Livros"
     public DbSet<Livro> Livros { get; set; }
 }
 ```

 ### 4. Configuração da Aplicação (Connection String)

 Define as credenciais para acessar o banco de dados.
 **Arquivo: `appsettings.json`**

 ```json
 {
   "Logging": {
     "LogLevel": {
       "Default": "Information",
       "Microsoft.AspNetCore": "Warning"
     }
   },
   "AllowedHosts": "*",
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=LivrariaCentral;Username=postgres;Password=admin"
   }
 }
 ```

 ### 5. Configuração dos Serviços (Program.cs)

 Substitua todo o conteúdo do arquivo `Program.cs` pelo código abaixo. Ele configura a Injeção de Dependência do Banco, ativa os Controllers e o Swagger.

 **Arquivo: `Program.cs`**

 ```csharp
 using LivrariaCentral.API.Data;
 using Microsoft.EntityFrameworkCore;

 var builder = WebApplication.CreateBuilder(args);

 // --- 1. CONFIGURAÇÃO DO BANCO (POSTGRES) ---

 // Lê a string de conexão do appsettings.json
 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

 // Registra o AppDbContext na injeção de dependência usando Npgsql
 builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(connectionString));

 // --------------------------------------------

 // Adiciona suporte a Controllers (API)
 builder.Services.AddControllers();

 // Adiciona suporte ao Swagger (Documentação da API)
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();

 var app = builder.Build();

 // --- 2. PIPELINE DE REQUISIÇÃO HTTP ---

 // Se estiver em ambiente de desenvolvimento, ativa o Swagger visual
 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }

 // Redireciona HTTP para HTTPS
 app.UseHttpsRedirection();

 app.UseAuthorization();

 // Mapeia os Controllers para as rotas da API
 app.MapControllers();

 // Roda a aplicação
 app.Run();
 ```

 > **Obs:** Caso de erro (linha vermelha) nas linhas de Swagger, use o comando abaixo no terminal dentro de LivrariaCentral.API:
 ```bash
 dotnet add package Swashbuckle.AspNetCore
 ```

 ### 6. Migrations (Inicialização do Banco)

 Execute os comandos abaixo no terminal para criar o banco de dados físico.

 ```bash
 # Ferramenta ef
 dotnet tool install --global dotnet-ef

 # Cria o script de migração (receita) baseado nas classes C#
 dotnet ef migrations add InitialCreate

 # Aplica o script no banco de dados PostgreSQL
 dotnet ef database update
 ```

 ---

 ## 🚀 Sessão 4: Endpoints da API (Controllers)

 Os Controllers são responsáveis por receber as requisições HTTP (GET, POST, PUT, DELETE), processar a lógica e retornar os dados.

 ### 1. Criar o Controller de Livros

 Crie um arquivo chamado `LivrosController.cs` dentro da pasta `Controllers`.
 **Arquivo: `Controllers/LivrosController.cs`**

 ```csharp
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using LivrariaCentral.API.Data;
 using LivrariaCentral.API.Models;

 namespace LivrariaCentral.API.Controllers;

 [Route("api/[controller]")]  A rota será: api/livros
 [ApiController]
 public class LivrosController : ControllerBase
 {
     private readonly AppDbContext _context;

     // Injeção de Dependência do Banco de Dados
     public LivrosController(AppDbContext context)
     {
         _context = context;
     }

      GET: api/livros (Listar todos)
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

          Retorna código 201 (Created) e o link para acessar o item criado
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
 ```

 ### 2. Executando e Testando (Swagger)

 Agora vamos rodar a API e ver a interface gráfica do Swagger.

 ```bash
 dotnet run
 ```

 1. Observe no terminal qual porta local foi aberta (geralmente `http:localhost:5000` ou similar).
 2. Abra o navegador e acesse: `http:localhost:5000/swagger`.
 3. Você verá a lista de endpoints. Clique em **POST /api/livros**, depois em "Try it out" e insira um JSON de exemplo para cadastrar seu primeiro livro.