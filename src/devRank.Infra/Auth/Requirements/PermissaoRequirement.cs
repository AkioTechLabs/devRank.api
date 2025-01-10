using Microsoft.AspNetCore.Authorization;

namespace devRank.Infra.Auth.Requirements;

public class PermissaoRequirement(string descricao) : IAuthorizationRequirement
{
    public string Descricao { get; private set; } = descricao;
}