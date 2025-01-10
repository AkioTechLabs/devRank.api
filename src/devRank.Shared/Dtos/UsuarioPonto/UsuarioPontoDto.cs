namespace devRank.Shared.Dtos.UsuarioPonto;

public record UsuarioPontoDto(
    long UsuarioId,
    string Nome,
    int Pontos,
    int Trofeus)
{
    public int Pontos { get; private set; } = Pontos;

    public void ValidarPonto()
    {
        Pontos = Pontos > 0 
            ? Pontos 
            : 0;
    }
};