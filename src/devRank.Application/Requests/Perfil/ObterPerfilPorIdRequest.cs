using devRank.Application.Abstractions.Contracts;

namespace devRank.Application.Requests.Perfil;

public record ObterPerfilPorIdRequest(long Id) : IRequestUseCase<PerfilResponse>;