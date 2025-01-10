namespace devRank.Shared.Dtos.UsuarioPonto;

public record UsuarioPontoCompletoDto(
    UsuarioPontoDto Usuario,
    List<UsuarioPontoHistoricoDto> Historico);