using devRank.Shared.Dtos.Auth;
using Microsoft.Extensions.Options;

namespace devRank.Presentation.Options;

public class JwtSetupOptions(IConfiguration configuration) : IConfigureOptions<AuthConfiguracaoDto>
{
    private const string SectionName = "Jwt";

    public void Configure(AuthConfiguracaoDto options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}