using System.Text;
using devRank.Shared.Dtos.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace devRank.Presentation.Options;

public class JwtBearerSetupOptions(IOptions<AuthConfiguracaoDto> options) : IPostConfigureOptions<JwtBearerOptions>
{
    private readonly AuthConfiguracaoDto _options = options.Value;

    public void PostConfigure(string? name, JwtBearerOptions optionsSetup)
    {
        optionsSetup.TokenValidationParameters.ValidateIssuer = true;
        optionsSetup.TokenValidationParameters.ValidIssuer = "TmF0dXJlQnJhYm8";
        optionsSetup.TokenValidationParameters.ValidateAudience = true;
        optionsSetup.TokenValidationParameters.ValidAudience = "https://github.com/OrganizacaoTesteSum/devRank.api";
        optionsSetup.TokenValidationParameters.ValidateLifetime = true;
        optionsSetup.TokenValidationParameters.ValidateIssuerSigningKey = true;
        optionsSetup.TokenValidationParameters.IssuerSigningKey =
            new SymmetricSecurityKey("TmFvQWRpYW50YU5hb1NlVGFOb0Rldk1ldUlybWFv"u8.ToArray());
    }
}