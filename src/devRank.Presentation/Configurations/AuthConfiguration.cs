using devRank.Presentation.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace devRank.Presentation.Configurations;

public static class AuthConfiguration
{
    public static IServiceCollection AdicionarAutentificacao(this IServiceCollection services)
    {
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();

        services.ConfigureOptions<JwtSetupOptions>();
        services.ConfigureOptions<JwtBearerSetupOptions>();

        return services;

        return services;
    }
}