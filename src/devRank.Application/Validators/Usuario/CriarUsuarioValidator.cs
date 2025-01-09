using devRank.Application.Requests.Usuario;
using devRank.Shared.Messages;
using FluentValidation;

namespace devRank.Application.Validators.Usuario;

public class CriarUsuarioValidator : AbstractValidator<CriarUsuarioRequest>
{
    public CriarUsuarioValidator()
    {
        RuleFor(ur => ur.Nome)
            .NotEmpty()
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);

        RuleFor(ur => ur.Email)
            .EmailAddress()
            .WithMessage(DevRankMessage.Auth.EmailInvalido);

        RuleFor(ur => ur.Senha)
            .NotEmpty()
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio)
            .Length(8, 35)
            .WithMessage(DevRankMessage.Comum.TamanhoDiferente(8, 35))
            .Matches(@"[A-Z]")
            .WithMessage(DevRankMessage.Auth.Maiuscula)
            .Matches(@"[a-z]")
            .WithMessage(DevRankMessage.Auth.Minuscula)
            .Matches(@"[0-9]")
            .WithMessage(DevRankMessage.Auth.Numero)
            .Matches(@"[\W_]")
            .WithMessage(DevRankMessage.Auth.CaracteresEspecial);

        RuleFor(ur => ur.PerfilId)
            .GreaterThan(0)
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);
    }
}