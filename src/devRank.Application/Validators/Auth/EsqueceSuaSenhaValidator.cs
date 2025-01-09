using devRank.Application.Requests.Auth;
using devRank.Shared.Messages;
using FluentValidation;

namespace devRank.Application.Validators.Auth;

public class EsqueceSuaSenhaValidator
    : AbstractValidator<EsqueceSuaSenhaRequest>
{
    public EsqueceSuaSenhaValidator()
    {
        RuleFor(es => es.Id)
            .GreaterThan(0)
            .WithMessage(DevRankMessage.Comum.CampoObrigatorio);

        RuleFor(es => es.Senha)
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
    }
}