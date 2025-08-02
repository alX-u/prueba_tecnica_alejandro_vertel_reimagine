using AlejandroVertelPruebaReImagine.Data;
using AlejandroVertelPruebaReImagine.Repositories;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;
using AlejandroVertelPruebaTecnica.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTRA EL REPOSITORIO AQUÍ
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UsuariosMapper>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
