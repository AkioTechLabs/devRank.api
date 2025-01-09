using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using devRank.Domain.Contracts.Infraestructures;
using devRank.Domain.Entities;
using devRank.Shared.Dtos.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace devRank.Infra.Auth;

public class AuthInfra(IOptions<AuthConfiguracaoDto> authConfiguracao) : IAuthInfra
{
    public TokenDto GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(authConfiguracao.Value.Key);
        var dataExpiracao = DateTime.UtcNow.AddDays(authConfiguracao.Value.DiasParaExpiracao);

        var tokenDescricao = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Role, usuario.PerfilId.ToString())
            }),
            Expires = dataExpiracao,
            Issuer = authConfiguracao.Value.KeyIssuer,
            Audience = authConfiguracao.Value.KeyAudience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescricao);
        var tokenGerado = tokenHandler.WriteToken(token);

        return new(
            tokenGerado,
            dataExpiracao,
            Guid.NewGuid());
    }
}