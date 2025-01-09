using devRank.Domain.Abstractions;

namespace devRank.Domain.Entities;

public sealed class Permissao() : Entity
{
    #region Properties

    public string Descricao { get; private set; } = string.Empty;

    public ICollection<PerfilPermissao> PerfilPermissao { get; set; } = [];

    #endregion  Properties

    #region Constructors

    public Permissao(string descricao) : this()
    {
        Descricao = descricao;
    }

    #endregion Constructors

    #region Methods

    protected override void Validar()
    {
    }

    #endregion Methods
}