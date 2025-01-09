using devRank.Shared.Messages;
using FluentValidation;

namespace devRank.Domain.Validators.Usuario;

public class UsuarioValidator : AbstractValidator<Entities.Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(ur => ur.Nome)
            .Length(1, 250)
            .WithMessage(DevRankMessage.Comum.TamanhoDiferente(1, 250));

        RuleFor(ur => ur.Email)
            .NotEmpty()
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio)
            .EmailAddress()
            .WithMessage(DevRankMessage.Comum.EmailInvalido);

        RuleFor(ur => ur.Senha)
            .NotEmpty()
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);
    }
}