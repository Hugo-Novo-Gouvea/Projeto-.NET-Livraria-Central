using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LivrariaCentral.Web;
using MudBlazor.Services; // Importante

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura o HttpClient para apontar para nossa API (Endereço Local)
// Nota: Vamos ajustar essa URL mais tarde quando rodarmos os dois juntos
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5239") });

// Adiciona os serviços do MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();
