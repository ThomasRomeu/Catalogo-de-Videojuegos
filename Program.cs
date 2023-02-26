using primerParcial.Servicios;
using Microsoft.EntityFrameworkCore;
using primerParcial.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<VideojuegosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));
builder.Services.AddTransient<IVideojuegoServicio,VideojuegoServicio>();
builder.Services.AddTransient<IPlataformaServicio,PlataformaServicio>();
builder.Services.AddTransient<IEmpresaServicio,EmpresaServicio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
