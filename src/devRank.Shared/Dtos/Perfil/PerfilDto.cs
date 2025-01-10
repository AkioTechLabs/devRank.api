namespace devRank.Shared.Dtos.Perfil;

public record PerfilDto(
    long Id,
    string Descricao,
    List<PerfilPermissaoDto> Permissoes);
    
public record PerfilPermissaoDto(
    long PermissaoId,
    string PermissaoDescricao);