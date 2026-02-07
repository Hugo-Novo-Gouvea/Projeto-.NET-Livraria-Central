# 📚 Livraria Central - Sistema de Gestão Full Stack

![Status](https://img.shields.io/badge/Status-Concluído-success?style=for-the-badge)

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![MudBlazor](https://img.shields.io/badge/MudBlazor-7E6EEF?style=for-the-badge&logo=mui&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

> **Uma solução completa para gerenciamento de livrarias, desenvolvida com as tecnologias mais modernas do ecossistema .NET.**

## 💡 Sobre o Projeto

Este projeto é uma aplicação **Full Stack** robusta desenvolvida para simular o ambiente real de uma livraria. Diferente de projetos acadêmicos simples, o objetivo aqui foi criar um sistema funcional com regras de negócio reais, controle de concorrência, autenticação segura e relatórios.



### 🎯 Objetivos
1.  **Portfólio Técnico:** Demonstrar domínio em arquitetura de software, Clean Code e padrões de mercado (.NET 10, Blazor WASM).
2.  **Material Didático:** O repositório contém um **Guia Passo a Passo** (logo abaixo) para desenvolvedores que desejam aprender a construir aplicações reais do zero.

## 🗺️ Roadmap do Projeto

Este repositório representa a **Parte 1** de uma série de estudos avançados. O objetivo é demonstrar a evolução de um software funcional ("Make it Work") para uma solução Enterprise escalável ("Make it Right").

| Fase | Foco | Status | Descrição |
| :--- | :--- | :---: | :--- |
| **Parte 1** | **MVP Funcional** | ✅ | Construção da aplicação completa (Back + Front + Banco), focado em entrega de valor e funcionalidades (Vendas, Auth, PDF, Logs). |
| **Parte 2** | **Arquitetura & Qualidade** | 🚧 | Refatoração para **Clean Architecture**, implementação de **Testes Unitários** (xUnit), Padrão Repository e validações avançadas (FluentValidation). |
| **Parte 3** | **Cloud & DevOps** | 📅 | Migração para **Microsoft Azure**, configuração de Pipeline de **CI/CD** (GitHub Actions), Dockerização e gestão de segredos. |

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
    git clone https://github.com/seu-usuario/LivrariaCentral.git
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

 ### 1. Infraestrutura

 **Para o Projeto será necessário:**

- **Banco de Dados PostgreSQL 18.**
- **.NET SDK: 10**
- **VIsual Studio Code**

 ## 🚀 Sessão 2: Criação da API

 ### 📝 Resumo Rápido de Comandos (Terminal)

 Para quem não tem o costume de usar o terminal, aqui vai um glossário essencial:

 ```bash
 cd ..             # Sai da pasta atual (volta um nível)
 cd nomeDaPasta    # Entra em uma pasta
 mkdir nomeDaPasta # Cria uma nova pasta (Make Directory)
 ```

 ### 1. Organização (Pasta Source)

 Vamos criar uma pasta `src` (source/código-fonte) na raiz para não misturar o código do projeto com arquivos de configuração soltos (como o README ou gitignore).

 ```bash
 mkdir src
 cd src
 ```

 ### 2. Estrutura inicial da API

 Vamos criar o projeto do tipo **WebAPI**. Este será o nosso **Back-end**.

 ```bash
 dotnet new webapi -n LivrariaCentral.API
 ```

 **O que é uma WebAPI?**
 É o "cérebro" do sistema sem a parte visual. Diferente de um site comum, a API não entrega HTML (telas), ela entrega **Dados Puros** (geralmente em formato JSON).
 * Ela recebe pedidos (ex: "Cadastrar Livro").
 * Ela processa as regras (ex: "O preço não pode ser zero").
 * Ela salva no banco.
 * Ela responde para quem pediu (o Site/Frontend).

 ### 3. Instalação de Pacotes

 Agora precisamos entrar na pasta do projeto e instalar as ferramentas de banco de dados.
 O .NET 10 gerencia as versões automaticamente, então não precisamos especificar números (a menos que use uma versão antiga).

 ```bash
 cd LivrariaCentral.API

 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
 ```

 > **Obs:** Caso esteja utilizando o .NET SDK 9 ou anterior, pode ser necessário adicionar `--version 9.0.0` (ou compatível) ao final de cada linha.

 **O que cada pacote faz:**
 * **EntityFrameworkCore:** É o núcleo do ORM. Ele permite que manipulemos o banco de dados usando classes e códigos C# em vez de escrever SQL puro.
 * **EntityFrameworkCore.Design:** Contém as ferramentas necessárias para rodar os comandos de **Migration** e scaffolding no terminal.
 * **Npgsql...PostgreSQL:** É o "driver" (ou provedor) que ensina o Entity Framework a se comunicar especificamente com o banco **PostgreSQL**.  


 ## 🚀 Sessão 3: Configuração da API (Backend)

 Agora que temos a estrutura, vamos transformar esse projeto vazio em uma API real.
 Usaremos a abordagem **Code-First** (Primeiro o Código), onde criamos as classes em C# e o Entity Framework gera o Banco de Dados para nós.

 ### 1. Estrutura de Pastas

 Vamos organizar a casa. Dentro da pasta do projeto API, crie as pastas para os Modelos e para o Banco de Dados.

 ```bash
 cd src/LivrariaCentral.API
 mkdir Models #Modelos
 mkdir Data #Banco de Dados
 ```

 ### 2. Entidade (Model)

 Como estamos gerenciando uma Livraria, precisamos definir o que é um "Livro".

 **Crie o arquivo `Livro.cs` dentro da pasta `Models`.**

 Esta classe representa a tabela `Livros` no banco de dados. Cada propriedade vira uma coluna.

 ```csharp
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
 ```

 ### 3. Contexto de Banco de Dados

 **Crie o arquivo `AppDbContext.cs` dentro da pasta `Data`.**

 Este arquivo é a "ponte" entre o C# e o PostgreSQL. Ele herda de `DbContext` e ensina ao sistema quais classes devem virar tabelas.

 ```csharp
 using Microsoft.EntityFrameworkCore;
 using LivrariaCentral.API.Models;

 namespace LivrariaCentral.API.Data;

 public class AppDbContext : DbContext
 {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     // Define que a classe Livro será uma tabela chamada "Livros"
     public DbSet<Livro> Livros { get; set; }
 }
 ```

 ### 4. Connection String (Acesso ao Banco)

 Precisamos dizer onde o banco está e qual a senha.

 

 **Abra o arquivo `appsettings.json` na raiz de `LivrariaCentral.API` e atualize a seção "ConnectionStrings":**

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

 > **⚠️ Importante:** Substitua `admin` em `Password=` pela senha que você configurou ao instalar o PostgreSQL. Se o nome do seu banco for diferente, altere o `LivrariaCentral` em `Database=` para o nome do seu banco.

 > **⚠️⚠️⚠️🛡️ Segurança:** Caso pretenda subir este projeto para o GitHub, **jamais envie senhas reais!** Em projetos profissionais, usamos "User Secrets" ou Variáveis de Ambiente. Para este estudo, garanta que a senha usada aqui seja apenas para testes locais e não uma senha pessoal importante.

 ### 5. Configuração dos Serviços (Program.cs)

 Primeiro, vamos instalar o pacote que gera a documentação automática (Swagger).

 ```bash
 dotnet add package Swashbuckle.AspNetCore
 ```

 Agora, substitua **todo o conteúdo** do arquivo `Program.cs` pelo código abaixo.
 Aqui nós configuramos a Injeção de Dependência do Banco e ativamos os Controllers.

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

 ### 6. Migrations (Inicialização do Banco)

 Agora vamos criar o banco de dados físico usando os comandos do Entity Framework.

 ```bash
 # Instala a ferramenta global do EF (se já tiver, ele avisa)
 dotnet tool install --global dotnet-ef

 # 1. Cria o script de migração (a "receita" do banco)
 dotnet ef migrations add InitialCreate

 # 2. Aplica o script no PostgreSQL (cria as tabelas de verdade)
 dotnet ef database update
 ```

 **Entendendo os comandos:**
 * **migrations add:** Analisa suas classes C# (`Livro`) e cria um arquivo descrevendo como criar essa tabela no SQL.
 * **database update:** Pega essa descrição e executa no banco de dados real. Se você abrir seu PostgreSQL agora, verá a tabela `Livros` lá!

 ## 🚀 Sessão 4: Endpoints da API (Controllers)

 Os **Controllers** são os "garçons" da nossa API. Eles são responsáveis por receber os pedidos HTTP (GET, POST, PUT, DELETE), processar a regra de negócio e devolver os dados.

 ### 1. Criar a Pasta

 Dentro da pasta `src/LivrariaCentral.API`, vamos criar um local para guardar nossos controladores.

 ```bash
 cd src/LivrariaCentral.API # Apenas se não estiver nela
 mkdir Controllers
 ```

 ### 2. Criar o Controller de Livros

 **Crie o arquivo `LivrosController.cs` dentro da pasta `Controllers`.**

 Copie o código abaixo. Ele implementa o **CRUD** completo (Create, Read, Update, Delete) usando os métodos assíncronos do Entity Framework.

 ```csharp
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using LivrariaCentral.API.Data;
 using LivrariaCentral.API.Models;

 namespace LivrariaCentral.API.Controllers;

 [Route("api/[controller]")]  // A rota será: api/livros
 [ApiController]
 public class LivrosController : ControllerBase
 {
     private readonly AppDbContext _context;

     // Injeção de Dependência do Banco de Dados
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

     // PUT: api/livros/5 (Atualiza um livro)
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

 Agora vamos rodar a API e ver a "mágica" acontecendo na interface gráfica, use o comando abaixo no terminal dentro de `LivrariaCentral.API`.

 ```bash
 dotnet run
 ```

 1.  Observe no terminal a linha `Now listening on: http://localhost:xxxx`.
 2.  Abra o navegador e digite: `http://localhost:xxxx/swagger` (substitua `xxxx` pela porta que apareceu).
 3.  Você verá a tela do Swagger listando seus endpoints.

 

 **Vamos cadastrar o primeiro livro:**

 1.  Clique em **POST /api/livros**.
 2.  Clique no botão **Try it out** (no canto direito).
 3.  Na caixa de texto, apague o conteúdo e cole este JSON (note que não precisamos enviar ID nem Data, o sistema gera sozinho):

     ```json
     {
       "titulo": "Arquitetura Limpa",
       "autor": "Robert C. Martin",
       "preco": 120.99,
       "estoque": 10
     }
     ```
 4.  Clique no botão azul **Execute**.

 ### 4. Entendendo a Resposta

 Logo abaixo, na seção **Server response**, verifique o **Code**:

 * **Code 201 (Created):** Sucesso! O registro foi criado. O corpo da resposta mostrará o livro com o `ID` gerado pelo banco.
 * **Code 200 (Success):** Sucesso na consulta ou atualização.

 Parabéns! Seu Back-end está completo: ele **adiciona, lê, altera e remove** dados do PostgreSQL. Isso é o que chamamos de **CRUD**.`

 ## 🚀 Sessão 5: Criação do Frontend (Blazor WebAssembly)

 O Frontend será uma **Single Page Application (SPA)**. Isso significa que o site carrega apenas uma vez e depois navega instantaneamente, parecendo um aplicativo de celular.

 ### 1. Criação do Projeto

 Volte para a pasta `src` e crie o projeto web ao lado da API.

 ```bash
 cd ..
 # (Certifique-se de que está na pasta "src")

 # Cria o projeto Blazor WebAssembly Standalone
 dotnet new blazorwasm -n LivrariaCentral.Web

 # Entra na pasta
 cd LivrariaCentral.Web
 ```

 ### 2. Instalação da Biblioteca Visual (MudBlazor)

 Instala o pacote de componentes (Gráficos, Tabelas, Botões).
 Vamos instalar a **versão 7** para garantir compatibilidade total com este guia.

 ```bash
 dotnet add package MudBlazor --version 7.0.0
 ```

 **O que é o MudBlazor?**
 É um framework de componentes de interface (UI) criado especificamente para Blazor.
 * **Visual Profissional:** Ele segue o padrão **Material Design** (o mesmo visual clean usado pelo Google e Android).
 * **Produtividade:** Funciona como uma caixa de "LEGO". Em vez de escrevermos CSS e HTML puros, usamos componentes prontos (como `<MudButton>`, `<MudDataGrid>`).

 ### 3. Configuração Inicial

 Primeiro, vamos adicionar o projeto Web à solução geral (para o Visual Studio reconhecer os dois projetos).

 ```bash
 cd .. 
 # Volta para a raiz onde está o arquivo .sln

 dotnet sln add src/LivrariaCentral.Web/LivrariaCentral.Web.csproj
 ```

 Agora, vamos configurar o MudBlazor nos arquivos do projeto.

 #### A. Importações Globais (_Imports.razor)

 **Abra o arquivo `src/LivrariaCentral.Web/_Imports.razor`.**
 Adicione as linhas abaixo no final do arquivo. Isso permite usar os componentes em qualquer página sem precisar importar toda hora.

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

 **Abra o arquivo `src/LivrariaCentral.Web/wwwroot/index.html`.**
 Precisamos adicionar as fontes do Google e os scripts do MudBlazor.

 **Substitua todo o conteúdo deste arquivo pelo código abaixo:**
 *(Já removemos o script com `fingerprint` para evitar erros de cache em desenvolvimento)*.

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

 Diferente da API, o Blazor WebAssembly não cria o arquivo de configuração por padrão. Precisamos criá-lo para evitar deixar o endereço da API "chumbado" no código.

 **Crie o arquivo `appsettings.json` DENTRO da pasta `wwwroot` em `LivrariaCentral.Web`:**

 ```json
 {
   "ApiUrl": "http://localhost:5000"
 }
 ```

 > **⚠️ Importante:** O valor `http://localhost:5000` é a porta padrão que configuraremos na API. Se a sua API estiver rodando em outra porta, altere aqui.

 ### 5. Registro de Serviços (Program.cs)

 Agora vamos ensinar o Blazor a ler esse arquivo JSON e usar o endereço correto.

 **Substitua todo o conteúdo do arquivo `src/LivrariaCentral.Web/Program.cs`:**

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

 **Abra o arquivo `src/LivrariaCentral.Web/Layout/MainLayout.razor` e substitua tudo por:**

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

 Vamos criar a tela inicial com **Indicadores de Desempenho (KPIs)** e gráficos.
 Por enquanto, usaremos dados "Fictícios" (Hardcoded) apenas para estruturar o layout e testar os componentes visuais. Nas próximas sessões, conectaremos isso à API.

 ### 1. Editando a Página Inicial (Home.razor)

 **Abra o arquivo `src/LivrariaCentral.Web/Pages/Home.razor`.**
 Substitua todo o conteúdo pelo código abaixo.

 Observe o uso de `<MudGrid>` e `<MudItem>`:
 * `xs="12"`: Em celulares, ocupa a linha toda (1 card por linha).
 * `sm="6"`: Em tablets, ocupa metade (2 cards por linha).
 * `md="3"`: Em computadores, ocupa 1/4 (4 cards por linha).

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

 Rode o projeto Frontend para ver o resultado.

 ```bash
 cd src/LivrariaCentral.Web # Apenas se necessário
 dotnet run
 ```

 1.  Abra o navegador no endereço indicado.
 2.  **O que você deve ver:**
     * **Topo:** 4 Cards com ícones coloridos alinhados.
     * **Esquerda:** Um gráfico de barras interativo (passe o mouse para ver os valores).
     * **Direita:** Um gráfico de rosca (Donut) dividindo as categorias.

 ## 🚀 Sessão 7: Conectando com a API (Listagem Real)

 Nesta etapa, vamos permitir que o Frontend converse com o Backend.
 Para isso, precisamos configurar o **CORS** (Cross-Origin Resource Sharing) e criar a tabela de listagem de livros.

 

 ### 1. Configurando CORS na API (Backend)

 Por segurança, os navegadores bloqueiam quando um site (ex: porta 5000) tenta acessar uma API em outra porta (ex: 5123). Precisamos liberar isso explicitamente.

 **Abra o arquivo `src/LivrariaCentral.API/Program.cs` e adicione as linhas marcadas com `[NOVO] <---`:**

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

 **Crie a pasta `Models` dentro de `src/LivrariaCentral.Web`.**
 **Crie o arquivo `Livro.cs` dentro desta pasta:**

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

 ### 3. Criando a Página de Listagem (Livros.razor)

 Vamos usar o componente `MudDataGrid` que é super poderoso: já traz busca, filtro e paginação prontos.

 **Crie o arquivo `Livros.razor` dentro de `src/LivrariaCentral.Web/Pages/`:**

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
 Em vez de criar uma página nova para cada ação, usaremos **Dialogs** (Janelas Modais/Pop-ups) do MudBlazor para uma experiência de usuário mais fluida.

 

 ### 1. Criando o Componente de Formulário (Modal)

 Este arquivo será a "janelinha" que abre para preencher os dados do livro.

 **Crie o arquivo `LivroDialog.razor` na pasta `src/LivrariaCentral.Web/Pages/`:**

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

 Agora vamos voltar na página de listagem e fazer os botões funcionarem.

 **Substitua todo o conteúdo do arquivo `src/LivrariaCentral.Web/Pages/Livros.razor`:**

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

 **Crie o arquivo `DashboardController.cs` na pasta `src/LivrariaCentral.API/Controllers/`:**

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

 **Crie o arquivo `DashboardDados.cs` na pasta `src/LivrariaCentral.Web/Models/`:**

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

 **Substitua todo o conteúdo de `src/LivrariaCentral.Web/Pages/Home.razor`:**

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
 Não é apenas salvar um registro; precisamos checar se tem estoque, calcular o preço total e dar baixa no produto automaticamente.

 

 ### 1. O Modelo de Venda (Backend)

 Precisamos criar uma tabela para guardar o histórico de vendas.

 **Crie o arquivo `Venda.cs` na pasta `src/LivrariaCentral.API/Models/`:**

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

 **Abra o arquivo `src/LivrariaCentral.API/Data/AppDbContext.cs` e adicione a linha da tabela Vendas:**

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

 Vamos criar essa tabela no PostgreSQL. No terminal da pasta `src/LivrariaCentral.API`, rode:

 ```bash
 dotnet ef migrations add CriandoVendas
 dotnet ef database update
 ```

 ### 4. A Lógica da Venda (Controller)

 Aqui está a mágica. O Endpoint não vai só salvar, ele vai checar o estoque e diminuir a quantidade **antes** de confirmar a venda.

 **Crie o arquivo `VendasController.cs` na pasta `src/LivrariaCentral.API/Controllers/`:**

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

         // 3. Cria o registro da venda (Calcula valor no servidor por segurança)
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

 **Crie o arquivo `VendaDialog.razor` na pasta `src/LivrariaCentral.Web/Pages/`:**

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

 **Crie o arquivo `VendaDTO.cs` na pasta `src/LivrariaCentral.Web/Models/`:**

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

 **Substitua todo o conteúdo de `src/LivrariaCentral.Web/Pages/Livros.razor` pelo código abaixo:**

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

 **O que deve acontecer:**
 * O modal fecha.
 * Uma mensagem verde aparece: "Venda realizada!".
 * A quantidade na tabela muda automaticamente de 10 para 8.

 **Teste de Erro:**
 * Tente vender 100 unidades desse mesmo livro.
 * Uma mensagem vermelha deve aparecer: "Erro: Estoque insuficiente...".

 ## 🚀 Sessão 11: Histórico de Vendas (Consulta e Join)

 Agora que já estamos vendendo, precisamos de um relatório para saber o que foi vendido.
 Aqui temos um desafio técnico: a tabela de `Vendas` só tem o ID do livro (`LivroId`), mas na tela queremos mostrar o **Título** do livro.

 Para resolver isso, faremos um **Join** (Cruzamento de Tabelas) no Backend.

 

 ### 1. Backend: Preparando a Consulta (VendasController)

 Precisamos de um endpoint que devolva a lista de vendas, mas que já inclua o nome do livro buscado na outra tabela.

 **Abra o arquivo `src/LivrariaCentral.API/Controllers/VendasController.cs` e adicione o método `GetVendas`:**

 ```csharp
     // ... (Método RealizarVenda fica acima deste)

     [HttpGet]
     public async Task<IActionResult> GetVendas()
     {
         // Faz a junção (Join) entre Venda e Livro para pegar o Título
         // É similar ao PROCV do Excel ou JOIN do SQL
         var historico = await _context.Vendas
             .Join(_context.Livros,
                 venda => venda.LivroId,  // Chave na tabela Venda
                 livro => livro.Id,       // Chave na tabela Livro
                 (venda, livro) => new    // O que vamos devolver para o site
                 {
                     Id = venda.Id,
                     DataVenda = venda.DataVenda,
                     LivroTitulo = livro.Titulo, // <--- Aqui está a mágica!
                     Quantidade = venda.Quantidade,
                     ValorTotal = venda.ValorTotal
                 })
             .OrderByDescending(v => v.DataVenda) // Mais recentes primeiro
             .ToListAsync();

         return Ok(historico);
     }
 ```

 ### 2. Frontend: Modelo de Dados

 O Frontend precisa de uma classe para receber esses dados combinados (Venda + Nome do Livro).

 **Crie o arquivo `VendaHistorico.cs` na pasta `src/LivrariaCentral.Web/Models/`:**

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

 **Crie o arquivo `HistoricoVendas.razor` na pasta `src/LivrariaCentral.Web/Pages/`:**

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

 ### 4. Frontend: Atualizando o Menu

 Por fim, precisamos colocar um link no menu lateral para acessar essa nova tela.

 **Abra o arquivo `src/LivrariaCentral.Web/Layout/MainLayout.razor` e adicione a linha do Histórico:**

 ```razor
         <MudNavMenu>
             <MudNavLink Href="/" Match="NavLinkMatch.All" Icon="@Icons.Material.Filled.Dashboard">Dashboard</MudNavLink>
             <MudNavLink Href="/livros" Icon="@Icons.Material.Filled.LibraryBooks">Livros</MudNavLink>
             
                          <MudNavLink Href="/historico" Match="NavLinkMatch.Prefix" Icon="@Icons.Material.Filled.History">Histórico</MudNavLink>
         </MudNavMenu>
 ```

 ### 5. Testando

 1.  Faça algumas vendas na tela de Livros.
 2.  Clique no menu **Histórico**.
 3.  Veja a lista ordenada da venda mais recente para a mais antiga, com o nome do livro correto e o horário ajustado para o seu fuso horário.

 ## 🚀 Sessão 12: Gerando Relatórios em PDF

 Vamos criar um botão que baixa um PDF profissional com a lista de produtos e o valor total do estoque.
 Usaremos a biblioteca **QuestPDF**, que é a solução mais moderna e performática para gerar documentos no ecossistema .NET.

 

 ### 1. Instalando o QuestPDF na API

 Pare a API se estiver rodando. No terminal da pasta `src/LivrariaCentral.API`, rode:

 ```bash
 dotnet add package QuestPDF
 ```

 ### 2. Configurando a Licença (Gratuita)

 O QuestPDF é gratuito para uso comunitário/estudantil, mas exige que a gente configure isso explicitamente.

 **Abra o arquivo `src/LivrariaCentral.API/Program.cs` e adicione estas linhas logo no topo:**

 ```csharp
 using QuestPDF.Infrastructure; // <--- Importante

 QuestPDF.Settings.License = LicenseType.Community; // <--- Licença Gratuita

 var builder = WebApplication.CreateBuilder(args);
 // ... resto do código
 ```

 ### 3. Criando o Endpoint do Relatório

 Vamos criar um Controller que desenha o PDF e devolve o arquivo binário para o navegador.

 **Crie o arquivo `RelatoriosController.cs` na pasta `src/LivrariaCentral.API/Controllers/`:**

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
 ```

 ### 4. Botão de Download no Frontend

 Vamos colocar um botão de impressora na tela de Livros que abre o PDF em uma nova aba.

 **Abra o arquivo `src/LivrariaCentral.Web/Pages/Livros.razor`:**

 1.  Adicione a injeção do JS Runtime no topo do arquivo (junto com os outros `@inject`):
     ```razor
     @inject IJSRuntime JS
     ```

 2.  Localize onde está o botão "Novo Livro" e substitua por este bloco (adicionando o botão de Imprimir ao lado):
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

 3.  Adicione a função `BaixarRelatorio` no bloco `@code` (pode ser no final):
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

 ### 5. Testando

 1.  Rode a API e o Frontend.
 2.  Vá na aba **Livros**.
 3.  Clique no botão cinza **"Imprimir Estoque"**.
 4.  O navegador deve abrir uma nova aba exibindo um PDF formatado com a lista dos seus livros!

 ## 🚀 Sessão 13: Segurança e Autenticação (Backend)

 Vamos implementar **JWT (JSON Web Tokens)**.
 Funciona assim: o usuário manda email/senha, a API confere e, se estiver certo, devolve um "crachá digital" (Token). Para qualquer outra requisição (como cadastrar livro), o usuário mostra esse crachá.

 

 ### 1. Instalando Pacotes de Segurança

 Pare a API. No terminal da pasta `src/LivrariaCentral.API`, rode:

 ```bash
 dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
 dotnet add package BCrypt.Net-Next
 ```
 *Nota: O BCrypt serve para criptografar a senha no banco. Nunca salve senhas em texto puro!*

 ### 2. Criando a Tabela de Usuários

 **Arquivo: `src/LivrariaCentral.API/Models/Usuario.cs`**

 ```csharp
 namespace LivrariaCentral.API.Models;

 public class Usuario
 {
     public int Id { get; set; }
     public string Email { get; set; } = string.Empty;
     public string SenhaHash { get; set; } = string.Empty; 
     public string Nome { get; set; } = string.Empty;
 }

 // Classe auxiliar para receber os dados do Login/Registro (DTO)
 public class UsuarioDTO
 {
     public string Email { get; set; } = string.Empty;
     public string Senha { get; set; } = string.Empty;
 }
 ```

 ### 3. Atualizando o Banco de Dados

 Precisamos avisar o Entity Framework sobre a nova tabela.

 **Arquivo: `src/LivrariaCentral.API/Data/AppDbContext.cs`**

 ```csharp
 using LivrariaCentral.API.Models; // <--- Importante: Adicione este using
 using Microsoft.EntityFrameworkCore;

 namespace LivrariaCentral.API.Data;

 public class AppDbContext : DbContext
 {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     public DbSet<Livro> Livros { get; set; }
     public DbSet<Venda> Vendas { get; set; }
     public DbSet<Usuario> Usuarios { get; set; } // <--- ADICIONE ESTA LINHA
 }
 ```

 Agora rode as migrations no terminal:
 ```bash
 dotnet ef migrations add CriandoUsuarios
 dotnet ef database update
 ```

 ### 4. Configurando o Segredo (Chave do Token)

 Precisamos de uma frase secreta para assinar os tokens.

 **Arquivo: `src/LivrariaCentral.API/appsettings.json`**
 Adicione a seção "Jwt":

 ```json
 {
   "ConnectionStrings": { ... },
   "Logging": { ... },
   "Jwt": {
     "Key": "MinhaChaveSuperSecretaDeLivraria123!" 
   },
   "AllowedHosts": "*"
 }
 ```

 ### 5. Criando o Controlador de Autenticação

 Aqui vamos criar as rotas `/api/auth/registrar` e `/api/auth/login`.

 **Arquivo: `src/LivrariaCentral.API/Controllers/AuthController.cs`**

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
         
         // Verifica se usuário existe e se a senha bate com o hash
         if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
         {
             return BadRequest("Email ou senha inválidos.");
         }

         // Se passou, gera o Token JWT
         string token = GerarToken(usuario);
         return Ok(new { token = token });
     }

     private string GerarToken(Usuario usuario)
     {
         // IMPORTANTE: Use UTF8 aqui e no Program.cs
         var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
         var claims = new List<Claim>
         {
             new Claim(ClaimTypes.Name, usuario.Email),
             new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
         };

         var tokenDescriptor = new SecurityTokenDescriptor
         {
             Subject = new ClaimsIdentity(claims),
             Expires = DateTime.UtcNow.AddHours(8), // Token vale por 8 horas
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

 **Arquivo: `src/LivrariaCentral.API/Program.cs`**

 ```csharp
 // ... imports (Adicione estes dois)
 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
 using System.Text;

 // ... (Logo após builder.Services.AddSwaggerGen();)

 // 1. Configura o JWT
 // IMPORTANTE: Deve ser UTF8 para bater com o Controller
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

 // ... (Swagger e HttpsRedirection)

 app.UseCors("AllowAll");

 // 2. ATENÇÃO: A ordem aqui importa muito!
 app.UseAuthentication(); // <--- Quem é você? (Verifica o Token)
 app.UseAuthorization();  // <--- Você pode entrar aqui? (Verifica Permissão)

 app.MapControllers();
 app.Run();
 ```
### 7. Criando o Primeiro Usuário (Admin)

 Como não criaremos uma tela de "Cadastre-se" no site (pois é um sistema restrito para funcionários), precisamos criar o primeiro usuário via Swagger.

 1.  Rode a API (`dotnet run`).
 2.  Acesse o Swagger (`http://localhost:xxxx/swagger`).
 3.  Abra a rota **POST /api/auth/registrar**.
 4.  Clique em **Try it out** e envie este JSON:

     ```json
     {
       "email": "admin@livraria.com",
       "senha": "admin"
     }
     ```
 5.  Clique em **Execute**.

 Se receber um **200 OK**, seu usuário está criado! Guarde esse email e senha, pois usaremos na próxima sessão para entrar no site.

 ## 🚀 Sessão 14: Login no Frontend (O Porteiro do Site)

 Vamos criar a tela de login, ensinar o Blazor a lembrar quem está logado e proteger as rotas.

 ### 1. Instalando o LocalStorage

 Precisamos guardar o Token no navegador para o usuário não precisar logar a cada clique.

 No terminal da pasta `src/LivrariaCentral.Web`, rode:
 ```bash
 dotnet add package Blazored.LocalStorage
 dotnet add package Microsoft.AspNetCore.Components.Authorization
 ```

 ### 2. Configurando as Importações Globais

 **Abra o arquivo:** `src/LivrariaCentral.Web/_Imports.razor`
 Adicione estas linhas no final:

 ```razor
 @using Microsoft.AspNetCore.Components.Authorization
 @using Microsoft.AspNetCore.Authorization
 @using Blazored.LocalStorage
 @using System.Text.Json
 @using System.Globalization
 ```

 ### 3. O Provedor de Autenticação (O Cérebro)

 Vamos criar a classe que gerencia o crachá do usuário. Ela também vai ensinar o Blazor a ler o Nome corretamente dentro do Token.

 **Crie a pasta:** `src/LivrariaCentral.Web/Auth/`
 **Crie o arquivo:** `CustomAuthStateProvider.cs` dentro dela.

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
         string token = await _localStorage.GetItemAsStringAsync("authToken");

         var identity = new ClaimsIdentity();
         _http.DefaultRequestHeaders.Authorization = null;

         if (!string.IsNullOrEmpty(token))
         {
             try
             {
                 // O "unique_name" diz pro Blazor onde achar o Nome do usuário no Token
                 identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt", "unique_name", "role");
                 _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
             }
             catch
             {
                 await _localStorage.RemoveItemAsync("authToken");
             }
         }

         var user = new ClaimsPrincipal(identity);
         var state = new AuthenticationState(user);

         NotifyAuthenticationStateChanged(Task.FromResult(state));
         return state;
     }

     public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
     {
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

 Aqui mantemos a configuração do `appsettings.json` (que fizemos na Sessão 5) e adicionamos a Autenticação e a correção de Cultura.

 **Arquivo: `src/LivrariaCentral.Web/Program.cs`**

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

 Configurar o roteador para verificar se o usuário está logado.

 **Arquivo: `src/LivrariaCentral.Web/App.razor`**

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

 Vamos mostrar o nome do usuário logado e o botão de Sair.

 **Arquivo: `src/LivrariaCentral.Web/Layout/MainLayout.razor`**

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

 Agora adicione o atributo `[Authorize]` no topo das páginas que você quer proteger (Home, Livros, Histórico).

 **Exemplo em `Livros.razor`:**

 ```razor
 @page "/livros"
 @attribute [Authorize]

 @using ...
 ```

 ## 🚀 Sessão 15: Logs e Monitoramento (A Caixa Preta)

 Vamos configurar a API para criar um arquivo diário (ex: `log-20260206.txt`) registrando tudo o que acontece. Além disso, vamos registrar **QUEM** fez cada ação (Auditoria).

 

 ### 1. Instalando o Serilog

 Pare a API. No terminal da pasta `src/LivrariaCentral.API`, rode:

 ```bash
 dotnet add package Serilog.AspNetCore
 dotnet add package Serilog.Sinks.File
 ```

 ### 2. Configurando a "Caixa Preta" (Program.cs)

 Vamos configurar o Serilog para gravar em arquivo e no console.

 **Substitua todo o conteúdo do arquivo `src/LivrariaCentral.API/Program.cs` por este código blindado:**

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
 // Garante que erros na inicialização sejam pegos antes mesmo do app subir
 Log.Logger = new LoggerConfiguration()
     .WriteTo.Console()
     .CreateBootstrapLogger();

 try 
 {
     Log.Information("Iniciando a API Livraria Central...");
     
     var builder = WebApplication.CreateBuilder(args);

     // 2. Conecta o Serilog no Host (Configuração Completa)
     builder.Host.UseSerilog((context, configuration) => configuration
         .ReadFrom.Configuration(context.Configuration) // Lê configurações do appsettings
         .WriteTo.Console()                             // Escreve no terminal preto
         .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)); // Cria arquivo diário

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

     // 3. LOGS DE REQUISIÇÃO (Mostra cada chamada HTTP no console)
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
     Log.Fatal(ex, "A aplicação falhou ao iniciar!");
 }
 finally
 {
     Log.CloseAndFlush();
 }
 ```

 ### 3. Limpando a Sujeira (Appsettings.json)

 Vamos configurar o log para não encher o console com mensagens inúteis de autorização (aqueles "Authorization failed").

 **Abra o arquivo `src/LivrariaCentral.API/appsettings.json` e atualize a seção "Logging":**

 ```json
   "Logging": {
     "LogLevel": {
       "Default": "Information",
       "Microsoft.AspNetCore": "Warning",
       "Microsoft.AspNetCore.Authorization": "Error" 
     }
   },
 ```
 *(Adicionamos a linha do Authorization como "Error" para silenciar os avisos)*.

 ### 4. Auditoria de Login (AuthController)

 Vamos registrar quem entrou no sistema.

 **Abra `src/LivrariaCentral.API/Controllers/AuthController.cs`:**
 1. Injete o `ILogger`.
 2. Adicione os logs no método `Login`.

 ```csharp
 public class AuthController : ControllerBase
 {
     private readonly AppDbContext _context;
     private readonly IConfiguration _configuration;
     private readonly ILogger<AuthController> _logger; // <--- Adicione

     public AuthController(AppDbContext context, IConfiguration configuration, ILogger<AuthController> logger)
     {
         _context = context;
         _configuration = configuration;
         _logger = logger; // <--- Injete
     }

     // ... (Método Registrar mantém igual) ...

     [HttpPost("login")]
     public async Task<IActionResult> Login(UsuarioDTO request)
     {
         var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
         
         if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
         {
             _logger.LogWarning("Tentativa de login falhou para o email: {Email}", request.Email); // <--- Log de Falha
             return BadRequest("Email ou senha inválidos.");
         }

         string token = GerarToken(usuario);
         
         _logger.LogInformation("Usuário [{Nome}] ({Email}) realizou login com sucesso.", usuario.Nome, usuario.Email); // <--- Log de Sucesso

         return Ok(new { token = token });
     }
     // ...
 }
 ```

 ### 5. Auditoria de Livros (LivrosController)

 Vamos saber quem cadastrou ou excluiu livros.

 **Abra `src/LivrariaCentral.API/Controllers/LivrosController.cs`:**

 ```csharp
 using Microsoft.AspNetCore.Authorization;
 // ...

 [Route("api/livros")]
 [ApiController]
 [Authorize] // <--- Garante que User.Identity não seja nulo
 public class LivrosController : ControllerBase
 {
     private readonly AppDbContext _context;
     private readonly ILogger<LivrosController> _logger; // <--- Logger

     public LivrosController(AppDbContext context, ILogger<LivrosController> logger)
     {
         _context = context;
         _logger = logger;
     }

     // ... (GetLivros e GetLivro mantém iguais) ...

     [HttpPost]
     public async Task<ActionResult<Livro>> PostLivro(Livro livro)
     {
         _context.Livros.Add(livro);
         await _context.SaveChangesAsync();

         // Registra QUEM cadastrou o livro
         _logger.LogInformation("Livro '{Titulo}' cadastrado por: {Usuario}", livro.Titulo, User.Identity?.Name);

         return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
     }

     [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteLivro(int id)
     {
         var livro = await _context.Livros.FindAsync(id);
         if (livro == null) return NotFound();

         _context.Livros.Remove(livro);
         await _context.SaveChangesAsync();

         // Registra QUEM excluiu o livro
         _logger.LogInformation("Livro '{Titulo}' (ID: {Id}) excluído por: {Usuario}", livro.Titulo, id, User.Identity?.Name);

         return NoContent();
     }
     // ...
 }
 ```

 ### 6. Auditoria de Vendas (VendasController)

 **Abra `src/LivrariaCentral.API/Controllers/VendasController.cs`:**

 ```csharp
 using Microsoft.AspNetCore.Authorization;
 // ...

 [ApiController]
 [Route("api/vendas")]
 [Authorize]
 public class VendasController : ControllerBase
 {
     private readonly AppDbContext _context;
     private readonly ILogger<VendasController> _logger;

     public VendasController(AppDbContext context, ILogger<VendasController> logger)
     {
         _context = context;
         _logger = logger;
     }

     [HttpPost]
     public async Task<IActionResult> RealizarVenda(Venda novaVenda)
     {
         try
         {
             var livro = await _context.Livros.FindAsync(novaVenda.LivroId);
             
             if (livro == null) 
             {
                 _logger.LogWarning("Usuário {User} tentou vender livro inexistente (ID {Id}).", User.Identity?.Name, novaVenda.LivroId);
                 return NotFound("Livro não encontrado.");
             }

             if (livro.Estoque < novaVenda.Quantidade)
             {
                 _logger.LogWarning("Estoque insuficiente. Vendedor: {User}, Livro: {Titulo}", User.Identity?.Name, livro.Titulo);
                 return BadRequest($"Estoque insuficiente.");
             }

             novaVenda.ValorTotal = livro.Preco * novaVenda.Quantidade;
             novaVenda.DataVenda = DateTime.UtcNow;

             _context.Vendas.Add(novaVenda);
             livro.Estoque -= novaVenda.Quantidade;
             
             await _context.SaveChangesAsync();

             // LOG DE SUCESSO
             _logger.LogInformation("Venda por [{User}]: Livro '{Titulo}', Qtd {Qtd}, Total {Total}", User.Identity?.Name, livro.Titulo, novaVenda.Quantidade, novaVenda.ValorTotal);

             return Ok(new { mensagem = "Venda realizada com sucesso!", novoEstoque = livro.Estoque });
         }
         catch (Exception ex)
         {
             _logger.LogError(ex, "Erro crítico na venda de {User}", User.Identity?.Name);
             return StatusCode(500, "Erro interno.");
         }
     }

     [HttpGet]
     public async Task<IActionResult> GetVendas()
     {
         _logger.LogInformation("Usuário [{User}] consultou o Histórico de Vendas.", User.Identity?.Name);
         
         var historico = await _context.Vendas
             .Join(_context.Livros,
                 venda => venda.LivroId,
                 livro => livro.Id,
                 (venda, livro) => new 
                 {
                     Id = venda.Id,
                     DataVenda = venda.DataVenda,
                     LivroTitulo = livro.Titulo,
                     Quantidade = venda.Quantidade,
                     ValorTotal = venda.ValorTotal
                 })
             .OrderByDescending(v => v.DataVenda)
             .ToListAsync();

         return Ok(historico);
     }
 }
 ```

 ### 7. Testando a Caixa Preta

 1.  Rode a API: `dotnet run`.
 2.  Use o site para: Fazer Login, Cadastrar um Livro e Fazer uma Venda.
 3.  Vá na pasta `src/LivrariaCentral.API/logs/`.
 4.  Abra o arquivo de texto mais recente.

 **Resultado Esperado no Arquivo:**
 ```text
 [INF] Usuário [Administrador] (admin@livraria.com) realizou login com sucesso.
 [INF] Livro 'Dom Casmurro' cadastrado por: Administrador
 [INF] Venda por [Administrador]: Livro 'Dom Casmurro', Qtd 1, Total 45.00
 ```

 ## 🚀 Sessão 16: Deploy Profissional (Windows e Linux)

 Chegamos ao **Grand Finale**! 🏆
 Vamos tirar o sistema do `localhost` e prepará-lo para rodar em um servidor real.

 Usaremos a arquitetura de **Proxy Reverso**:
 * O **Backend** roda escondido (Serviço).
 * O **Servidor Web (IIS/Nginx)** entrega o site e repassa os pedidos de API para o Backend.

 

 ### 🛠️ Passo 1: Preparando o Código da API

 Para que a API rode como um "Serviço do Windows" ou "Systemd do Linux" sem erros, precisamos instalar as extensões nativas.

 1. **Instale os pacotes na API:**
    No terminal `src/LivrariaCentral.API`:
    ```bash
    dotnet add package Microsoft.Extensions.Hosting.WindowsServices
    dotnet add package Microsoft.Extensions.Hosting.Systemd
    ```

 2. **Configure o `Program.cs` da API:**
    Adicione as linhas `UseWindowsService` e `UseSystemd` logo após criar o builder. Isso garante que a API entenda os sinais de "Iniciar" e "Parar" do sistema operacional.

    ```csharp
    var builder = WebApplication.CreateBuilder(args);

    // --- CONFIGURAÇÃO DE SERVIÇO (DEPLOY) ---
    builder.Host.UseWindowsService(); // Habilita rodar como Serviço do Windows
    builder.Host.UseSystemd();        // Habilita rodar como Daemon do Linux
    // ----------------------------------------

    // O Serilog já estava aqui da sessão anterior
    builder.Host.UseSerilog((context, configuration) => ... );
    
    // ... resto do código
    ```

 ---

 ### 🏗️ Passo 2: Gerando os Arquivos (Publish)

 Vamos gerar a versão final, otimizada e sem código fonte, pronta para copiar para o servidor.

 Rode estes comandos na **raiz da solução** (onde está o `.sln`):

 ```bash
 # 1. Compila o Frontend (Gera HTML/CSS/DLLs na pasta deploy/frontend)
 dotnet publish src/LivrariaCentral.Web -c Release -o ./deploy/frontend

 # 2. Compila o Backend para WINDOWS (Gera .exe na pasta deploy/backend)
 dotnet publish src/LivrariaCentral.API -c Release -r win-x64 --self-contained true -o ./deploy/backend

 # (OU, se seu servidor for LINUX, use este comando:)
 # dotnet publish src/LivrariaCentral.API -c Release -r linux-x64 --self-contained true -o ./deploy/backend
 ```

 > **🐈 Pulo do Gato:** Antes de subir para o servidor, abra o arquivo `deploy/frontend/wwwroot/appsettings.json` e altere o `ApiUrl` para o endereço real do seu servidor (ex: `http://meusite.com/api` ou mantenha `http://localhost:5000` se for usar a config de Nginx abaixo).

 ---

 ### 🪟 Passo 3: Configuração no Windows (IIS + Serviço)

 #### A. Instalando a API (Windows Service)
 O Backend vai rodar "invisível" em segundo plano.

 1. Abra o **CMD** ou **PowerShell** como **Administrador**.
 2. Crie o serviço (Atenção: o espaço depois do `=` é obrigatório!):
    ```cmd
    sc create LivrariaAPI binPath= "C:\deploy\backend\LivrariaCentral.API.exe" start= auto
    ```
 3. Inicie o serviço:
    ```cmd
    sc start LivrariaAPI
    ```
 4. Teste: Abra o navegador no servidor e acesse `http://localhost:5000/swagger`. Se abrir, o backend está vivo!

 #### B. Instalando o Frontend (IIS)

 1. Instale o **.NET Core Hosting Bundle** (procure no Google e instale no servidor). Ele configura o IIS para entender .NET.
 2. Instale o módulo **URL Rewrite** do IIS (Obrigatório para Blazor funcionar).
 3. Abra o **Gerenciador do IIS (Inetmgr)**.
 4. Botão direito em "Sites" -> "Adicionar Site":
    * **Nome do Site:** LivrariaWeb
    * **Caminho Físico:** `C:\deploy\frontend\wwwroot`
    * **Porta:** 80
 5. Acesse `http://localhost` e o site deve abrir!

 ---

 ### 🐧 Passo 4: Configuração no Linux (Nginx + Systemd)

 Se você usa Ubuntu, Debian ou CentOs, este é o caminho.

 #### A. Instalando a API (Systemd)

 1. Copie a pasta `backend` gerada para `/var/www/livraria-api`.
 2. **Importante:** Dê permissão de execução para o arquivo:
    ```bash
    sudo chmod +x /var/www/livraria-api/LivrariaCentral.API
    ```
 3. Crie o arquivo de serviço:
    ```bash
    sudo nano /etc/systemd/system/livraria-api.service
    ```
 4. Cole o conteúdo abaixo (Salvel com CTRL+O, Saia com CTRL+X):
    ```ini
    [Unit]
    Description=API Livraria .NET

    [Service]
    WorkingDirectory=/var/www/livraria-api
    ExecStart=/var/www/livraria-api/LivrariaCentral.API
    Restart=always
    # Reinicia o serviço automaticamente se ele cair
    RestartSec=10
    SyslogIdentifier=livraria-api
    User=www-data
    Environment=ASPNETCORE_ENVIRONMENT=Production
    Environment=ASPNETCORE_URLS=http://localhost:5000

    [Install]
    WantedBy=multi-user.target
    ```
 5. Ative e Inicie o serviço:
    ```bash
    sudo systemctl enable livraria-api.service
    sudo systemctl start livraria-api.service
    ```

 #### B. Instalando o Frontend (Nginx)

 1. Copie a pasta `frontend/wwwroot` para `/var/www/livraria-web`.
 2. Instale o Nginx: `sudo apt install nginx`.
 3. Configure o site:
    ```bash
    sudo nano /etc/nginx/sites-available/livraria
    ```
 4. Cole a configuração (Proxy Reverso):
    ```nginx
    server {
        listen 80;
        server_name _; # Aceita qualquer domínio ou IP

        # CONFIGURAÇÃO DO FRONTEND (Arquivos Estáticos)
        location / {
            root /var/www/livraria-web;
            index index.html;
            # O segredo do SPA: Se não achar o arquivo, manda pro index.html
            try_files $uri $uri/ /index.html =404;
        }

        # CONFIGURAÇÃO DO BACKEND (Repassa chamadas /api para a porta 5000)
        location /api {
            proxy_pass http://localhost:5000;
            proxy_http_version 1.1;
            proxy_set_header Upgrade $http_upgrade;
            proxy_set_header Connection keep-alive;
            proxy_set_header Host $host;
            proxy_cache_bypass $http_upgrade;
            proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
            proxy_set_header X-Forwarded-Proto $scheme;
        }
    }
    ```
 5. Ative o site e reinicie o Nginx:
    ```bash
    sudo ln -s /etc/nginx/sites-available/livraria /etc/nginx/sites-enabled/
    sudo nginx -t # Testa se a config está válida
    sudo service nginx restart
    ```

 **Parabéns!** 🎉
 Seu sistema Fullstack .NET agora está rodando em produção, seguro e performático. Você completou a jornada de Zero a Hero! 🚀