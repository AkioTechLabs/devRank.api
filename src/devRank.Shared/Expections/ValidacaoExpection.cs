using FastResults.Errors;

namespace devRank.Shared.Expections;

public class ValidacaoExpection(List<Error> errors) : Exception
{
    #region Properties

    public List<Error> Errors { get; private set; } = errors;

    #endregion Properties

    public override string ToString()
    {
        return string.Join(Environment.NewLine, Errors.Select(error => error.Message));
    }
}