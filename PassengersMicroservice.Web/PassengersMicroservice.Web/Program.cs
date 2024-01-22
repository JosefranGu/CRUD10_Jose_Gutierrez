using Microsoft.EntityFrameworkCore;
using PassengersMicroservice.DataAccess;
using Passengers.ApplicationServices;

var builder = WebApplication.CreateBuilder(args);

// Obtener la configuración a través de la inyección de dependencias
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<PassengersDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("PassengersDatabase")));

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
