 # 📚 Livraria Central - Sistema de Gestão Full Stack

 ![Status](https://img.shields.io/badge/Status-Concluído-success?style=for-the-badge)

 ![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
 ![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
 ![MudBlazor](https://img.shields.io/badge/MudBlazor-7E6EEF?style=for-the-badge&logo=mui&logoColor=white)
 ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)

 > **Uma solução completa para gerenciamento de livrarias, desenvolvida com as tecnologias mais modernas do ecossistema .NET.**

 ## 💡 Sobre o Projeto

 Este projeto é uma aplicação **Full Stack** robusta desenvolvida para simular o ambiente real de uma livraria. Diferente de projetos acadêmicos simples, o objetivo aqui foi criar um sistema funcional com regras de negócio reais, controle de concorrência, autenticação segura e relatórios.

 ### 🎯 Objetivos
 1.  **Portfólio Técnico:** Demonstrar domínio em arquitetura de software, Clean Code e padrões de mercado (.NET 10, Blazor WASM).
 2.  **Material Didático:** O repositório contém um **Guia Passo a Passo** (logo abaixo) para desenvolvedores que desejam aprender a construir aplicações reais do zero.

 ## 🗺️ Roadmap do Projeto

 Este repositório representa a **Parte 1** de uma série de estudos avançados. O objetivo é demonstrar a evolução de um software funcional ("Make it Work") para uma solução Enterprise escalável ("Make it Right").

 | Fase | Foco | Status | Descrição | Acesso |
 | :--- | :--- | :---: | :--- | :--- |
 | **Parte 1** | **MVP Funcional** | ✅ | Construção da aplicação completa (Back + Front + Banco), focado em entrega de valor e funcionalidades (Vendas, Auth, PDF, Logs). | (Atual)
 | **Parte 2** | **Arquitetura & Qualidade** | ✅ | Refatoração para **Clean Architecture**, implementação de **Testes Unitários** (xUnit), Padrão Repository e validações avançadas (FluentValidation). | https://github.com/Hugo-Novo-Gouvea/Projeto-.NET-Livraria-Central-Parte-2
 | **Parte 3** | **Cloud & DevOps** | 🚧 | Migração para **Microsoft Azure**, configuração de Pipeline de **CI/CD** (GitHub Actions), Dockerização e gestão de segredos. | (Em Breve)

 ## 🛠️ Tecnologias Utilizadas

 * **Backend:** .NET 10 (Web API), Entity Framework Core.
 * **Frontend:** Blazor WebAssembly (SPA), MudBlazor (Material Design).
 * **Banco de Dados:** PostgreSQL 18.
 * **Segurança:** JWT (JSON Web Tokens), BCrypt (Hash de Senhas).
 * **Relatórios:** QuestPDF (Geração de PDFs profissionais).
 * **Observabilidade:** Serilog (Logs estruturados e auditoria em arquivo).
 * **Deploy:** Configuração pronta para Windows Service (IIS) e Linux (Nginx + Systemd).

 ## ✨ Funcionalidades Principais

 ✅ **Dashboard Interativo:** Gráficos de vendas e indicadores de estoque (KPIs) em tempo real.  
 ✅ **Gestão de Livros:** Cadastro, edição e exclusão com validações de negócio.  
 ✅ **Ponto de Venda (PDV):** Registro de vendas com cálculo automático e baixa de estoque.  
 ✅ **Segurança:** Autenticação via Token JWT, proteção de rotas e criptografia.  
 ✅ **Auditoria:** Logs detalhados de rastreabilidade (ex: "Quem excluiu o livro X?").  
 ✅ **Relatórios:** Exportação de listagem de estoque em PDF.  

 ## 📸 Pré-visualização

 | Dashboard (KPIs) | Gestão de Estoque |
 |:---:|:---:|
 | ![Dashboard](img/dashboard.png) | ![Livros](img/tabela.png) |

 ## 🚀 Quick Start (Como Rodar)

 Siga os passos abaixo para executar o projeto em sua máquina local.

 ### Pré-requisitos
 * .NET SDK 10 (ou superior)
 * PostgreSQL

 ### Passo a Passo

 1.  **Clone o repositório:**
     ```bash
     git clone [https://github.com/seu-usuario/LivrariaCentral.git](https://github.com/seu-usuario/LivrariaCentral.git)
     cd LivrariaCentral
     ```

 2.  **Configure o Banco de Dados:**
     * Certifique-se que o PostgreSQL está rodando.
     * Abra `src/LivrariaCentral.API/appsettings.json` e ajuste a `ConnectionStrings` com sua senha.

 3.  **Crie o Banco (Migrations):**
     ```bash
     cd src/LivrariaCentral.API
     dotnet ef database update
     ```

 4.  **Execute a Aplicação:**
     Abra dois terminais.
     
     *Terminal 1 (Backend):*
     ```bash
     cd src/LivrariaCentral.API
     dotnet run
     ```
     
     *Terminal 2 (Frontend):*
     ```bash
     cd src/LivrariaCentral.Web
     dotnet run
     ```

 5.  **Acesse o Sistema:**
     * Abra o navegador no endereço indicado pelo Frontend (ex: `http://localhost:xxxx`).
     * **Login Inicial:** Como o sistema é fechado, utilize o Swagger (`/api/auth/registrar`) para criar seu primeiro usuário admin ou insira manualmente no banco.

 # 📖 Guia de Desenvolvimento (Passo a Passo)

 > **📝 Nota para Estudantes:**
 > 
 > O conteúdo abaixo serve como um tutorial sequencial para quem deseja replicar este projeto do zero, explicando não apenas o código, mas o **"porquê"** das decisões tomadas.
 >
 > **Siga as sessões na ordem para garantir o aprendizado.**

 ## 🚀 Sessão 1: Configuração do Ambiente

 Antes de colocarmos a mão na massa, precisamos preparar o terreno. Assim como um chef precisa de suas facas afiadas, nós precisamos garantir que as ferramentas corretas estão instaladas na sua máquina.

 ### 1. Infraestrutura Necessária

 Para desenvolver este projeto, utilizaremos um conjunto de tecnologias modernas e robustas. Certifique-se de ter os seguintes itens instalados e configurados:

 * **🐘 Banco de Dados PostgreSQL 18:** Onde guardaremos nossos livros, usuários e vendas de forma segura.
 * **💻 .NET SDK 10:** O kit de desenvolvimento da Microsoft necessário para criar, compilar e rodar nossa aplicação.
 * **📝 Visual Studio Code:** Nosso editor de código (IDE), leve e poderoso.

 ## 🚀 Sessão 2: Criação da API

 Agora que o ambiente está pronto, vamos construir o **Back-end** do nosso sistema. É aqui que toda a regra de negócio e a conexão com o banco de dados vão morar.

 > **🧠 Conceito: O que é uma WebAPI?**
 > Pense nela como o "cérebro" invisível do sistema. Diferente de um site comum, a API não entrega telas (HTML), ela entrega **Dados Puros** (geralmente JSON).
 > * Ela recebe pedidos (ex: "Cadastrar Livro").
 > * Ela processa as regras (ex: "Preço não pode ser zero").
 > * Ela responde para quem pediu (o Site/Frontend).

 ### 1. Organização da Solução (Pasta Source)

 Para manter o projeto organizado profissionalmente, não misturamos código-fonte com arquivos de configuração (como o `.git` ou `README.md`). Usaremos o padrão de mercado `src` (source).

 **No terminal, na raiz onde você quer criar o projeto, execute:**

 ```bash
 mkdir src
 cd src
 ```

 ### 2. Estrutura Inicial da API

 Vamos usar o esqueleto oficial da Microsoft para criar nosso projeto base.

 **Ainda dentro da pasta `src`, execute o comando:**

 ```bash
 # Cria o projeto do tipo WebAPI com o nome "LivrariaCentral.API"
 dotnet new webapi -n LivrariaCentral.API
 ```

 **✅ Checkpoint Visual:**
 A sua estrutura de pastas deve ter ficado assim:

 ```text
 src/
 └── LivrariaCentral.API/
     ├── Properties/
     ├── appsettings.json
     ├── LivrariaCentral.API.csproj
     ├── LivrariaCentral.API.http
     └── Program.cs
 ```

 ### 3. Instalação de Pacotes (Ferramentas)

 O .NET vem "limpo" para ser leve. Para conversar com o banco de dados PostgreSQL, precisamos instalar ferramentas adicionais (o Entity Framework).

 **1. Entre na pasta do projeto criado:**

 ```bash
 cd LivrariaCentral.API
 ```

 **2. Instale os pacotes necessários:**

 ```bash
 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
 ```

 > **🔍 O que instalamos?**
 > * **EntityFrameworkCore:** O "tradutor" que permite escrever códigos C# em vez de SQL puro.
 > * **EntityFrameworkCore.Design:** As ferramentas para rodar comandos de criação de banco (Migrations) pelo terminal.
 > * **Npgsql.PostgreSQL:** O "motorista" que ensina o Entity Framework a falar especificamente com o banco PostgreSQL.

 ## 🚀 Sessão 3: Configuração da API (Backend)

 Agora que temos a estrutura vazia, vamos transformá-la em uma API real.

 > **🧠 Conceito: Code-First (Primeiro o Código)**
 > Em vez de abrir o banco de dados e criar tabelas com SQL (CREATE TABLE...), nós criamos **Classes C#**.
 > O Entity Framework lê essas classes e cria o banco de dados automaticamente para nós.

 ### 1. Estrutura de Pastas

 Vamos organizar a casa criando as divisões para a lógica do banco de dados.

 **No terminal, dentro da pasta `src/LivrariaCentral.API`, execute:**

 ```bash
 mkdir Models  # Onde ficam as classes (Entidades)
 mkdir Data    # Onde fica a configuração do Banco
 ```

 ### 2. Criando a Entidade (O Molde)

 Precisamos ensinar ao sistema o que é um "Livro".

 **1. Localize a pasta:** `src/LivrariaCentral.API/Models`
 **2. Crie o arquivo:** `Livro.cs`
 **3. Adicione o código:**

 ```csharp
 namespace LivrariaCentral.API.Models;

 public class Livro
 {
     public int Id { get; set; } // O EF Core entende automaticamente que "Id" é a Chave Primária (PK)
     public string Titulo { get; set; } = string.Empty; // Inicializa vazio para evitar erros de Nulo
     public string Autor { get; set; } = string.Empty;
     public decimal Preco { get; set; } // "decimal" é obrigatório para dinheiro (evita erros de arredondamento do "double")
     public int Estoque { get; set; }
     public DateTime DataCadastro { get; set; } = DateTime.UtcNow; // Sempre use UTC para evitar confusão de fuso horário
 }
 ```

 ### 3. Contexto de Banco de Dados (A Ponte)

 O Contexto é a classe que traduz o C# para o PostgreSQL.

 **1. Localize a pasta:** `src/LivrariaCentral.API/Data`
 **2. Crie o arquivo:** `AppDbContext.cs`
 **3. Adicione o código:**

 ```csharp
 using Microsoft.EntityFrameworkCore;
 using LivrariaCentral.API.Models;

 namespace LivrariaCentral.API.Data;

 // Herdar de DbContext transforma essa classe em uma ferramenta do EF Core
 public class AppDbContext : DbContext
 {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     // Esta linha diz: "Crie uma tabela chamada 'Livros' baseada na classe 'Livro'"
     public DbSet<Livro> Livros { get; set; }
 }
 ```

 ### 4. Connection String (O Endereço do Banco)

 Precisamos configurar onde o banco está e qual a senha de acesso.

 **1. Localize o arquivo:** `src/LivrariaCentral.API/appsettings.json`
 **2. Adicione a vírgula após "AllowedHosts" e insira o bloco "ConnectionStrings":**

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

 > **⚠️ Atenção Crítica:**
 > 1. Substitua `admin` pela senha que você criou ao instalar o PostgreSQL.
 > 2. **Segurança:** Em projetos reais, jamais commitamos senhas no Git. Usamos *User Secrets* ou *Variáveis de Ambiente*. Aqui faremos assim apenas para fins didáticos locais.

 ### 5. Configuração dos Serviços (Program.cs)

 Agora precisamos "ligar os fios": registrar o banco de dados e ativar o Swagger (documentação).

 **1. Instale o pacote do Swagger via terminal (na pasta da API):**

 ```bash
 dotnet add package Swashbuckle.AspNetCore
 ```

 **2. Substitua TODO o conteúdo de `src/LivrariaCentral.API/Program.cs` por:**

 ```csharp
 using LivrariaCentral.API.Data;
 using Microsoft.EntityFrameworkCore;

 var builder = WebApplication.CreateBuilder(args);

 // --- 1. CONFIGURAÇÃO DOS SERVIÇOS (INJEÇÃO DE DEPENDÊNCIA) ---

 // Pega a conexão do arquivo appsettings.json
 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

 // Ensina a API a usar o PostgreSQL
 builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(connectionString));

 // Ativa os Controllers (nossas rotas de API)
 builder.Services.AddControllers();

 // Configura o Swagger (Documentação Automática)
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();

 var app = builder.Build();

 // --- 2. PIPELINE DE REQUISIÇÃO (MIDDLEWARES) ---

 // Se estiver rodando local (Development), mostra o Swagger
 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }

 app.UseHttpsRedirection();
 app.UseAuthorization();
 app.MapControllers();

 app.Run();
 ```

 ### 6. Migrations (Criando o Banco)

 Chegou a hora da verdade. Vamos rodar os comandos que leem seu código C# e criam a tabela no PostgreSQL.

 **No terminal (pasta da API), execute na ordem:**

 ```bash
 # 1. Instala a ferramenta global do EF (apenas na primeira vez)
 dotnet tool install --global dotnet-ef

 # 2. Cria o arquivo de instrução (Migration) - O "Plano de Voo"
 dotnet ef migrations add InitialCreate

 # 3. Executa a instrução no banco - A "Decolagem"
 dotnet ef database update
 ```

 > **✅ Checkpoint de Sucesso:**
 > Se o comando terminar sem erros vermelhos e aparecer `Done.`, seu banco de dados foi criado!
 > Você pode abrir seu gerenciador de banco (pgAdmin ou DBeaver) e verá a tabela `Livros` criada com as colunas certas.

 ## 🚀 Sessão 4: Endpoints da API (Controllers)

 Os **Controllers** são os "garçons" da nossa API. Eles são responsáveis por receber os pedidos HTTP (GET, POST, PUT, DELETE), processar a regra de negócio e devolver os dados.

 > **🧠 Conceito: O Ciclo da Requisição**
 > 1. O Usuário pede (Request) -> 2. Controller recebe -> 3. Controller chama o Banco -> 4. Controller devolve (Response).

 

 ### 1. Criar a Pasta de Controladores

 Dentro da pasta da API, vamos criar um local organizado para guardar nossos controladores.

 **No terminal, execute:**

 ```bash
 cd src/LivrariaCentral.API # Apenas se não estiver nela
 mkdir Controllers
 ```

 ### 2. Criar o Controller de Livros

 Vamos implementar o CRUD completo (Create, Read, Update, Delete).

 **1. Localize a pasta:** `src/LivrariaCentral.API/Controllers`
 **2. Crie o arquivo:** `LivrosController.cs`
 **3. Adicione o código:**

 ```csharp
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using LivrariaCentral.API.Data;
 using LivrariaCentral.API.Models;

 namespace LivrariaCentral.API.Controllers;

 [Route("api/[controller]")]  // Define a rota base como: api/livros
 [ApiController]
 public class LivrosController : ControllerBase
 {
     private readonly AppDbContext _context;

     // Injeção de Dependência: Recebemos o Banco de Dados pronto para uso
     public LivrosController(AppDbContext context)
     {
         _context = context;
     }

     // GET: api/livros (Listar todos os livros)
     [HttpGet]
     public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
     {
         return await _context.Livros.ToListAsync();
     }

     // GET: api/livros/5 (Busca um livro específico pelo ID)
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

     // POST: api/livros (Criar um novo livro)
     [HttpPost]
     public async Task<ActionResult<Livro>> PostLivro(Livro livro)
     {
         _context.Livros.Add(livro);
         await _context.SaveChangesAsync();

         // Retorna código 201 (Created) e o link para acessar o item criado
         return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
     }

     // PUT: api/livros/5 (Atualiza um livro existente)
     [HttpPut("{id}")]
     public async Task<IActionResult> PutLivro(int id, Livro livro)
     {
         if (id != livro.Id) return BadRequest();

         _context.Entry(livro).State = EntityState.Modified;

         try
         {
             await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
             if (!_context.Livros.Any(e => e.Id == id))
                 return NotFound();
             else
                 throw;
         }

         return NoContent();
     }

     // DELETE: api/livros/5 (Deleta um livro)
     [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteLivro(int id)
     {
         var livro = await _context.Livros.FindAsync(id);
         if (livro == null) return NotFound();

         _context.Livros.Remove(livro);
         await _context.SaveChangesAsync();

         return NoContent();
     }
 }
 ```

 ### 3. Executando e Testando (Swagger)

 Agora vamos rodar a API e ver a "mágica" acontecendo na interface gráfica.

 **1. No terminal (`src/LivrariaCentral.API`), execute:**

 ```bash
 dotnet run
 ```

 **2. Acesse o Swagger:**
 * Observe no terminal a linha `Now listening on: http://localhost:xxxx`.
 * Abra o navegador e digite: `http://localhost:xxxx/swagger` (substitua `xxxx` pela porta que apareceu).

 **3. Teste Prático (Cadastro):**
 * Clique em **POST /api/livros**.
 * Clique no botão **Try it out** (no canto direito).
 * Cole este JSON (note que não precisamos enviar ID nem Data):
     ```json
     {
       "titulo": "Arquitetura Limpa",
       "autor": "Robert C. Martin",
       "preco": 120.99,
       "estoque": 10
     }
     ```
 * Clique em **Execute**.

 ### 4. Entendendo a Resposta

 Logo abaixo, na seção **Server response**, verifique o **Code**:

 * **Code 201 (Created):** Sucesso! O registro foi criado. O corpo da resposta mostrará o livro com o `ID` gerado pelo banco.
 * **Code 200 (Success):** Sucesso na consulta ou atualização.

 Parabéns! Seu Back-end está completo: ele **adiciona, lê, altera e remove** dados do PostgreSQL. Isso é o que chamamos de **CRUD**.

 ## 🚀 Sessão 5: Criação do Frontend (Blazor WebAssembly)

 O Frontend será uma **Single Page Application (SPA)**. Isso significa que o site carrega apenas uma vez e depois navega instantaneamente, parecendo um aplicativo de celular.

 > **🧠 Conceito: SPA vs Tradicional**
 > Em sites antigos, cada clique recarregava a página inteira (tela branca). No SPA (como Gmail ou Trello), apenas os dados mudam, a estrutura fica. É muito mais rápido.

 ### 1. Criação do Projeto

 Volte para a pasta `src` e crie o projeto web ao lado da API.

 **No terminal, execute:**

 ```bash
 cd .. # Volta para pasta 'src'

 # Cria o projeto Blazor WebAssembly
 dotnet new blazorwasm -n LivrariaCentral.Web

 # Entra na pasta
 cd LivrariaCentral.Web
 ```

 **✅ Checkpoint Visual:**
 Agora sua pasta `src` tem dois projetos irmãos:

 ```text
 src/
 ├── LivrariaCentral.API/  (Backend)
 └── LivrariaCentral.Web/  (Frontend - Novo)
 ```

 ### 2. Instalação da Biblioteca Visual (MudBlazor)

 Instala o pacote de componentes (Gráficos, Tabelas, Botões). Vamos usar a **versão 7** para garantir compatibilidade.

 ```bash
 dotnet add package MudBlazor --version 7.0.0
 ```

 > **🧠 Conceito: MudBlazor**
 > É uma caixa de "LEGO" visual. Em vez de escrevermos CSS puro, usamos componentes prontos (como `<MudButton>`, `<MudDataGrid>`) que já vêm bonitos e responsivos.

 ### 3. Configuração Inicial

 Primeiro, vamos adicionar o projeto Web à solução geral para que o Visual Studio enxergue os dois.

 ```bash
 cd ..
 cd ..
 # Volta para a raiz onde está o arquivo .sln

 dotnet sln add src/LivrariaCentral.Web/LivrariaCentral.Web.csproj
 ```

 Agora, vamos configurar o MudBlazor nos arquivos do projeto.

 #### A. Importações Globais (_Imports.razor)

 Este arquivo define o que está disponível em **todas** as páginas sem precisar importar de novo.

 **Abra o arquivo:** `src/LivrariaCentral.Web/_Imports.razor`
 **Adicione ao final:**

 ```razor
 @using System.Net.Http
 @using System.Net.Http.Json
 @using Microsoft.AspNetCore.Components.Forms
 @using Microsoft.AspNetCore.Components.Routing
 @using Microsoft.AspNetCore.Components.Web
 @using Microsoft.AspNetCore.Components.Web.Virtualization
 @using Microsoft.AspNetCore.Components.WebAssembly.Http
 @using Microsoft.JSInterop
 @using LivrariaCentral.Web
 @using LivrariaCentral.Web.Layout

 // --- Adicione estas linhas do MudBlazor ---
 @using MudBlazor
 @using MudBlazor.Components
 ```

 #### B. Referências de CSS e JS (index.html)

 Precisamos adicionar as fontes do Google (Roboto) e os scripts que fazem os componentes funcionarem.

 **Abra o arquivo:** `src/LivrariaCentral.Web/wwwroot/index.html`
 **Substitua TODO o conteúdo por:**

 ```html
 <!DOCTYPE html>
 <html lang="en">

 <head>
     <meta charset="utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <title>LivrariaCentral.Web</title>
     <base href="/" />
     <link rel="stylesheet" href="css/app.css" />
     <link rel="icon" type="image/png" href="favicon.png" />
     <link href="LivrariaCentral.Web.styles.css" rel="stylesheet" />
     
          <link href="[https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap](https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap)" rel="stylesheet" />
     <link href="_content/MudBlazor/MudBlazor.min.css" rel="stylesheet" />
 </head>

 <body>
     <div id="app">
         <svg class="loading-progress">
             <circle r="40%" cx="50%" cy="50%" />
             <circle r="40%" cx="50%" cy="50%" />
         </svg>
         <div class="loading-progress-text"></div>
     </div>

     <div id="blazor-error-ui">
         An unhandled error has occurred.
         <a href="." class="reload">Reload</a>
         <span class="dismiss">🗙</span>
     </div>
     
     <script src="_framework/blazor.webassembly.js"></script>
          <script src="_content/MudBlazor/MudBlazor.min.js"></script>
 </body>

 </html>
 ```

 ### 4. Configuração de Ambiente (appsettings.json)

 Diferente da API, o Blazor WebAssembly não cria o arquivo de configuração por padrão. Precisamos criá-lo para evitar deixar o endereço da API "chumbado" (fixo) no código C#.

 **1. Localize a pasta:** `src/LivrariaCentral.Web/wwwroot`
 **2. Crie o arquivo:** `appsettings.json`
 **3. Adicione o código:**

 ```json
 {
   "ApiUrl": "http://localhost:5000"
 }
 ```

 > **⚠️ Importante:** O valor `http://localhost:5000` é um exemplo. Quando você rodar sua API, verifique qual porta ela pegou e atualize este arquivo se necessário.

 ### 5. Registro de Serviços (Program.cs)

 Agora vamos ensinar o Blazor a ler esse arquivo JSON e usar o endereço correto para conectar no Backend.

 **Substitua TODO o arquivo:** `src/LivrariaCentral.Web/Program.cs`

 ```csharp
 using Microsoft.AspNetCore.Components.Web;
 using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
 using LivrariaCentral.Web;
 using MudBlazor.Services;

 var builder = WebAssemblyHostBuilder.CreateDefault(args);
 builder.RootComponents.Add<App>("#app");
 builder.RootComponents.Add<HeadOutlet>("head::after");

 // --- 1. LER CONFIGURAÇÃO DA API ---
 // O Blazor baixa o appsettings.json automaticamente. Aqui nós lemos a chave "ApiUrl".
 var apiUrl = builder.Configuration.GetValue<string>("ApiUrl") ?? "http://localhost:5000";

 // --- 2. CONFIGURAR CLIENTE HTTP ---
 // Isso cria um "HttpClient" pré-configurado que sabe onde a API mora.
 builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

 // --- 3. CONFIGURAR MUDBLAZOR ---
 builder.Services.AddMudServices();

 await builder.Build().RunAsync();
 ```

 ### 6. Teste Inicial

 Vamos garantir que nada quebrou até agora.

 ```bash
 cd src/LivrariaCentral.Web # Apenas se necessário
 dotnet run
 ```

 1.  Abra o navegador no endereço indicado (ex: `http://localhost:xxxx`).
 2.  Se você ver a mensagem **"Hello World"** (ainda sem estilo bonito), está tudo certo!

 ### 7. Aplicando o Layout de Dashboard

 Vamos substituir o layout padrão pelo layout do MudBlazor (Menu Lateral + Barra Superior).

 **Substitua TODO o arquivo:** `src/LivrariaCentral.Web/Layout/MainLayout.razor`

 ```razor
 @inherits LayoutComponentBase

  <MudThemeProvider /> 
 <MudPopoverProvider />
 <MudDialogProvider />
 <MudSnackbarProvider />

 <MudLayout>
     <MudAppBar Elevation="1">
         <MudIconButton Icon="@Icons.Material.Filled.Menu" Color="Color.Inherit" Edge="Edge.Start" OnClick="@((e) => DrawerToggle())" />
         <MudText Typo="Typo.h6" Class="ml-3">Livraria Central</MudText>
         <MudSpacer />
         <MudIconButton Icon="@Icons.Material.Filled.Person" Color="Color.Inherit" />
     </MudAppBar>

     <MudDrawer @bind-Open="_drawerOpen" ClipMode="DrawerClipMode.Always" Elevation="2">
         <MudNavMenu>
             <MudNavLink Href="/" Match="NavLinkMatch.All" Icon="@Icons.Material.Filled.Dashboard">Dashboard</MudNavLink>
             <MudNavLink Href="/livros" Icon="@Icons.Material.Filled.LibraryBooks">Livros</MudNavLink>
             <MudNavLink Href="/historico" Icon="@Icons.Material.Filled.History">Histórico</MudNavLink>
         </MudNavMenu>
     </MudDrawer>

     <MudMainContent>
         <MudContainer MaxWidth="MaxWidth.Large" Class="mt-4">
             @Body
         </MudContainer>
     </MudMainContent>
 </MudLayout>

 @code {
     bool _drawerOpen = true;

     void DrawerToggle()
     {
         _drawerOpen = !_drawerOpen;
     }
 }
 ```

 ### 8. Testando o Novo Visual

 Rode o projeto novamente (`dotnet run`). Agora você deve ver um site com **Menu Lateral** e uma **Barra Azul** no topo. O MudBlazor está funcionando!

 ## 🚀 Sessão 6: Criando o Dashboard (Visual)

 Vamos criar a tela inicial com **Indicadores de Desempenho (KPIs)** e gráficos. Por enquanto, usaremos dados "Fictícios" (Hardcoded) apenas para estruturar o layout e ver como o MudBlazor organiza a tela.

 ### 1. Editando a Página Inicial (Home.razor)

 **Substitua TODO o conteúdo do arquivo:** `src/LivrariaCentral.Web/Pages/Home.razor`

 ```razor
 @page "/"

 <MudText Typo="Typo.h4" Class="mb-4">Dashboard</MudText>

 <MudGrid>
          <MudItem xs="12" sm="6" md="3">
         <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
             <MudIcon Icon="@Icons.Material.Filled.AttachMoney" Color="Color.Success" Class="mx-4" Style="width:54px; height:54px;" />
             <div>
                 <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Vendas Hoje</MudText>
                 <MudText Typo="Typo.h5">R$ 1.250,00</MudText>
             </div>
         </MudPaper>
     </MudItem>

     <MudItem xs="12" sm="6" md="3">
         <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
             <MudIcon Icon="@Icons.Material.Filled.LibraryBooks" Color="Color.Primary" Class="mx-4" Style="width:54px; height:54px;" />
             <div>
                 <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Livros Vendidos</MudText>
                 <MudText Typo="Typo.h5">45</MudText>
             </div>
         </MudPaper>
     </MudItem>

     <MudItem xs="12" sm="6" md="3">
         <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
             <MudIcon Icon="@Icons.Material.Filled.Warning" Color="Color.Warning" Class="mx-4" Style="width:54px; height:54px;" />
             <div>
                 <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Estoque Baixo</MudText>
                 <MudText Typo="Typo.h5">3 Títulos</MudText>
             </div>
         </MudPaper>
     </MudItem>

     <MudItem xs="12" sm="6" md="3">
         <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
             <MudIcon Icon="@Icons.Material.Filled.People" Color="Color.Info" Class="mx-4" Style="width:54px; height:54px;" />
             <div>
                 <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Clientes</MudText>
                 <MudText Typo="Typo.h5">120</MudText>
             </div>
         </MudPaper>
     </MudItem>

          <MudItem xs="12" md="8">
         <MudPaper Class="pa-4">
             <MudText Typo="Typo.h6">Vendas dos Últimos 6 Meses</MudText>
             <MudChart ChartType="ChartType.Bar" ChartSeries="@Series" XAxisLabels="@XAxisLabels" Width="100%" Height="350px"></MudChart>
         </MudPaper>
     </MudItem>

     <MudItem xs="12" md="4">
         <MudPaper Class="pa-4">
             <MudText Typo="Typo.h6">Categorias Mais Vendidas</MudText>
             <MudChart ChartType="ChartType.Donut" InputData="@DonutData" InputLabels="@DonutLabels" Width="100%" Height="300px" />
         </MudPaper>
     </MudItem>
 </MudGrid>

 @code {
     // --- Dados Fictícios para o Gráfico de Barras ---
     public List<ChartSeries> Series = new List<ChartSeries>()
     {
         new ChartSeries() { Name = "Vendas (R$)", Data = new double[] { 4000, 2000, 8000, 15000, 6000, 9000 } }
     };

     public string[] XAxisLabels = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun" };

     // --- Dados Fictícios para o Gráfico de Pizza ---
     public double[] DonutData = { 25, 45, 10, 20 };
     public string[] DonutLabels = { "Ficção", "Técnico", "Romance", "HQs" };
 }
 ```

 ### 2. Testando o Dashboard

 1.  Rode o projeto Frontend (`dotnet run` na pasta Web).
 2.  Acesse o navegador.

 **✅ Checkpoint Visual:**
 Você deve ver um painel de controle executivo:
 * **Topo:** 4 Cards com ícones coloridos alinhados horizontalmente.
 * **Esquerda:** Um gráfico de barras interativo mostrando a evolução mensal.
 * **Direita:** Um gráfico de rosca (Donut) mostrando categorias.

  ## 🚀 Sessão 7: Conectando com a API (Listagem Real)

 Nesta etapa, vamos permitir que o Frontend converse com o Backend. Para isso, precisamos configurar o **CORS** (Cross-Origin Resource Sharing) e criar a tabela de listagem de livros que consome dados reais.

 > **🧠 Conceito: O que é CORS?**
 > Por padrão, navegadores bloqueiam quando um site (ex: `localhost:5000`) tenta acessar uma API em outra porta (ex: `localhost:5123`). O CORS é a "autorização" que o Backend dá para o Frontend acessar seus dados.

 

 ### 1. Configurando CORS na API (Backend)

 Vamos liberar o acesso para qualquer origem (para facilitar o desenvolvimento).

 **Abra o arquivo:** `src/LivrariaCentral.API/Program.cs`
 **Adicione as linhas marcadas com `[NOVO] <---`:**

 ```csharp
 // ... (códigos anteriores)
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();

 // [NOVO] Liberar o CORS (Permitir acesso do Frontend) <---
 builder.Services.AddCors(options =>
 {
     options.AddPolicy("AllowAll",
         policy =>
         {
             policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
         });
 });

 var app = builder.Build();

 // ... (códigos anteriores do Swagger)

 app.UseHttpsRedirection();

 // [NOVO] Ativar a política de CORS (Antes do Authorization) <---
 app.UseCors("AllowAll"); 

 app.UseAuthorization();
 // ... (resto do código)
 ```

 ### 2. Modelagem no Frontend

 O Frontend precisa saber o que é um "Livro" para poder ler o JSON que vem da API.

 **1. Crie a pasta:** `src/LivrariaCentral.Web/Models`
 **2. Crie o arquivo:** `Livro.cs`

 ```csharp
 namespace LivrariaCentral.Web.Models;

 public class Livro
 {
     public int Id { get; set; }
     public string Titulo { get; set; } = string.Empty;
     public string Autor { get; set; } = string.Empty;
     public decimal Preco { get; set; }
     public int Estoque { get; set; }
     public DateTime DataCadastro { get; set; }
 }
 ```

 **✅ Checkpoint Visual:**

 ```text
 src/
 └── LivrariaCentral.Web/
     └── Models/
         └── Livro.cs  <-- (Novo arquivo)
 ```

 ### 3. Criando a Página de Listagem (Livros.razor)

 Vamos usar o componente `MudDataGrid` que é super poderoso: já traz busca, filtro e paginação prontos.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Pages/Livros.razor`

 ```razor
 @page "/livros"
 @using LivrariaCentral.Web.Models
 @inject HttpClient Http

 <MudText Typo="Typo.h4" Class="mb-4">Gerenciar Livros</MudText>

 @if (livros == null)
 {
     <MudProgressCircular Color="Color.Primary" Indeterminate="true" />
 }
 else
 {
     <MudDataGrid Items="@livros" Filterable="true" SortMode="SortMode.Multiple" QuickFilter="@_quickFilter">
         <ToolBarContent>
             <MudText Typo="Typo.h6">Lista de Livros</MudText>
             <MudSpacer />
             <MudTextField @bind-Value="_searchString" Placeholder="Buscar..." Adornment="Adornment.Start" Immediate="true"
                           AdornmentIcon="@Icons.Material.Filled.Search" IconSize="Size.Medium" Class="mt-0"></MudTextField>
         </ToolBarContent>
         
         <Columns>
             <PropertyColumn Property="x => x.Id" Title="#" Sortable="true" Filterable="false" />
             <PropertyColumn Property="x => x.Titulo" Sortable="true" />
             <PropertyColumn Property="x => x.Autor" Sortable="true" />
             <PropertyColumn Property="x => x.Estoque" Title="Qtd." />
             <PropertyColumn Property="x => x.Preco" Title="Preço" Format="C" />
             
             <TemplateColumn CellClass="d-flex justify-end">
                 <CellTemplate>
                     <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.Edit" Color="@Color.Primary" />
                     <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.Delete" Color="@Color.Error" />
                 </CellTemplate>
             </TemplateColumn>
         </Columns>
         
         <PagerContent>
             <MudDataGridPager T="Livro" />
         </PagerContent>
     </MudDataGrid>
 }

 @code {
     private List<Livro>? livros;
     private string _searchString = string.Empty; // Inicializado para evitar erro de nulo na busca

     // Função executada quando a página carrega
     protected override async Task OnInitializedAsync()
     {
         try 
         {
             // Chama a API para pegar os dados
             livros = await Http.GetFromJsonAsync<List<Livro>>("api/livros");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Erro ao buscar livros: {ex.Message}");
         }
     }

     // Lógica da Barra de Busca (Filtra por Título ou Autor)
     private Func<Livro, bool> _quickFilter => x =>
     {
         if (string.IsNullOrWhiteSpace(_searchString))
             return true;

         if (x.Titulo.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
             return true;

         if (x.Autor.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
             return true;

         return false;
     };
 }
 ```

 ### 4. Conectando as Pontas (Ajuste de Porta)

 Agora precisamos garantir que o Frontend sabe onde o Backend está rodando.

 1.  **Rode a API:** Abra um terminal em `src/LivrariaCentral.API` e digite `dotnet run`.
 2.  **Verifique a Porta:** Olhe no terminal qual endereço apareceu (ex: `http://localhost:5123`).
 3.  **Atualize o Frontend:**
     Abra o arquivo `src/LivrariaCentral.Web/wwwroot/appsettings.json` e atualize a URL com a porta correta:

     ```json
     {
       "ApiUrl": "http://localhost:5123" 
     }
     ```
     *(Substitua 5123 pela porta que apareceu no seu terminal)*

 ### 5. Rodando o Ecossistema Completo

 > **💡 Conceito Importante:**
 > A partir de agora, nossa aplicação funciona como um sistema conectado.
 > Sempre que você for testar, você precisará de **dois terminais abertos**:
 > 1. Um rodando a **API** (Backend).
 > 2. Outro rodando a **WEB** (Frontend).

 **Teste Final:**
 1.  Com a API rodando, abra um **novo terminal** na pasta `src/LivrariaCentral.Web`.
 2.  Rode `dotnet run`.
 3.  Acesse o site, clique no menu **Livros** e veja a mágica: a tabela carregará os dados vindos direto do PostgreSQL!

 ## 🚀 Sessão 8: Finalizando o CRUD (Dialogs e Ações)

 Vamos implementar as funcionalidades de **Adicionar**, **Editar** e **Excluir** livros na aba "Livros".

 > **🧠 Conceito: UX em SPAs**
 > Em aplicações modernas, evitamos navegar para uma página nova apenas para preencher um formulário pequeno. Usamos **Dialogs** (Janelas Modais/Pop-ups) para manter o usuário no contexto da lista.

 ### 1. Criando o Componente de Formulário (Modal)

 Este arquivo será a "janelinha" que abre sobre a tela para preencher os dados do livro.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Pages/LivroDialog.razor`

 ```razor
 @using LivrariaCentral.Web.Models
 @using MudBlazor

 <MudDialog>
     <DialogContent>
         <MudTextField @bind-Value="Livro.Titulo" Label="Título" />
         <MudTextField @bind-Value="Livro.Autor" Label="Autor" />
         <MudNumericField @bind-Value="Livro.Preco" Label="Preço" Format="N2" />
         <MudNumericField @bind-Value="Livro.Estoque" Label="Estoque" />
     </DialogContent>
     <DialogActions>
         <MudButton OnClick="Cancel">Cancelar</MudButton>
         <MudButton Color="Color.Primary" Variant="Variant.Filled" OnClick="Submit">Salvar</MudButton>
     </DialogActions>
 </MudDialog>

 @code {
     [CascadingParameter] 
     MudDialogInstance MudDialog { get; set; } = default!;

     [Parameter] public Livro Livro { get; set; } = new Livro();

     void Submit() => MudDialog.Close(DialogResult.Ok(Livro));
     void Cancel() => MudDialog.Cancel();
 }
 ```

 ### 2. Atualizando a Listagem (Livros.razor)

 Agora vamos voltar na página de listagem e fazer os botões funcionarem, conectando o Dialog com a API.

 **Substitua TODO o conteúdo do arquivo:** `src/LivrariaCentral.Web/Pages/Livros.razor`

 ```razor
 @page "/livros"
 @using LivrariaCentral.Web.Models
 @inject HttpClient Http
 @inject IDialogService DialogService
 @inject ISnackbar Snackbar

 <MudText Typo="Typo.h4" Class="mb-4">Gerenciar Livros</MudText>

 <MudButton Variant="Variant.Filled" StartIcon="@Icons.Material.Filled.Add" Color="Color.Primary" Class="mb-4" OnClick="AdicionarLivro">
     Novo Livro
 </MudButton>

 @if (livros == null)
 {
     <MudProgressCircular Color="Color.Primary" Indeterminate="true" />
 }
 else
 {
     <MudDataGrid Items="@livros" Filterable="true" SortMode="SortMode.Multiple" QuickFilter="@_quickFilter">
         <ToolBarContent>
             <MudText Typo="Typo.h6">Lista de Livros</MudText>
             <MudSpacer />
             <MudTextField @bind-Value="_searchString" Placeholder="Buscar..." Adornment="Adornment.Start" Immediate="true"
                           AdornmentIcon="@Icons.Material.Filled.Search" IconSize="Size.Medium" Class="mt-0"></MudTextField>
         </ToolBarContent>
         
         <Columns>
             <PropertyColumn Property="x => x.Id" Title="#" Sortable="true" Filterable="false" />
             <PropertyColumn Property="x => x.Titulo" Sortable="true" />
             <PropertyColumn Property="x => x.Autor" Sortable="true" />
             <PropertyColumn Property="x => x.Estoque" Title="Qtd." />
             <PropertyColumn Property="x => x.Preco" Title="Preço" Format="C" />
             
             <TemplateColumn CellClass="d-flex justify-end">
                 <CellTemplate>
                     <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.Edit" Color="@Color.Primary" OnClick="@(() => EditarLivro(context.Item))" />
                     <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.Delete" Color="@Color.Error" OnClick="@(() => DeletarLivro(context.Item))" />
                 </CellTemplate>
             </TemplateColumn>
         </Columns>
         
         <PagerContent>
             <MudDataGridPager T="Livro" />
         </PagerContent>
     </MudDataGrid>
 }

 @code {
     private List<Livro>? livros;
     private string _searchString = string.Empty;

     protected override async Task OnInitializedAsync()
     {
         await CarregarLivros();
     }

     private async Task CarregarLivros()
     {
         livros = await Http.GetFromJsonAsync<List<Livro>>("api/livros");
     }

     // --- Lógica de ADICIONAR ---
     private async Task AdicionarLivro()
     {
         var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
         
         var dialog = await DialogService.ShowAsync<LivroDialog>("Novo Livro", options);
         
         // Aguarda o usuário clicar em Salvar ou Cancelar
         var result = await dialog.Result;

         if (result != null && !result.Canceled && result.Data != null)
         {
             var novoLivro = (Livro)result.Data;
             await Http.PostAsJsonAsync("api/livros", novoLivro);
             Snackbar.Add("Livro cadastrado!", Severity.Success);
             await CarregarLivros();
         }
     }

     // --- Lógica de EDITAR ---
     private async Task EditarLivro(Livro livro)
     {
         var parameters = new DialogParameters { ["Livro"] = livro };
         var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
         
         var dialog = await DialogService.ShowAsync<LivroDialog>("Editar Livro", parameters, options);
         var result = await dialog.Result;

         if (result != null && !result.Canceled && result.Data != null)
         {
             var livroEditado = (Livro)result.Data;
             
             // Atualiza no Backend
             await Http.PutAsJsonAsync($"api/livros/{livroEditado.Id}", livroEditado);
             
             Snackbar.Add("Livro atualizado!", Severity.Success);
             await CarregarLivros();
         }
     }

     // --- Lógica de DELETAR ---
     private async Task DeletarLivro(Livro livro)
     {
         bool? result = await DialogService.ShowMessageBox(
             "Atenção", 
             $"Deseja excluir o livro '{livro.Titulo}'?", 
             yesText: "Excluir", cancelText: "Cancelar");

         if (result == true)
         {
             await Http.DeleteAsync($"api/livros/{livro.Id}");
             Snackbar.Add("Livro excluído.", Severity.Error);
             await CarregarLivros();
         }
     }

     // --- Filtro da Tabela ---
     private Func<Livro, bool> _quickFilter => x =>
     {
         if (string.IsNullOrWhiteSpace(_searchString)) return true;
         if (x.Titulo.Contains(_searchString, StringComparison.OrdinalIgnoreCase)) return true;
         if (x.Autor.Contains(_searchString, StringComparison.OrdinalIgnoreCase)) return true;
         return false;
     };
 }
 ```

 ### 3. Teste Completo

 Rode a aplicação (API + Frontend) e realize o ciclo completo:

 1.  Clique em **"Novo Livro"**, preencha os dados e salve. Veja ele aparecer na tabela.
 2.  Clique no ícone de **Lápis (Editar)**, mude o preço e salve.
 3.  Clique no ícone de **Lixeira (Excluir)** e confirme a exclusão.

 Agora seu sistema é um software funcional capaz de gerenciar dados reais! 🎉

  ## 🚀 Sessão 9: Dashboard com Dados Reais

 Chega de dados falsos! Vamos substituir os números "chumbados" do Dashboard por cálculos reais vindos do banco de dados.

 ### 1. Criando a Rota de Dashboard na API

 Vamos criar um Controller novo focado apenas em estatísticas.

 **Crie o arquivo:** `src/LivrariaCentral.API/Controllers/DashboardController.cs`

 ```csharp
 using LivrariaCentral.API.Data;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;

 namespace LivrariaCentral.API.Controllers;

 [ApiController]
 [Route("api/dashboard")]
 public class DashboardController : ControllerBase
 {
     private readonly AppDbContext _context;

     public DashboardController(AppDbContext context)
     {
         _context = context;
     }

     [HttpGet("resumo")]
     public async Task<IActionResult> GetResumo()
     {
         // O Banco de Dados faz as contas (muito mais rápido que trazer tudo para o C# somar)
         var totalLivros = await _context.Livros.CountAsync();
         var valorEstoque = await _context.Livros.SumAsync(l => l.Preco * l.Estoque);
         var estoqueBaixo = await _context.Livros.CountAsync(l => l.Estoque < 5);
         
         // Retorna um objeto anônimo (JSON) com os dados calculados
         return Ok(new 
         {
             TotalLivros = totalLivros,
             ValorEstoque = valorEstoque,
             EstoqueBaixo = estoqueBaixo,
             // VendasHoje = 0 (Deixaremos zerado até implementarmos a tabela de Vendas)
         });
     }
 }
 ```

 ### 2. Criando o Modelo no Frontend

 O site precisa de uma classe (DTO) para entender o JSON que a API vai mandar.

 > **🧠 Conceito: DTO (Data Transfer Object)**
 > É uma classe simples usada apenas para transportar dados. Diferente das Entidades (Livro), ela não tem regras de negócio e não vira tabela no banco.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Models/DashboardDados.cs`

 ```csharp
 namespace LivrariaCentral.Web.Models;

 public class DashboardDados
 {
     public int TotalLivros { get; set; }
     public decimal ValorEstoque { get; set; }
     public int EstoqueBaixo { get; set; }
 }
 ```

 ### 3. Conectando a Home aos Dados Reais

 Agora vamos editar a página inicial para buscar esses números na API assim que a tela abrir.

 **Substitua TODO o conteúdo do arquivo:** `src/LivrariaCentral.Web/Pages/Home.razor`

 ```razor
 @page "/"
 @using LivrariaCentral.Web.Models
 @inject HttpClient Http

 <MudText Typo="Typo.h4" Class="mb-4">Dashboard</MudText>

 @if (dados == null)
 {
     <div class="d-flex justify-center align-center" style="height: 400px;">
         <MudProgressCircular Color="Color.Primary" Size="Size.Large" Indeterminate="true" />
     </div>
 }
 else
 {
     <MudGrid>
                  <MudItem xs="12" sm="6" md="3">
             <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
                 <MudIcon Icon="@Icons.Material.Filled.LibraryBooks" Color="Color.Primary" Class="mx-4" Style="width:54px; height:54px;" />
                 <div>
                     <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Total Livros</MudText>
                     <MudText Typo="Typo.h5">@dados.TotalLivros</MudText>
                 </div>
             </MudPaper>
         </MudItem>

                  <MudItem xs="12" sm="6" md="3">
             <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
                 <MudIcon Icon="@Icons.Material.Filled.AttachMoney" Color="Color.Success" Class="mx-4" Style="width:54px; height:54px;" />
                 <div>
                     <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Valor em Estoque</MudText>
                     <MudText Typo="Typo.h5">@dados.ValorEstoque.ToString("C")</MudText>
                 </div>
             </MudPaper>
         </MudItem>

                  <MudItem xs="12" sm="6" md="3">
             <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
                 <MudIcon Icon="@Icons.Material.Filled.Warning" Color="Color.Warning" Class="mx-4" Style="width:54px; height:54px;" />
                 <div>
                     <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Estoque Baixo</MudText>
                     <MudText Typo="Typo.h5">@dados.EstoqueBaixo</MudText>
                 </div>
             </MudPaper>
         </MudItem>

                  <MudItem xs="12" sm="6" md="3">
             <MudPaper Class="d-flex flex-row pt-6 pb-4" Style="height:100px;">
                 <MudIcon Icon="@Icons.Material.Filled.People" Color="Color.Info" Class="mx-4" Style="width:54px; height:54px;" />
                 <div>
                     <MudText Typo="Typo.subtitle1" Class="mud-text-secondary mb-n1">Clientes</MudText>
                     <MudText Typo="Typo.h5">120</MudText>
                 </div>
             </MudPaper>
         </MudItem>

         <MudItem xs="12" md="8">
             <MudPaper Class="pa-4">
                 <MudText Typo="Typo.h6">Tendência de Vendas (Simulado)</MudText>
                 <MudChart ChartType="ChartType.Bar" ChartSeries="@Series" XAxisLabels="@XAxisLabels" Width="100%" Height="350px"></MudChart>
             </MudPaper>
         </MudItem>

         <MudItem xs="12" md="4">
             <MudPaper Class="pa-4">
                 <MudText Typo="Typo.h6">Categorias (Simulado)</MudText>
                 <MudChart ChartType="ChartType.Donut" InputData="@DonutData" InputLabels="@DonutLabels" Width="100%" Height="300px" />
             </MudPaper>
         </MudItem>
     </MudGrid>
 }

 @code {
     private DashboardDados? dados;

     // Carrega os dados reais ao abrir a página
     protected override async Task OnInitializedAsync()
     {
         try 
         {
             // Bate na API nova que criamos
             dados = await Http.GetFromJsonAsync<DashboardDados>("api/dashboard/resumo");
         }
         catch(Exception ex)
         {
             Console.WriteLine("Erro ao carregar dashboard: " + ex.Message);
         }
     }

     // --- Dados dos Gráficos (Ainda Fictícios para visual) ---
     public List<ChartSeries> Series = new List<ChartSeries>()
     {
         new ChartSeries() { Name = "Vendas (R$)", Data = new double[] { 4000, 2000, 8000, 15000, 6000, 9000 } }
     };
     public string[] XAxisLabels = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun" };
     public double[] DonutData = { 25, 45, 10, 20 };
     public string[] DonutLabels = { "Ficção", "Técnico", "Romance", "HQs" };
 }
 ```

 ### 4. Teste em Tempo Real

 1.  Garanta que a **API** e o **Web** estejam rodando.
 2.  Abra o site (`localhost`). Veja os números nos cartões.
 3.  Vá na aba **Livros** e cadastre um livro novo com preço alto (ex: R$ 1000,00) e estoque 20.
 4.  Volte para a **Dashboard** (Home).

 **Resultado:** O card "Valor em Estoque" deve ter subido R$ 20.000,00 automaticamente! Isso prova que o Frontend está lendo o banco de dados em tempo real.

  ## 🚀 Sessão 10: Registrando Vendas (Regra de Negócio Real)

 Agora a brincadeira fica séria. Vamos implementar a principal funcionalidade do sistema: **A Venda**.

 > **🧠 Conceito: Transação e Atomicidade**
 > Uma venda não é apenas salvar um registro. Ela envolve **regras de negócio**:
 > 1. Verificar se existe estoque.
 > 2. Calcular o valor total (Preço x Quantidade).
 > 3. **Baixar o estoque** do produto.
 > 4. Registrar a venda.
 > Tudo isso deve acontecer junto. Se uma parte falhar, nada deve ser salvo.

 ### 1. O Modelo de Venda (Backend)

 Precisamos criar uma tabela para guardar o histórico de vendas.

 **Crie o arquivo:** `src/LivrariaCentral.API/Models/Venda.cs`

 ```csharp
 namespace LivrariaCentral.API.Models;

 public class Venda
 {
     public int Id { get; set; }
     public int LivroId { get; set; } // Referência: Qual livro foi vendido
     public int Quantidade { get; set; }
     public decimal ValorTotal { get; set; }
     public DateTime DataVenda { get; set; } = DateTime.UtcNow;
 }
 ```

 ### 2. Atualizando o Banco de Dados (AppDbContext)

 Avise o Entity Framework que existe uma nova tabela.

 **Abra o arquivo:** `src/LivrariaCentral.API/Data/AppDbContext.cs`
 **Adicione a linha da tabela Vendas:**

 ```csharp
 // ... imports
 public class AppDbContext : DbContext
 {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     public DbSet<Livro> Livros { get; set; }
     public DbSet<Venda> Vendas { get; set; } // <--- ADICIONE ESTA LINHA
 }
 ```

 ### 3. Rodando a Migration

 Vamos criar essa tabela no PostgreSQL.

 **No terminal (`src/LivrariaCentral.API`), execute:**

 ```bash
 dotnet ef migrations add CriandoVendas
 dotnet ef database update
 ```

 ### 4. A Lógica da Venda (Controller)

 Aqui está a mágica. O Endpoint não vai só salvar, ele vai checar o estoque e diminuir a quantidade **antes** de confirmar a venda.

 **Crie o arquivo:** `src/LivrariaCentral.API/Controllers/VendasController.cs`

 ```csharp
 using LivrariaCentral.API.Data;
 using LivrariaCentral.API.Models;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;

 namespace LivrariaCentral.API.Controllers;

 [ApiController]
 [Route("api/vendas")]
 public class VendasController : ControllerBase
 {
     private readonly AppDbContext _context;

     public VendasController(AppDbContext context)
     {
         _context = context;
     }

     [HttpPost]
     public async Task<IActionResult> RealizarVenda([FromBody] Venda novaVenda)
     {
         // 1. Busca o livro no banco
         var livro = await _context.Livros.FindAsync(novaVenda.LivroId);
         
         if (livro == null) return NotFound("Livro não encontrado.");

         // 2. Valida se tem estoque suficiente
         if (livro.Estoque < novaVenda.Quantidade)
         {
             return BadRequest($"Estoque insuficiente. Restam apenas {livro.Estoque} unidades.");
         }

         // 3. Cria o registro da venda (Calcula valor no servidor por segurança e não confia no front)
         novaVenda.ValorTotal = livro.Preco * novaVenda.Quantidade;
         novaVenda.DataVenda = DateTime.UtcNow;
         
         _context.Vendas.Add(novaVenda);

         // 4. ATUALIZA O ESTOQUE DO LIVRO (Baixa automática)
         livro.Estoque -= novaVenda.Quantidade;
         
         // 5. Salva tudo numa única transação (Venda + Baixa de Estoque)
         await _context.SaveChangesAsync();

         return Ok(new { mensagem = "Venda realizada com sucesso!", novoEstoque = livro.Estoque });
     }
 }
 ```

 ### 5. O Modal de Venda (Frontend)

 Vamos criar uma janelinha simples para digitar a quantidade.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Pages/VendaDialog.razor`

 ```razor
 @using MudBlazor

 <MudDialog>
     <DialogContent>
         <MudText Class="mb-3">Vendendo: <b>@TituloLivro</b></MudText>
         <MudText Class="mb-3">Preço Unitário: <b>@PrecoUnitario.ToString("C")</b></MudText>
         
         <MudNumericField @bind-Value="Quantidade" Label="Quantidade" Variant="Variant.Outlined" Min="1" />
         
         <MudText Color="Color.Success" Typo="Typo.h6" Class="mt-4">
             Total: @((PrecoUnitario * Quantidade).ToString("C"))
         </MudText>
     </DialogContent>
     <DialogActions>
         <MudButton OnClick="Cancel">Cancelar</MudButton>
         <MudButton Color="Color.Success" Variant="Variant.Filled" OnClick="Submit">Confirmar Venda</MudButton>
     </DialogActions>
 </MudDialog>

 @code {
     [CascadingParameter] MudDialogInstance MudDialog { get; set; } = default!;

     [Parameter] public string TituloLivro { get; set; } = "";
     [Parameter] public decimal PrecoUnitario { get; set; }

     public int Quantidade { get; set; } = 1;

     void Submit() => MudDialog.Close(DialogResult.Ok(Quantidade));
     void Cancel() => MudDialog.Cancel();
 }
 ```

 ### 6. Modelo de Transferência (DTO)

 Para enviar a venda do Site para a API, precisamos de uma classezinha auxiliar.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Models/VendaDTO.cs`

 ```csharp
 namespace LivrariaCentral.Web.Models;

 public class VendaDTO
 {
     public int LivroId { get; set; }
     public int Quantidade { get; set; }
 }
 ```

 ### 7. Botão de Venda na Lista

 Agora vamos adicionar o botão de cifrão ($) na tabela de livros e a lógica para chamar a API.

 **Substitua TODO o conteúdo do arquivo:** `src/LivrariaCentral.Web/Pages/Livros.razor`

 ```razor
 @page "/livros"
 @using LivrariaCentral.Web.Models
 @inject HttpClient Http
 @inject IDialogService DialogService
 @inject ISnackbar Snackbar

 <MudText Typo="Typo.h4" Class="mb-4">Gerenciar Livros</MudText>

 <MudButton Variant="Variant.Filled" StartIcon="@Icons.Material.Filled.Add" Color="Color.Primary" Class="mb-4" OnClick="AdicionarLivro">
     Novo Livro
 </MudButton>

 @if (livros == null)
 {
     <MudProgressCircular Color="Color.Primary" Indeterminate="true" />
 }
 else
 {
     <MudDataGrid Items="@livros" Filterable="true" SortMode="SortMode.Multiple" QuickFilter="@_quickFilter">
         <ToolBarContent>
             <MudText Typo="Typo.h6">Lista de Livros</MudText>
             <MudSpacer />
             <MudTextField @bind-Value="_searchString" Placeholder="Buscar..." Adornment="Adornment.Start" Immediate="true"
                           AdornmentIcon="@Icons.Material.Filled.Search" IconSize="Size.Medium" Class="mt-0"></MudTextField>
         </ToolBarContent>
         
         <Columns>
             <PropertyColumn Property="x => x.Id" Title="#" Sortable="true" Filterable="false" />
             <PropertyColumn Property="x => x.Titulo" Sortable="true" />
             <PropertyColumn Property="x => x.Autor" Sortable="true" />
             <PropertyColumn Property="x => x.Estoque" Title="Qtd." />
             <PropertyColumn Property="x => x.Preco" Title="Preço" Format="C" />
             
             <TemplateColumn CellClass="d-flex justify-end">
                 <CellTemplate>
                                          <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.AttachMoney" Color="@Color.Success" OnClick="@(() => RealizarVenda(context.Item))" Title="Vender" />
                     
                     <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.Edit" Color="@Color.Primary" OnClick="@(() => EditarLivro(context.Item))" />
                     <MudIconButton Size="@Size.Small" Icon="@Icons.Material.Filled.Delete" Color="@Color.Error" OnClick="@(() => DeletarLivro(context.Item))" />
                 </CellTemplate>
             </TemplateColumn>
         </Columns>
         
         <PagerContent>
             <MudDataGridPager T="Livro" />
         </PagerContent>
     </MudDataGrid>
 }

 @code {
     private List<Livro>? livros;
     private string _searchString = string.Empty;

     protected override async Task OnInitializedAsync()
     {
         await CarregarLivros();
     }

     private async Task CarregarLivros()
     {
         livros = await Http.GetFromJsonAsync<List<Livro>>("api/livros");
     }

     // --- Lógica de VENDA (Novo) ---
     private async Task RealizarVenda(Livro livro)
     {
         var parameters = new DialogParameters 
         { 
             ["TituloLivro"] = livro.Titulo,
             ["PrecoUnitario"] = livro.Preco 
         };
         
         var dialog = await DialogService.ShowAsync<VendaDialog>("Registrar Venda", parameters);
         var result = await dialog.Result;

         if (result != null && !result.Canceled && result.Data != null)
         {
             int qtdVendida = (int)result.Data;
             var venda = new VendaDTO { LivroId = livro.Id, Quantidade = qtdVendida };

             var response = await Http.PostAsJsonAsync("api/vendas", venda);

             if (response.IsSuccessStatusCode)
             {
                 Snackbar.Add($"Venda realizada!", Severity.Success);
                 await CarregarLivros(); // Atualiza a tabela para ver o estoque baixando
             }
             else
             {
                 var erro = await response.Content.ReadAsStringAsync();
                 Snackbar.Add($"Erro: {erro}", Severity.Error);
             }
         }
     }

     // --- CRUD (Mantido igual) ---
     private async Task AdicionarLivro()
     {
         var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
         var dialog = await DialogService.ShowAsync<LivroDialog>("Novo Livro", options);
         var result = await dialog.Result;

         if (result != null && !result.Canceled && result.Data != null)
         {
             await Http.PostAsJsonAsync("api/livros", result.Data);
             Snackbar.Add("Livro cadastrado!", Severity.Success);
             await CarregarLivros();
         }
     }

     private async Task EditarLivro(Livro livro)
     {
         var parameters = new DialogParameters { ["Livro"] = livro };
         var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
         var dialog = await DialogService.ShowAsync<LivroDialog>("Editar Livro", parameters, options);
         var result = await dialog.Result;

         if (result != null && !result.Canceled && result.Data != null)
         {
             var livroEditado = (Livro)result.Data;
             await Http.PutAsJsonAsync($"api/livros/{livroEditado.Id}", livroEditado);
             Snackbar.Add("Livro atualizado!", Severity.Success);
             await CarregarLivros();
         }
     }

     private async Task DeletarLivro(Livro livro)
     {
         bool? result = await DialogService.ShowMessageBox("Atenção", $"Deseja excluir '{livro.Titulo}'?", yesText: "Excluir", cancelText: "Cancelar");
         if (result == true)
         {
             await Http.DeleteAsync($"api/livros/{livro.Id}");
             Snackbar.Add("Livro excluído.", Severity.Error);
             await CarregarLivros();
         }
     }

     private Func<Livro, bool> _quickFilter => x =>
     {
         if (string.IsNullOrWhiteSpace(_searchString)) return true;
         if (x.Titulo.Contains(_searchString, StringComparison.OrdinalIgnoreCase)) return true;
         if (x.Autor.Contains(_searchString, StringComparison.OrdinalIgnoreCase)) return true;
         return false;
     };
 }
 ```

 ### 8. Teste de Fogo

 1.  Rode a aplicação e vá na aba **Livros**.
 2.  Escolha um livro que tenha estoque (ex: 10 unidades).
 3.  Clique no ícone **$ (Vender)**.
 4.  Venda 2 unidades.

 **✅ Checkpoint de Sucesso:**
 * O modal fecha.
 * Uma mensagem verde aparece: "Venda realizada!".
 * A quantidade na tabela muda automaticamente de 10 para 8.

 **Teste de Erro (Opcional):**
 * Tente vender 100 unidades desse mesmo livro.
 * Uma mensagem vermelha deve aparecer: "Erro: Estoque insuficiente...".

  ## 🚀 Sessão 11: Histórico de Vendas (Consulta e Join)

 Agora que já estamos vendendo, precisamos de um relatório para saber o que foi vendido. Aqui temos um desafio técnico: a tabela de `Vendas` só tem o ID do livro (`LivroId`), mas na tela queremos mostrar o **Título** do livro.

 Para resolver isso, faremos um **Join** (Cruzamento de Tabelas) no Backend.

 > **🧠 Conceito: SQL JOIN no Entity Framework**
 > Imagine que você tem duas planilhas do Excel: "Vendas" e "Livros". O comando `Join` é como um `PROCV` (VLOOKUP) que pega o ID de uma planilha e busca o Nome na outra.

 ### 1. Backend: Preparando a Consulta (VendasController)

 Precisamos de um endpoint que devolva a lista de vendas, mas que já inclua o nome do livro buscado na outra tabela.

 **Abra o arquivo:** `src/LivrariaCentral.API/Controllers/VendasController.cs`
 **Adicione o método `GetVendas`:**

 ```csharp
     // ... (Método RealizarVenda fica acima deste)

     [HttpGet]
     public async Task<IActionResult> GetVendas()
     {
         // Faz a junção (Join) entre Venda e Livro para pegar o Título
         var historico = await _context.Vendas
             .Join(_context.Livros,
                 venda => venda.LivroId,  // Chave na tabela Venda
                 livro => livro.Id,       // Chave na tabela Livro
                 (venda, livro) => new    // O que vamos devolver para o site (Objeto Anônimo)
                 {
                     Id = venda.Id,
                     DataVenda = venda.DataVenda,
                     LivroTitulo = livro.Titulo, // <--- Aqui está a mágica! Pegamos o Título da tabela Livros
                     Quantidade = venda.Quantidade,
                     ValorTotal = venda.ValorTotal
                 })
             .OrderByDescending(v => v.DataVenda) // Mais recentes primeiro
             .ToListAsync();

         return Ok(historico);
     }
 ```

 ### 2. Frontend: Modelo de Dados

 O Frontend precisa de uma classe para receber esses dados combinados (Venda + Nome do Livro). Note que essa classe não existe no banco de dados, ela é exclusiva para exibição.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Models/VendaHistorico.cs`

 ```csharp
 namespace LivrariaCentral.Web.Models;

 public class VendaHistorico
 {
     public int Id { get; set; }
     public DateTime DataVenda { get; set; }
     public string LivroTitulo { get; set; } = string.Empty;
     public int Quantidade { get; set; }
     public decimal ValorTotal { get; set; }
 }
 ```

 ### 3. Frontend: A Tela de Histórico

 Vamos criar a página que exibe a tabela. Como é só leitura (não dá pra editar uma venda passada), o código é bem direto.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Pages/HistoricoVendas.razor`

 ```razor
 @page "/historico"
 @using LivrariaCentral.Web.Models
 @inject HttpClient Http

 <MudText Typo="Typo.h4" Class="mb-4">Histórico de Vendas</MudText>

 @if (vendas == null)
 {
     <MudProgressCircular Color="Color.Primary" Indeterminate="true" />
 }
 else
 {
     <MudDataGrid Items="@vendas" Filterable="true" SortMode="SortMode.Multiple">
         <Columns>
             <PropertyColumn Property="x => x.Id" Title="#" />
             
                          <PropertyColumn Property="x => x.DataVenda" Title="Data">
                 <CellTemplate>
                     @context.Item.DataVenda.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
                 </CellTemplate>
             </PropertyColumn>
             
             <PropertyColumn Property="x => x.LivroTitulo" Title="Livro" />
             <PropertyColumn Property="x => x.Quantidade" Title="Qtd." />
             <PropertyColumn Property="x => x.ValorTotal" Title="Total" Format="C" />
         </Columns>
         
         <PagerContent>
             <MudDataGridPager T="VendaHistorico" />
         </PagerContent>
     </MudDataGrid>
 }

 @code {
     private List<VendaHistorico>? vendas;

     protected override async Task OnInitializedAsync()
     {
         try
         {
             vendas = await Http.GetFromJsonAsync<List<VendaHistorico>>("api/vendas");
         }
         catch (Exception ex)
         {
             Console.WriteLine("Erro ao buscar histórico: " + ex.Message);
         }
     }
 }
 ```

 ### 4. Testando

 1.  Faça algumas vendas na tela de Livros.
 2.  Clique no menu **Histórico**.
 3.  Veja a lista ordenada da venda mais recente para a mais antiga, com o nome do livro correto e o horário ajustado para o seu fuso horário local.

 ## 🚀 Sessão 12: Gerando Relatórios em PDF

 Vamos criar um botão que baixa um PDF profissional com a lista de produtos. Usaremos a biblioteca **QuestPDF**, moderna, performática e que não depende de HTML para desenhar.

 > **🧠 Conceito: Fluent API**
 > O QuestPDF usa uma "Interface Fluente". Isso significa que encadeamos comandos como uma frase: `page.Header().Text("Olá").Bold();`. É muito legível e fácil de manter.

 ### 1. Instalando o QuestPDF na API

 **No terminal (`src/LivrariaCentral.API`), execute:**

 ```bash
 dotnet add package QuestPDF
 ```

 ### 2. Configurando a Licença (Gratuita)

 O QuestPDF exige configuração explícita de licença para funcionar sem marcas d'água ou erros.

 **Abra o arquivo:** `src/LivrariaCentral.API/Program.cs`
 **Adicione no topo:**

 ```csharp
 using QuestPDF.Infrastructure; // <--- Importante

 QuestPDF.Settings.License = LicenseType.Community; // <--- Licença Gratuita para projetos open-source/estudo

 var builder = WebApplication.CreateBuilder(args);
 // ... resto do código
 ```

 ### 3. Criando o Endpoint do Relatório

 Vamos criar um Controller que desenha o PDF e devolve o arquivo binário (stream) para o navegador.

 **Crie o arquivo:** `src/LivrariaCentral.API/Controllers/RelatoriosController.cs`

 ```csharp
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
                     // Definição das colunas (Largura fixa ou relativa)
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
                         // Zebrando e desenhando as bordas
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
         // MemoryStream guarda o PDF na memória RAM temporariamente
         var stream = new MemoryStream();
         pdf.GeneratePdf(stream);
         stream.Position = 0; // Volta o "cursor" para o início do arquivo antes de enviar

         // Devolve o arquivo com o tipo MIME correto (application/pdf)
         return File(stream, "application/pdf", "RelatorioEstoque.pdf");
     }
 }
 ```

 ### 4. Botão de Download no Frontend

 Precisamos usar um pequeno truque de JavaScript (`window.open`) para forçar o navegador a baixar o arquivo, já que o Blazor roda dentro de uma "caixa fechada".

 **Abra o arquivo:** `src/LivrariaCentral.Web/Pages/Livros.razor`

 **1. Adicione a injeção do JS Runtime no topo (junto com os outros @inject):**

 ```razor
 @inject IJSRuntime JS
 ```

 **2. Adicione a função `BaixarRelatorio` no bloco `@code` (pode ser no final):**

 ```csharp
     private async Task BaixarRelatorio()
     {
         // Truque: Pegamos a URL base configurada no HttpClient para não precisar digitar a porta de novo
         var urlBase = Http.BaseAddress?.ToString();
         var urlRelatorio = $"{urlBase}api/relatorios/estoque";
         
         // Abre o PDF em uma nova aba do navegador
         await JS.InvokeVoidAsync("open", urlRelatorio, "_blank");
     }
 ```

 **3. Localize o botão "Novo Livro" e substitua por este bloco:**
 (Isso coloca o botão de imprimir ao lado do de adicionar)

 ```razor
 <div class="d-flex gap-4 mb-4">
     <MudButton Variant="Variant.Filled" StartIcon="@Icons.Material.Filled.Add" Color="Color.Primary" OnClick="AdicionarLivro">
         Novo Livro
     </MudButton>

     <MudButton Variant="Variant.Filled" StartIcon="@Icons.Material.Filled.Print" Color="Color.Secondary" OnClick="BaixarRelatorio">
         Imprimir Estoque
     </MudButton>
 </div>
 ```

 ### 5. Testando

 1.  Rode a API e o Frontend.
 2.  Vá na aba **Livros**.
 3.  Clique no botão cinza **"Imprimir Estoque"**.
 4.  O navegador deve abrir uma nova aba exibindo um PDF perfeitamente formatado com a lista dos seus livros!

  ## 🚀 Sessão 13: Segurança e Autenticação (Backend)

 Vamos implementar **JWT (JSON Web Tokens)**.

 > **🧠 Conceito: Como funciona o Login Moderno?**
 > 1. O usuário envia Email/Senha.
 > 2. A API valida e, se estiver certo, devolve um **Token** (uma string gigante criptografada).
 > 3. O usuário guarda esse Token (crachá).
 > 4. Para criar um livro, o usuário envia o Token no cabeçalho da requisição. A API lê o Token e sabe quem é.

 

 ### 1. Instalando Pacotes de Segurança

 **No terminal (`src/LivrariaCentral.API`), execute:**

 ```bash
 dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
 dotnet add package BCrypt.Net-Next
 ```
 *Nota: O BCrypt serve para transformar a senha "123456" em algo ilegível no banco.*

 ### 2. Criando a Tabela de Usuários

 **Crie o arquivo:** `src/LivrariaCentral.API/Models/Usuario.cs`

 ```csharp
 namespace LivrariaCentral.API.Models;

 public class Usuario
 {
     public int Id { get; set; }
     public string Email { get; set; } = string.Empty;
     public string SenhaHash { get; set; } = string.Empty; // Nunca salvamos senha pura!
     public string Nome { get; set; } = string.Empty;
 }

 // DTO para Login (O que o usuário envia na tela)
 public class UsuarioDTO
 {
     public string Email { get; set; } = string.Empty;
     public string Senha { get; set; } = string.Empty;
 }
 ```

 ### 3. Atualizando o Banco de Dados

 Precisamos avisar o Entity Framework sobre a nova tabela.

 **Abra o arquivo:** `src/LivrariaCentral.API/Data/AppDbContext.cs`

 ```csharp
 using LivrariaCentral.API.Models; // <--- Importante
 // ...
 public class AppDbContext : DbContext
 {
     // ...
     public DbSet<Livro> Livros { get; set; }
     public DbSet<Venda> Vendas { get; set; }
     public DbSet<Usuario> Usuarios { get; set; } // <--- ADICIONE ESTA LINHA
 }
 ```

 Rode as migrations para criar a tabela no PostgreSQL:

 ```bash
 dotnet ef migrations add CriandoUsuarios
 dotnet ef database update
 ```

 ### 4. Configurando o Segredo (Chave do Token)

 Precisamos de uma frase secreta para assinar os tokens. Se alguém descobrir isso, pode criar tokens falsos.

 **Abra o arquivo:** `src/LivrariaCentral.API/appsettings.json`
 **Adicione a seção "Jwt":**

 ```json
 {
   "Jwt": {
      "Key": "MinhaChaveSuperSecretaDeLivraria123!" 
   }
   // ...
 }
 ```

 ### 5. Criando o Controlador de Autenticação

 Aqui vamos criar as rotas para Registrar e Logar.

 **Crie o arquivo:** `src/LivrariaCentral.API/Controllers/AuthController.cs`

 ```csharp
 using System.IdentityModel.Tokens.Jwt;
 using System.Security.Claims;
 using System.Text;
 using LivrariaCentral.API.Data;
 using LivrariaCentral.API.Models;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.IdentityModel.Tokens;

 namespace LivrariaCentral.API.Controllers;

 [Route("api/auth")]
 [ApiController]
 public class AuthController : ControllerBase
 {
     private readonly AppDbContext _context;
     private readonly IConfiguration _configuration;

     public AuthController(AppDbContext context, IConfiguration configuration)
     {
         _context = context;
         _configuration = configuration;
     }

     [HttpPost("registrar")]
     public async Task<IActionResult> Registrar(UsuarioDTO request)
     {
         // Criptografa a senha antes de salvar
         string senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

         var novoUsuario = new Usuario
         {
             Email = request.Email,
             SenhaHash = senhaHash,
             Nome = "Administrador"
         };

         _context.Usuarios.Add(novoUsuario);
         await _context.SaveChangesAsync();

         return Ok("Usuário criado com sucesso!");
     }

     [HttpPost("login")]
     public async Task<IActionResult> Login(UsuarioDTO request)
     {
         var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
         
         // Verifica se o usuário existe E se a senha bate com o hash
         if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
         {
             return BadRequest("Email ou senha inválidos.");
         }

         // Se passou, gera o token
         string token = GerarToken(usuario);
         return Ok(new { token = token });
     }

     private string GerarToken(Usuario usuario)
     {
         var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
         
         // Claims são os dados que vão DENTRO do token (ex: Id, Email)
         var claims = new List<Claim>
         {
             new Claim(ClaimTypes.Name, usuario.Email),
             new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
         };

         var tokenDescriptor = new SecurityTokenDescriptor
         {
             Subject = new ClaimsIdentity(claims),
             Expires = DateTime.UtcNow.AddHours(8), // Token expira em 8 horas
             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
         };

         var tokenHandler = new JwtSecurityTokenHandler();
         var token = tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
     }
 }
 ```

 ### 6. Blindando a API (Program.cs)

 Agora vamos avisar o .NET que ele deve usar JWT e proteger as rotas.

 **Substitua TODO o conteúdo do arquivo:** `src/LivrariaCentral.API/Program.cs`

 ```csharp
 using LivrariaCentral.API.Data;
 using Microsoft.EntityFrameworkCore;
 using QuestPDF.Infrastructure;
 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
 using System.Text;

 QuestPDF.Settings.License = LicenseType.Community;

 var builder = WebApplication.CreateBuilder(args);

 // --- CONFIGURAÇÃO DO BANCO ---
 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(connectionString));

 builder.Services.AddControllers();
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();

 // --- CONFIGURAÇÃO DO CORS ---
 builder.Services.AddCors(options =>
 {
     options.AddPolicy("AllowAll",
         policy =>
         {
             policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
         });
 });

 // --- CONFIGURAÇÃO DO JWT ---
 var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);

 builder.Services.AddAuthentication(x =>
 {
     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 })
 .AddJwtBearer(x =>
 {
     x.RequireHttpsMetadata = false;
     x.SaveToken = true;
     x.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(key),
         ValidateIssuer = false,
         ValidateAudience = false
     };
 });

 var app = builder.Build();

 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger();
     app.UseSwaggerUI();
 }

 app.UseHttpsRedirection();
 app.UseCors("AllowAll");

 // ATENÇÃO: A ordem aqui importa muito!
 app.UseAuthentication(); // <--- Quem é você? (Verifica Token)
 app.UseAuthorization();  // <--- Você pode entrar? (Verifica Permissão)

 app.MapControllers();

 app.Run();
 ```

 ### 7. Criando o Primeiro Usuário (Admin)

 Como não temos tela de cadastro no site, vamos criar o primeiro usuário via Swagger.

 1.  Rode a API (`dotnet run`).
 2.  Acesse o Swagger (`http://localhost:xxxx/swagger`).
 3.  Abra a rota **POST /api/auth/registrar**.
 4.  Clique em **Try it out** e envie:
     ```json
     {
       "email": "admin@livraria.com",
       "senha": "admin"
     }
     ```
 5.  Clique em **Execute**. Se der 200 OK, parabéns! Guarde essa senha.

 ## 🚀 Sessão 14: Login no Frontend (O Porteiro do Site)

 Vamos criar a tela de login, ensinar o Blazor a lembrar quem está logado (mesmo se fechar o navegador) e proteger as páginas restritas.

 > **🧠 Conceito: Autenticação no Blazor**
 > O Blazor não sabe "quem é você" nativamente. Precisamos criar um **Provedor de Estado** que olha para o `LocalStorage` (o "bolso" do navegador), vê se tem um Token lá e avisa o resto do site: "Ei, o usuário está logado!".

 ### 1. Instalando o LocalStorage

 Precisamos de uma biblioteca para guardar o Token no navegador.

 **No terminal (`src/LivrariaCentral.Web`), execute:**

 ```bash
 dotnet add package Blazored.LocalStorage
 dotnet add package Microsoft.AspNetCore.Components.Authorization
 ```

 ### 2. Configurando as Importações Globais

 **Abra:** `src/LivrariaCentral.Web/_Imports.razor`
 **Adicione:**

 ```razor
 @using Microsoft.AspNetCore.Components.Authorization
 @using Microsoft.AspNetCore.Authorization
 @using Blazored.LocalStorage
 @using System.Text.Json
 @using System.Globalization
 ```

 ### 3. O Provedor de Autenticação (O Cérebro)

 Esta classe é a peça chave. Ela traduz o Token JWT para algo que o Blazor entende.

 **Crie o arquivo:** `src/LivrariaCentral.Web/Auth/CustomAuthStateProvider.cs`

 ```csharp
 using System.Net.Http.Headers;
 using System.Security.Claims;
 using System.Text.Json;
 using Blazored.LocalStorage;
 using Microsoft.AspNetCore.Components.Authorization;

 namespace LivrariaCentral.Web.Auth;

 public class CustomAuthStateProvider : AuthenticationStateProvider
 {
     private readonly ILocalStorageService _localStorage;
     private readonly HttpClient _http;

     public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
     {
         _localStorage = localStorage;
         _http = http;
     }

     public override async Task<AuthenticationState> GetAuthenticationStateAsync()
     {
         // 1. Tenta pegar o token do navegador
         string token = await _localStorage.GetItemAsStringAsync("authToken");

         var identity = new ClaimsIdentity();
         _http.DefaultRequestHeaders.Authorization = null;

         if (!string.IsNullOrEmpty(token))
         {
             try
             {
                 // 2. Lê o token e extrai os dados (Claims)
                 identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt", "unique_name", "role");
                 
                 // 3. Adiciona o token no cabeçalho de todas as requisições futuras
                 _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
             }
             catch
             {
                 await _localStorage.RemoveItemAsync("authToken");
             }
         }

         // 4. Retorna o estado (Logado ou Não Logado) para o Blazor
         var user = new ClaimsPrincipal(identity);
         var state = new AuthenticationState(user);

         NotifyAuthenticationStateChanged(Task.FromResult(state));
         return state;
     }

     public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
     {
         // Lógica para decodificar o Base64 do JWT
         var payload = jwt.Split('.')[1];
         var jsonBytes = ParseBase64WithoutPadding(payload);
         var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
         
         return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? string.Empty));
     }

     private static byte[] ParseBase64WithoutPadding(string base64)
     {
         switch (base64.Length % 4)
         {
             case 2: base64 += "=="; break;
             case 3: base64 += "="; break;
         }
         return Convert.FromBase64String(base64);
     }
 }
 ```

 ### 4. Configurando o Program.cs (Web)

 Vamos registrar nosso provedor customizado.

 **Substitua TODO o arquivo:** `src/LivrariaCentral.Web/Program.cs`

 ```csharp
 using Microsoft.AspNetCore.Components.Web;
 using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
 using LivrariaCentral.Web;
 using MudBlazor.Services;
 using Blazored.LocalStorage;
 using LivrariaCentral.Web.Auth;
 using Microsoft.AspNetCore.Components.Authorization;
 using System.Globalization;

 // 1. CORREÇÃO DE CULTURA (Crucial para o MudBlazor não travar com números)
 var culture = new CultureInfo("pt-BR");
 culture.NumberFormat.NumberDecimalSeparator = ".";
 CultureInfo.DefaultThreadCurrentCulture = culture;
 CultureInfo.DefaultThreadCurrentUICulture = culture;

 var builder = WebAssemblyHostBuilder.CreateDefault(args);
 builder.RootComponents.Add<App>("#app");
 builder.RootComponents.Add<HeadOutlet>("head::after");

 // 2. LER CONFIGURAÇÃO DA API (appsettings.json)
 var apiUrl = builder.Configuration.GetValue<string>("ApiUrl") ?? "http://localhost:5000";
 builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

 // 3. SERVIÇOS
 builder.Services.AddMudServices();
 builder.Services.AddBlazoredLocalStorage();
 builder.Services.AddAuthorizationCore();
 // Registra nosso provedor customizado
 builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

 await builder.Build().RunAsync();
 ```

 ### 5. A Tela de Login

 **Crie o arquivo:** `src/LivrariaCentral.Web/Pages/Login.razor`

 ```razor
 @page "/login"
 @inject HttpClient Http
 @inject ILocalStorageService LocalStorage
 @inject AuthenticationStateProvider AuthStateProvider
 @inject NavigationManager Nav
 @inject ISnackbar Snackbar

 <MudContainer MaxWidth="MaxWidth.Small" Class="mt-16">
     <MudPaper Class="pa-8" Elevation="3">
         <MudText Typo="Typo.h4" Align="Align.Center" Class="mb-4">🔐 Login</MudText>
         
         <MudTextField @bind-Value="email" Label="Email" Variant="Variant.Outlined" Class="mb-3" />
         <MudTextField @bind-Value="senha" Label="Senha" Variant="Variant.Outlined" InputType="InputType.Password" Class="mb-4" />
         
         <MudButton Variant="Variant.Filled" Color="Color.Primary" FullWidth="true" OnClick="FazerLogin">Entrar</MudButton>
     </MudPaper>
 </MudContainer>

 @code {
     string email = "";
     string senha = "";

     async Task FazerLogin()
     {
         var loginModel = new { Email = email, Senha = senha };
         var response = await Http.PostAsJsonAsync("api/auth/login", loginModel);

         if (response.IsSuccessStatusCode)
         {
             var resultado = await response.Content.ReadFromJsonAsync<JsonElement>();
             string token = resultado.GetProperty("token").GetString()!;

             // Salva o token e avisa o sistema que o usuário logou
             await LocalStorage.SetItemAsStringAsync("authToken", token);
             await AuthStateProvider.GetAuthenticationStateAsync();
             Nav.NavigateTo("/");
         }
         else
         {
             Snackbar.Add("Email ou senha inválidos!", Severity.Error);
         }
     }
 }
 ```

 ### 6. Protegendo o App (App.razor)

 Envolvemos todo o site com o componente `<CascadingAuthenticationState>`, que propaga a informação de login para todos os cantos.

 **Substitua TODO o arquivo:** `src/LivrariaCentral.Web/App.razor`

 ```razor
 <CascadingAuthenticationState>
     <Router AppAssembly="@typeof(App).Assembly">
         <Found Context="routeData">
             <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)">
                 <NotAuthorized>
                                          <div class="d-flex flex-column align-center justify-center pa-8" style="height: 80vh">
                         <MudIcon Icon="@Icons.Material.Filled.Lock" Size="Size.Large" Color="Color.Warning" Class="mb-4" />
                         <MudText Typo="Typo.h4" Class="mb-2">Acesso Restrito</MudText>
                         <MudText Class="mb-6">Você precisa estar logado para acessar esta página.</MudText>
                         
                         <MudButton Variant="Variant.Filled" Color="Color.Primary" Href="/login" Size="Size.Large" StartIcon="@Icons.Material.Filled.Login">
                             Ir para o Login
                         </MudButton>
                     </div>
                 </NotAuthorized>
             </AuthorizeRouteView>
         </Found>
         <NotFound>
             <PageTitle>Não Encontrado</PageTitle>
             <LayoutView Layout="@typeof(MainLayout)">
                 <p role="alert">Ops, essa página não existe.</p>
             </LayoutView>
         </NotFound>
     </Router>
 </CascadingAuthenticationState>
 ```

 ### 7. Atualizando o Menu (MainLayout.razor)

 Vamos usar o componente `<AuthorizeView>` para mostrar conteúdo diferente dependendo se o usuário está logado ou não.

 **Substitua TODO o arquivo:** `src/LivrariaCentral.Web/Layout/MainLayout.razor`

 ```razor
 @inherits LayoutComponentBase
 @inject Blazored.LocalStorage.ILocalStorageService LocalStorage
 @inject AuthenticationStateProvider AuthStateProvider
 @inject NavigationManager Nav

 <MudThemeProvider />
 <MudPopoverProvider />
 <MudDialogProvider />
 <MudSnackbarProvider />

 <MudLayout>
     <MudAppBar Elevation="1">
         <MudIconButton Icon="@Icons.Material.Filled.Menu" Color="Color.Inherit" Edge="Edge.Start" OnClick="@((e) => DrawerToggle())" />
         <MudText Typo="Typo.h6" Class="ml-3">Livraria Central</MudText>
         <MudSpacer />
         
         <AuthorizeView>
             <Authorized>
                 <MudText Class="mr-4">Olá @context.User.Identity?.Name</MudText>
                 <MudButton Variant="Variant.Filled" Color="Color.Secondary" OnClick="Logout">Sair</MudButton>
             </Authorized>
             <NotAuthorized>
                 <MudButton Variant="Variant.Filled" Color="Color.Success" Href="/login">Entrar</MudButton>
             </NotAuthorized>
         </AuthorizeView>
     </MudAppBar>

     <MudDrawer @bind-Open="_drawerOpen" ClipMode="DrawerClipMode.Always" Elevation="2">
         <MudNavMenu>
                          <MudNavLink Href="/" Match="NavLinkMatch.All" Icon="@Icons.Material.Filled.Dashboard">Dashboard</MudNavLink>
             <MudNavLink Href="/livros" Icon="@Icons.Material.Filled.LibraryBooks">Livros</MudNavLink>
             <MudNavLink Href="/historico" Match="NavLinkMatch.Prefix" Icon="@Icons.Material.Filled.History">Histórico</MudNavLink>
         </MudNavMenu>
     </MudDrawer>

     <MudMainContent>
         <MudContainer MaxWidth="MaxWidth.Large" Class="mt-4">
             @Body
         </MudContainer>
     </MudMainContent>
 </MudLayout>

 @code {
     bool _drawerOpen = true;

     void DrawerToggle()
     {
         _drawerOpen = !_drawerOpen;
     }

     async Task Logout()
     {
         await LocalStorage.RemoveItemAsync("authToken");
         await AuthStateProvider.GetAuthenticationStateAsync();
         Nav.NavigateTo("/login");
     }
 }
 ```

 ### 8. Trancando as Portas (Authorize)

 Agora que temos o sistema de chaves, vamos colocar cadeados nas páginas. Adicione o atributo `[Authorize]` no topo das páginas que você quer proteger.

 **Abra:** `src/LivrariaCentral.Web/Pages/Livros.razor`
 **Abra:** `src/LivrariaCentral.Web/Pages/Home.razor`
 **Abra:** `src/LivrariaCentral.Web/Pages/HistoricoVendas.razor`

 **Adicione na linha 2:**

 ```razor
 @page "/..."
 @attribute [Authorize] // <--- ADICIONE ISSO AQUI
 ```

  ## 🚀 Sessão 15: Logs e Monitoramento (A Caixa Preta)

 Vamos usar o **Serilog** para criar um arquivo diário com o histórico de tudo que acontece no sistema. Isso é vital para descobrir por que um erro aconteceu quando você não estava olhando.

 > **🧠 Conceito: Structured Logging**
 > Diferente de um `Console.WriteLine` simples, o Serilog grava dados estruturados. Isso permite que, no futuro, você pesquise logs filtrando por propriedades, como: `Find where UserName == "admin"`.

 ### 1. Instalando o Serilog

 **No terminal (`src/LivrariaCentral.API`), execute:**

 ```bash
 dotnet add package Serilog.AspNetCore
 dotnet add package Serilog.Sinks.File
 ```

 ### 2. Configurando a "Caixa Preta" (Program.cs)

 Vamos blindar a inicialização da API. Usaremos um bloco `try/catch` global para garantir que, se o banco de dados falhar ao ligar, o erro seja registrado antes da aplicação morrer.

 **Substitua TODO o conteúdo do arquivo:** `src/LivrariaCentral.API/Program.cs`

 ```csharp
 using LivrariaCentral.API.Data;
 using Microsoft.EntityFrameworkCore;
 using QuestPDF.Infrastructure;
 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
 using System.Text;
 using Serilog; // <--- Importante

 QuestPDF.Settings.License = LicenseType.Community;

 // 1. Configuração Inicial (Bootstrap Logger)
 // Garante que erros na inicialização sejam pegos antes mesmo do app subir completamente
 Log.Logger = new LoggerConfiguration()
     .WriteTo.Console()
     .CreateBootstrapLogger();

 try 
 {
     Log.Information("Iniciando a API Livraria Central...");
     
     var builder = WebApplication.CreateBuilder(args);

     // 2. Conecta o Serilog no Host (Substitui o log padrão do .NET)
     builder.Host.UseSerilog((context, configuration) => configuration
         .ReadFrom.Configuration(context.Configuration) // Lê configurações do appsettings
         .WriteTo.Console()                            // Escreve no terminal
         .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)); // Cria um arquivo por dia

     // ... (Mesmas configurações de Banco, JWT, Cors de antes)
     var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
     builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
     
     builder.Services.AddControllers();
     builder.Services.AddEndpointsApiExplorer();
     builder.Services.AddSwaggerGen();
     
     // Configuração do CORS
     builder.Services.AddCors(options =>
     {
         options.AddPolicy("AllowAll", policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
     });

     // Configuração do JWT
     var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
     builder.Services.AddAuthentication(x =>
     {
         x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
     }).AddJwtBearer(x =>
     {
         x.RequireHttpsMetadata = false;
         x.SaveToken = true;
         x.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(key),
             ValidateIssuer = false,
             ValidateAudience = false
         };
     });

     var app = builder.Build();

     if (app.Environment.IsDevelopment())
     {
         app.UseSwagger();
         app.UseSwaggerUI();
     }

     // 3. LOGS DE REQUISIÇÃO (Mostra cada chamada HTTP no console de forma limpa)
     app.UseSerilogRequestLogging();

     app.UseHttpsRedirection();
     app.UseCors("AllowAll");

     app.UseAuthentication();
     app.UseAuthorization();

     app.MapControllers();

     app.Run();
 }
 catch (Exception ex)
 {
     // Se algo crítico quebrar no boot (ex: senha do banco errada), cai aqui
     Log.Fatal(ex, "A aplicação falhou ao iniciar!");
 }
 finally
 {
     Log.CloseAndFlush();
 }
 ```

 ### 3. Limpando a Sujeira (Appsettings.json)

 O log padrão do ASP.NET é muito "barulhento" (registra cada arquivo HTML carregado). Vamos filtrar para mostrar apenas o que importa (Avisos e Erros do sistema, Informações nossas).

 **Abra o arquivo:** `src/LivrariaCentral.API/appsettings.json`
 **Atualize a seção "Logging":**

 ```json
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning", // Ignora msgs de "Info" do .NET
        "Microsoft.AspNetCore.Authorization": "Error" 
      }
    },
 ```

 ### 4. Auditoria de Login (AuthController)

 Vamos registrar quem entrou no sistema. Precisamos injetar o `ILogger` no construtor.

 **Abra:** `src/LivrariaCentral.API/Controllers/AuthController.cs`

 ```csharp
 public class AuthController : ControllerBase
 {
     private readonly AppDbContext _context;
     private readonly IConfiguration _configuration;
     private readonly ILogger<AuthController> _logger; // <--- Novo campo

     // Injeção de Dependência atualizada
     public AuthController(AppDbContext context, IConfiguration configuration, ILogger<AuthController> logger)
     {
         _context = context;
         _configuration = configuration;
         _logger = logger; // <--- Recebendo o logger
     }

     [HttpPost("login")]
     public async Task<IActionResult> Login(UsuarioDTO request)
     {
         var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
         
         if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
         {
             // Log de Aviso (Warning) - Alguém tentou entrar e errou
             _logger.LogWarning("Tentativa de login falhou para: {Email}", request.Email);
             return BadRequest("Email ou senha inválidos.");
         }

         string token = GerarToken(usuario);
         
         // Log de Informação (Information) - Sucesso
         _logger.LogInformation("Usuário [{Nome}] realizou login.", usuario.Nome);

         return Ok(new { token = token });
     }
     
     // ... (Resto do código: Método Registrar e GerarToken continuam iguais)
 }
 ```

 **✅ Checkpoint Visual:**
 1. Rode a API.
 2. Tente fazer um Login pelo Swagger (com senha certa e depois errada).
 3. Olhe na pasta do projeto: deve ter aparecido uma pasta nova chamada `logs`.
 4. Abra o arquivo de texto lá dentro. Você verá o histórico do que aconteceu!

 ## 🚀 Sessão 16: Deploy Profissional (Windows e Linux)

 Chegamos ao **Grand Finale**! 🏆 Vamos tirar o sistema do `localhost` e prepará-lo para rodar em um servidor real.

 ### 🛠️ Passo 1: Preparando o Código da API

 **1. Instale os pacotes na API:**

 ```bash
 dotnet add package Microsoft.Extensions.Hosting.WindowsServices
 dotnet add package Microsoft.Extensions.Hosting.Systemd
 ```

 **2. Configure o `Program.cs`:**

 ```csharp
 var builder = WebApplication.CreateBuilder(args);

 // --- CONFIGURAÇÃO DE SERVIÇO (DEPLOY) ---
 builder.Host.UseWindowsService(); // Habilita rodar como Serviço do Windows
 builder.Host.UseSystemd();        // Habilita rodar como Daemon do Linux
 ```

 ### 🏗️ Passo 2: Gerando os Arquivos (Publish)

 Rode estes comandos na **raiz da solução**:

 ```bash
 # 1. Compila o Frontend
 dotnet publish src/LivrariaCentral.Web -c Release -o ./deploy/frontend

 # 2. Compila o Backend para WINDOWS
 dotnet publish src/LivrariaCentral.API -c Release -r win-x64 --self-contained true -o ./deploy/backend
 ```

 ### 🪟 Passo 3: Configuração no Windows (IIS + Serviço)

 1.  **Crie o serviço:**
     ```cmd
     sc create LivrariaAPI binPath= "C:\deploy\backend\LivrariaCentral.API.exe" start= auto
     sc start LivrariaAPI
     ```
 2.  **No IIS:** Crie um site apontando para `C:\deploy\frontend\wwwroot` na porta 80.

 ### 🐧 Passo 4: Configuração no Linux (Nginx + Systemd)

 1.  **Crie o serviço Systemd:** `/etc/systemd/system/livraria-api.service`
 2.  **Configure o Nginx (Proxy Reverso):**

 ```nginx
 server {
     listen 80;
     server_name _;

     location / {
         root /var/www/livraria-web;
         try_files $uri $uri/ /index.html =404;
     }

     location /api {
         proxy_pass http://localhost:5000;
         proxy_http_version 1.1;
         proxy_set_header Upgrade $http_upgrade;
         proxy_set_header Connection keep-alive;
         proxy_cache_bypass $http_upgrade;
     }
 }
 ```