using devRank.Application.Abstractions;
using devRank.Application.Requests.Perfil;
using devRank.Application.Responses.Perfil;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.PerfilUseCase;

public class ObterPerfilPorIdUseCase(
    ISender sender,
    IPerfilRepository perfilRepository) :
    BaseUseCase<
        ObterPerfilPorIdRequest,
        PerfilResponse>(sender)
{
    public override async Task<BaseResult<PerfilResponse>> Handle(
        ObterPerfilPorIdRequest request,
        CancellationToken cancellationToken)
    {
        var perfil = await perfilRepository.ObterPorIdDependencias(request.Id, cancellationToken);
        if (perfil is null)
        {
            return BaseResultExtension<PerfilResponse>.NenhumRegistro;
        }

        return perfil.Adapt<PerfilResponse>();
    }
}