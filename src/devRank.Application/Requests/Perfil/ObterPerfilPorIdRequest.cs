using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Perfil;

namespace devRank.Application.Requests.Perfil;

public record ObterPerfilPorIdRequest(long Id) : IRequestUseCase<PerfilResponse>;