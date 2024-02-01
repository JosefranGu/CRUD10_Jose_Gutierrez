using Microsoft.EntityFrameworkCore;
using TicketMicroservice.DataAccess;
using TicketMicroservice.ApplicationServices;
using Serilog;
using Serilog.Sinks.MySQL;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TicketMicroservice.Test;
using Microsoft.EntityFrameworkCore.SqlServer;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TicketMicroservice.Web;
using TicketMicroservice.DataAccess.Config;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Obtener la configuración a través de la inyección de dependencias
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tickets API", Version = "v1" });
});

// Add Jwt Token Validation
builder.Services.Configure<JwtTokenValidationSettings>(builder.Configuration.GetSection("JwtTokenValidationSettings"));

var tokenValidationSettings = builder.Configuration.GetSection("JwtTokenValidationSettings").Get<JwtTokenValidationSettings>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = tokenValidationSettings.ValidIssuer,
            ValidateAudience = true,
            ValidAudience = tokenValidationSettings.ValidAudience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenValidationSettings.SecretKey)),
            ValidateIssuerSigningKey = true,
        };
    });

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// Configurar DbContext
builder.Services.AddDbContext<TicketDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("TicketDatabase")));

builder.Services.AddDbContext<TicketDbContextInMemory>(options =>
    options.UseInMemoryDatabase("TicketInMemoryDatabase"));

// Configurar Serilog con el sink MySQL
Log.Logger = new LoggerConfiguration()
    .WriteTo.MySQL("YourMySqlConnectionHere") // Ajusta la cadena de conexión MySQL
    .CreateLogger();

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.InitDb();
app.UseHttpsRedirection();
app.UseAuthorization(); // Solo necesitas una llamada a UseAuthorization()
app.MapControllers();
app.Run();
