using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace IdentityCore.Infrastructure.Persistence;

public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        Env.TraversePath().Load();

        var connectionString = new NpgsqlConnectionStringBuilder
        {
        Host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost",
        Port = int.Parse(Environment.GetEnvironmentVariable("POSTGRES_PORT")!),
        Database = Environment.GetEnvironmentVariable("POSTGRES_DB"),
        Username = Environment.GetEnvironmentVariable("POSTGRES_USER"),
        Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")
        }.ConnectionString;

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new AppDbContext(options);
    }
}