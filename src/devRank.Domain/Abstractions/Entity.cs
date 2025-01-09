using devRank.Shared.Errors;
using devRank.Shared.Expections;
using FluentValidation;

namespace devRank.Domain.Abstractions;

public abstract class Entity
{
    #region Properties

    public long Id { get; private set; }

    #endregion Properties

    #region Methods

    protected abstract void Validar();

    protected static void ValidarInternal<TValidate, TEntity>(
        TValidate validador,
        TEntity entity)
        where TEntity : Entity
        where TValidate : IValidator<TEntity>
    {
        var result = validador.Validate(entity);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .ConvertAll(e => DevRankError.Comum.Validacao(e.ErrorMessage));

            throw new ValidacaoExpection(errors);
        }
    }

    #endregion Methods
}