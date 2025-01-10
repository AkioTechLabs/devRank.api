using devRank.Shared.Enums.Usuario;

namespace devRank.Application.Responses.UsuarioPonto;

public record UsuarioPontoCompletoResponse(
    UsuarioPontoResponse Usuario,
    List<UsuarioPontoHistoricoResponse> Historico);

public record UsuarioPontoHistoricoResponse(
    long Id,
    string Observacao,
    int Ponto,
    int Movimento,
    TipoPonto Tipo,
    string TipoDescricao,
    DateTime Data);