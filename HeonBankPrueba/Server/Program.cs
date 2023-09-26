using HeonBankPrueba.Server.Services;
using HeonBankPrueba.Shared;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<CuentaBancariaService>();
builder.Services.AddScoped<TransaccionService>();
builder.Services.AddScoped<TipoIdentificacionService>();
builder.Services.AddScoped<BancosService>();
builder.Services.AddScoped<TipoCuentaService>();
builder.Services.AddScoped<TipoTransaccionService>();
builder.Services.AddScoped<FormaPagoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
