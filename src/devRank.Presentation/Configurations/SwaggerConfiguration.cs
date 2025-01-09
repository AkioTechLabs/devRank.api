using System.Reflection;
using Microsoft.OpenApi.Models;

namespace devRank.Presentation.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AdicionarSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DevRank - Sistema para fazer um rankeamento de pessoas.",
                Version = "v1",
                Description = "API para gerenciar potuação para pessoas forma eficiente e organizada.",
                Contact = new OpenApiContact 
                { 
                    Name = "Akio Serizawa"
                },
                License = new OpenApiLicense
                {
                    Name = "Licença MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });
            
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            
            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xml));
        });
        
        return services;
    }
    
    public static void UseSwaggerDocumentacao(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}