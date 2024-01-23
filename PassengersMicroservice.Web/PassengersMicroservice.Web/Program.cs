using Microsoft.EntityFrameworkCore;
using PassengersMicroservice.DataAccess;
using Passengers.ApplicationServices;
using PassengersMicroservice.Tests;
using Serilog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Obtener la configuración a través de la inyección de dependencias
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Passengers API", Version = "v1" });
});

// Configure method



// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<PassengersDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("PassengersDatabase")));

builder.Services.AddDbContext<PassengersDbContextInMemory>(options =>
        options.UseInMemoryDatabase("PassengersInMemoryDatabase"));


Log.Logger = new LoggerConfiguration()
      .WriteTo.MySQL("YourMySqlConnectionHere") // Ajusta la cadena de conexión MySQL
      .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>loggingBuilder.AddSerilog());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Passengers API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
