using Microsoft.EntityFrameworkCore;
using TestWebApplication.Application.Interfaces;
using TestWebApplication.Application.Services;
using TestWebApplication.Infrastructure.Persistence.Common;
using TestWebApplication.Infrastructure.Persistence.Repositories;

namespace TestWebApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        // Add services to the container.
        // Configure EF Core with SQL Server
        builder.Services.AddDbContext<PostgresApplicationDbContext>(dbContextOptions =>
        {
            dbContextOptions.EnableDetailedErrors();
            dbContextOptions.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        // Register Repositories and Services for dependency injection
        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<ICheckActivityService, CheckActivityService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PostgresApplicationDbContext>();
                if (context.Database.EnsureCreated())
                {
                    using StreamReader reader = new(@"Infrastructure/Persistence/Common/SeedDatabase.sql");
                    var text = reader.ReadToEnd();
                    context.Database.BeginTransactionAsync();
                    context.Database.ExecuteSqlRawAsync(text);
                    context.Database.CommitTransactionAsync();
                    context.Database.Migrate();
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
