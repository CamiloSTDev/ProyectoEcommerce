using Domain.Interfaces;
using Application.UseCases;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repositorio e inyección de casos de uso
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<GetAllProductsHandler>();
builder.Services.AddScoped<CreateProductHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();