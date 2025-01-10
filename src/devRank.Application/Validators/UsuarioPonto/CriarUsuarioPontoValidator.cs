using devRank.Application.Requests.UsuarioPonto;
using devRank.Shared.Messages;
using FluentValidation;

namespace devRank.Application.Validators.UsuarioPonto;

public class CriarUsuarioPontoValidator : AbstractValidator<CriarUsuarioPontoRequest>
{
    public CriarUsuarioPontoValidator()
    {
        RuleFor(up => up.UsuarioId)
            .GreaterThan(0)
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);

        RuleFor(up => up.Observacao)
            .Length(1, 1000)
            .WithMessage(DevRankMessage.Comum.TamanhoDiferente(1, 1000));
    }
}