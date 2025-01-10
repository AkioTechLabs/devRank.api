using System.Security.Claims;
using devRank.Domain.Contracts.Repositories;
using devRank.Infra.Auth.Requirements;
using devRank.Shared.Dtos.Perfil;
using devRank.Shared.Enums.Permissao;
using devRank.Shared.Errors;
using Microsoft.AspNetCore.Authorization;

namespace devRank.Infra.Auth.Handlers;

public class AuthPermissaoHandler(IPerfilRepository perfilRepository) : AuthorizationHandler<PermissaoRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissaoRequirement requirement)
    {
        var idPerfil = context.User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.Role);
        if (idPerfil is null)
        {
            GerarErro(context);
        }

        var perfil =
            await perfilRepository.ObterPorIdDependencias(Convert.ToInt64(idPerfil?.Value), CancellationToken.None);
        if (PerfilValido(perfil, context, requirement))
        {
            context.Succeed(requirement);
        }
    }

    private bool PerfilValido(
        PerfilDto? perfil,
        AuthorizationHandlerContext context,
        PermissaoRequirement requirement)
    {
        var permissao = Enum.Parse<NivelPermissao>(requirement.Descricao);
        if (perfil is null || perfil.Permissoes.All(pp => pp.PermissaoId != (int)permissao))
        {
            GerarErro(context);
        }

        return true;
    }

    private void GerarErro(AuthorizationHandlerContext context)
    {
        context.Fail();
        throw new UnauthorizedAccessException(DevRankError.Comum.AcessoNegado.Message);
    }
}