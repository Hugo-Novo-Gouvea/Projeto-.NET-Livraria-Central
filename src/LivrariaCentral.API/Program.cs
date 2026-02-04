using LivrariaCentral.API.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

QuestPDF.Settings.License = LicenseType.Community;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Nível padrão geral
    .WriteTo.Console() // Mostra tudo no terminal também
    
    // ARQUIVO 1: O "Dedoduro" (Grava TUDO, inclusive queries do banco)
    .WriteTo.File("logs/completo/log-.txt", rollingInterval: RollingInterval.Day)
    
    // ARQUIVO 2: O "Gerencial" (Grava SÓ o que interessa, sem sujeira da Microsoft)
    .WriteTo.Logger(l => l
        .Filter.ByExcluding(e => e.Properties.ContainsKey("SourceContext") && 
                                (e.Properties["SourceContext"].ToString().Contains("Microsoft") || 
                                 e.Properties["SourceContext"].ToString().Contains("System")))
        .WriteTo.File("logs/resumo/log-.txt", rollingInterval: RollingInterval.Day))
    
    .CreateLogger();

try 
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

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

    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!); // <--- Exclamação aqui
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

    // --- 2. PIPELINE DE REQUISIÇÃO HTTP ---

    // Se estiver em ambiente de desenvolvimento, ativa o Swagger visual
    if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

    // Redireciona HTTP para HTTPS
    //app.UseHttpsRedirection();

    app.UseCors("AllowAll"); 

    app.UseAuthentication();
    app.UseAuthorization();

    // Mapeia os Controllers para as rotas da API
    app.MapControllers();

    // Roda a aplicação
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