using BankCardService.Application.Interfaces;
using BankCardService.Application.Services;
using BankCardService.Infrastructure.Data;
using BankCardService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<BankCardDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("BankCardDb")
    )
);

// Dependency Injection
builder.Services.AddScoped<IBankCardRepository, BankCardRepository>();
builder.Services.AddScoped<IBankCardService, BankCardService.Application.Services.BankCardService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware pipeline
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
