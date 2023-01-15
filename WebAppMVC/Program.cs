using BLL.Service;
using Data.DataContext;
using Data.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//agregar el servicio de conexion al datacontext
builder.Services.AddDbContext<MvcPruebasContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

//agregando los servicios hacia los metodos de la interfaz
builder.Services.AddScoped<IRepositorioGenerico<Balero>, BaleroRepositorio>();
builder.Services.AddScoped<IBaleroService, BaleroSerivicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
