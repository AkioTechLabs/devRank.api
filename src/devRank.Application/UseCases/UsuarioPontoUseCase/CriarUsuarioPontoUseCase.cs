using devRank.Application.Abstractions;
using devRank.Application.Requests.Usuario;
using devRank.Application.Requests.UsuarioPonto;
using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using FastResults.Results;
using MediatR;

namespace devRank.Application.UseCases.UsuarioPontoUseCase;

public class CriarUsuarioPontoUseCase(
    ISender sender,
    IUnitOfWork unitOfWork) :
    BaseUseCase<
        CriarUsuarioPontoRequest>(sender)
{
    public override async Task<BaseResult> Handle(
        CriarUsuarioPontoRequest request,
        CancellationToken cancellationToken)
    {
        var validacao = await Validar(request, cancellationToken);
        if (validacao.IsFailure)
        {
            return validacao;
        }

        UsuarioPonto usuarioPonto = new(
            request.Ponto,
            request.Tipo,
            request.Observacao,
            request.UsuarioId);

        return BaseResult.Sucess();
    }

    public async Task<BaseResult> Validar(
        CriarUsuarioPontoRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await sender.Send(new ObterUsuarioPorIdRequest(request.UsuarioId), cancellationToken);

        return usuario;
    }
}