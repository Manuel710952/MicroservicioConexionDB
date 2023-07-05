using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddEndpointsApiExplorer();
//services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextAutor>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(typeof(Nuevo.Manejador).Assembly);
    });
//builder.Services.AddDbContext<ContextAutor>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));
//builder.Services.Adddef<ContextAutor>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContextAutor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
  //  app.UseSwagger();
  //  app.UseSwaggerUI();
}



app.MapControllers();

app.Run();
