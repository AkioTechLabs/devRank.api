using devRank.Application.Abstractions.Contracts;
using devRank.Shared.Dtos.Perfil;

namespace devRank.Application.Requests.Perfil;

public record CriarPerfilRequest(
    string Descricao,
    List<CriarPerfilPermissao> PerfilPermissao) : IRequestUseCase<PerfilResponse>;

public record CriarPerfilPermissao(long IdPermissao);