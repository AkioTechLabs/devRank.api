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
        optionsSetup.TokenValidationParameters.ValidIssuer = _options.KeyIssuer;
        optionsSetup.TokenValidationParameters.ValidateAudience = true;
        optionsSetup.TokenValidationParameters.ValidAudience = _options.KeyAudience;
        optionsSetup.TokenValidationParameters.ValidateLifetime = true;
        optionsSetup.TokenValidationParameters.ValidateIssuerSigningKey = true;
        optionsSetup.TokenValidationParameters.IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes("TmFvQWRpYW50YU5hb1NlVGFOb0Rldk1ldUlybWFv"));
    }
}