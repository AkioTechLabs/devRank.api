using devRank.Application.Abstractions;
using devRank.Application.Requests.Perfil;
using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using devRank.Shared.Messages;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.PerfilUseCase;

public class CriarPerfilUseCase(
    ISender sender,
    IPerfilRepository perfilRepository,
    IPermissaoRepository permissaoRepository,
    IUnitOfWork unitOfWork) :
    BaseUseCase<
        CriarPerfilRequest,
        PerfilResponse>(sender)
{
    public override async Task<BaseResult<PerfilResponse>> Handle(
        CriarPerfilRequest request,
        CancellationToken cancellationToken)
    {
        var validacao = await Validar(request, cancellationToken);
        if (validacao.IsFailure)
        {
            return BaseResult.Failure<PerfilResponse>(validacao.Error);
        }

        var perfil = request.Adapt<Perfil>();

        perfilRepository.Inserir(perfil);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return perfil.Adapt<PerfilResponse>();
    }

    private async Task<BaseResult> Validar(
        CriarPerfilRequest request,
        CancellationToken cancellationToken)
    {
        var ids = request.PerfilPermissao
            .Select(x => x.IdPermissao)
            .ToList();
        var idsInexistentes = await permissaoRepository.ValidarExistentes(ids, cancellationToken);
        if (!idsInexistentes.Any())
        {
            return BaseResult.Sucess();
        }

        var validar = string.Empty;
        idsInexistentes.ForEach(id =>
        {
            validar += DevRankMessage.Comum.NaoPossuiId(nameof(Permissao), id) + Environment.NewLine;
        });

        return BaseResult.Failure(validar);
    }
}