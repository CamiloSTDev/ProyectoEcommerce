using Application.Interfaces;
using Application.Settings;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Handlers;
using Infrastructure.Services;
using Application.Validators;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Configuration.AddEnvironmentVariables();

//JWT auth
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!))
        };
    });

builder.Services.Configure<JwtSettings>(options =>
{
    options.SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
    options.Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
    options.Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
});

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// MediatR
builder.Services.AddMediatR(typeof(RegisterUserHandler).Assembly);
builder.Services.AddMediatR(typeof(LoginUserHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);
builder.Services.AddMediatR(typeof(GetInventoryByIdHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateInventoryHandler).Assembly);

// FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(RegisterCommandValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(UpdateInventoryValidators).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetByIdInventoryValidator).Assembly);

//Repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

//servicios de dominio
builder.Services.AddScoped<IUserAuthService, UserAuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<GetAllProductsHandler>();
builder.Services.AddScoped<GetAllInventoryHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "Funciona la Api!").AllowAnonymous();
app.MapControllers().RequireAuthorization();

app.Run();