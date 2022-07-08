using Banco.Core.Interfaces;
using Banco.Core.Interfaces.Services;
using Banco.DataAccess;
using Banco.Services;
using MyMusic.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string Politica = "politica_cors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Politica,
                      bldr =>
                      {
                          bldr.WithOrigins(builder.Configuration.GetSection("ApplicationSettings:Client_Url").Value.Split(','))
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

string dbPath = String.Format(builder.Configuration.GetConnectionString("Default"), $"{builder.Environment.ContentRootPath}data\\db_banco.mdf");

builder.Services.AddDbContext<BancoDbContext>(options => options.UseSqlServer(dbPath, x =>
{
    x.MigrationsAssembly("Banco.DataAccess");
    x.EnableRetryOnFailure();
}));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IClientesService, ClientesService>();
builder.Services.AddTransient<ICuentasService, CuentasService>();
builder.Services.AddTransient<IMovimientosService, MovimientosService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(Politica);

app.UseAuthorization();

app.MapControllers();

app.Run();
