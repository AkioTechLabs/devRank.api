using devRank.Domain.Entities;
using devRank.Shared.Messages;
using FluentValidation;

namespace devRank.Domain.Validators.Usuario;

public class UsuarioPontoValidator : AbstractValidator<UsuarioPonto>
{
    public UsuarioPontoValidator()
    {
        RuleFor(up => up.UsuarioId)
            .GreaterThan(0)
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);

        RuleFor(up => up.Ponto)
            .GreaterThan(0)
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);

        RuleFor(up => up.Observacao)
            .Length(1, 1000)
            .WithMessage(DevRankMessage.Comum.TamanhoDiferente(1, 1000));
    }
}