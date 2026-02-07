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