using devRank.Domain.Contracts.Repositories;
using devRank.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace devRank.Presentation.Configurations;

public static class BancoDeDadosConfiguration
{
    public static IServiceCollection AdicionarBancoDeDados(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IUnitOfWork, DevRankContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));
        services.AddHostedService<MigrationsRunner<DevRankContext>>();

        return services;
    }
}