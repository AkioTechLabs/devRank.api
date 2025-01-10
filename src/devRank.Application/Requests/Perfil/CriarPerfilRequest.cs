using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Perfil;
using devRank.Shared.Dtos.Perfil;

namespace devRank.Application.Requests.Perfil;

public record CriarPerfilRequest(
    string Descricao,
    List<CriarPerfilPermissao> PerfilPermissao) : IRequestUseCase<PerfilResponse>;

public record CriarPerfilPermissao(long IdPermissao);