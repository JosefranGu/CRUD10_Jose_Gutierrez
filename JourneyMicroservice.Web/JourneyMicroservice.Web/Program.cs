using JourneyMicroservice.ApplicationServices;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using JourneyMicroservice.Test;
using AutoMapper;
using JourneyMicroservice.DataAccess;
using Serilog.Sinks.MySQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Journey Microservice API", Version = "v1" });
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<JourneyDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("JourneyDatabase")));

// Note: UseInMemoryDatabase is correct, no need to change it.
builder.Services.AddDbContext<JourneyDbContextInMemory>(options =>
    options.UseInMemoryDatabase("JourneyInMemoryDatabase"));

Log.Logger = new LoggerConfiguration()
    .WriteTo.MySQL("YourMySqlConnectionHere") // Adjust the MySQL connection string
    .CreateLogger();

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Journey Microservice API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
