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