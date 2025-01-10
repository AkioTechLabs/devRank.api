namespace devRank.Application.Responses.UsuarioPonto;

public record UsuarioPontoResponse(
    long UsuarioId,
    string Nome,
    int Pontos,
    int Trofeus);