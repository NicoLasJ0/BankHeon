using HeonBankPrueba.Client;
using HeonBankPrueba.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<string>("apiUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<TipoIdentificacionService>();
builder.Services.AddScoped<CuentaBancariaService>();
builder.Services.AddScoped<TipoCuentaService>();
builder.Services.AddScoped<BancosService>();
builder.Services.AddScoped<TransaccionService>();
builder.Services.AddScoped<FormaPagoService>();
builder.Services.AddScoped<TipoTransaccionService>();

await builder.Build().RunAsync();
