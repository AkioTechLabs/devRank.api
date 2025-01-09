using devRank.Shared.Messages;
using FastResults.Results;

namespace devRank.Shared.Extensions;

public static class BaseResultExtension<TResult>
{
    public static BaseResult<TResult> NenhumRegistro =>
        BaseResult.Failure<TResult>(DevRankMessage.Comum.NenhumRegistroLocalizado);
}