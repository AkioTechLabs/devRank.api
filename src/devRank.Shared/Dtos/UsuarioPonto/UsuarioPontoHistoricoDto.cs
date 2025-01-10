using devRank.Shared.Enums.Usuario;

namespace devRank.Shared.Dtos.UsuarioPonto;

public record UsuarioPontoHistoricoDto(
    long Id,
    string Observacao,
    int Ponto,
    int Movimento,
    TipoPonto Tipo,
    string TipoDescricao,
    DateTime Data);