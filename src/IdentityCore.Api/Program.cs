using DotNetEnv;
using IdentityCore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = new NpgsqlConnectionStringBuilder
{
    Host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost",
    Port = int.Parse(Environment.GetEnvironmentVariable("POSTGRES_PORT")!),
    Database = Environment.GetEnvironmentVariable("POSTGRES_DB"),
    Username = Environment.GetEnvironmentVariable("POSTGRES_USER"),
    Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")
}.ConnectionString;

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));