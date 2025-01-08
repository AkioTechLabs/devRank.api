using System.Net;
using FastResults.Enums;
using FastResults.Errors;

namespace devRank.Shared.Errors;

public partial class DevRankError
{
    public class Comum
    {
        public static Error ErroInterno => new(
            HttpStatusCode.InternalServerError,
            "Erro interno, contate o suporte!",
            TypeError.InternalError);

        public static Error AcessoNegado => new(
            HttpStatusCode.Unauthorized,
            "Acesso negado. O usuário não tem permissão para essa ação.",
            TypeError.Unauthorized);

        public static Error Validacao(string mensagem) => new(
            HttpStatusCode.BadRequest,
            mensagem,
            TypeError.Validation);
    }
}