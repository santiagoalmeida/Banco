using Banco.Web.Models;
using Banco.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string urlSvc = builder.Configuration.GetValue<string>("WebAPIBaseUrl");

builder.Services.
    AddHttpClient<IServices<Cliente>, Services<Cliente>>(client =>
    {
        client.BaseAddress = new Uri(urlSvc + "Clientes/");
    });
builder.Services
    .AddHttpClient<IServices<Cuenta>, Services<Cuenta>>(client =>
    {
        client.BaseAddress = new Uri(urlSvc + "Cuentas/");
    });
builder.Services
    .AddHttpClient<IServices<Movimiento>, Services<Movimiento>>(client =>
    {
        client.BaseAddress = new Uri(urlSvc + "Movimientos/");
    });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
