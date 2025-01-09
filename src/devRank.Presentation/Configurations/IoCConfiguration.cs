using devRank.Application;
using devRank.Application.Abstractions.Contracts;
using devRank.Domain;
using devRank.Domain.Abstractions.Contracts;
using devRank.Infra;

namespace devRank.Presentation.Configurations;

public static class IoCConfiguration
{
    public static IServiceCollection AdicionarIoC(this IServiceCollection services)
    {
        AdicionarService(services);
        AdicionarRepository(services);
        AdicionarInfra(services);

        return services;
    }

    private static void AdicionarService(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(ApplicationAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    private static void AdicionarRepository(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(DomainAssembly.Assembly, InfrastructureAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
    
    private static void AdicionarInfra(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(DomainAssembly.Assembly, InfrastructureAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IInfraestructure>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}