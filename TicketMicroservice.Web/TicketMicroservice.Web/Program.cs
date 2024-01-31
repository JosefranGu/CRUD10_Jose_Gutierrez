using Microsoft.EntityFrameworkCore;
using TicketMicroservice.DataAccess;
using TicketMicroservice.ApplicationServices;
using TicketMicroservice.Test;
using Serilog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Obtener la configuraci�n a trav�s de la inyecci�n de dependencias
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tickets API", Version = "v1" });
});

// Configure method



// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<TicketDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("TicketDatabase")));

builder.Services.AddDbContext<TicketDbContextInMemory>(options =>
        options.UseInMemoryDatabase("TicketInMemoryDatabase"));


Log.Logger = new LoggerConfiguration()
      .WriteTo.MySQL("YourMySqlConnectionHere") // Ajusta la cadena de conexi�n MySQL
      .CreateLogger();

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
