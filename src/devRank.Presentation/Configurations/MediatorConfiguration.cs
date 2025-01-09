using devRank.Application;
using devRank.Application.Behaviors;
using FluentValidation;
using MediatR;

namespace devRank.Presentation.Configurations;

public static class MediatorConfiguration
{
    public static IServiceCollection AdicionarMediator(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(ApplicationAssembly.Assembly);
        });
        
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(ApplicationAssembly.Assembly);

        return services;
    }
}