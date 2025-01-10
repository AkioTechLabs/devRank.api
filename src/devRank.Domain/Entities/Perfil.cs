using devRank.Domain.Abstractions;

namespace devRank.Domain.Entities;

public sealed class Perfil() : AuditEntity
{
    #region Properties

    public string Descricao { get; private set; } = string.Empty;

    #region Ref. Foreing Key

    public ICollection<Usuario> Usuario { get; set; } = [];
    public ICollection<PerfilPermissao> PerfilPermissao { get; set; } = [];

    #endregion Ref. Foreing Key

    #endregion Properties

    #region Constructors

    public Perfil(
        string descricao) : this()
    {
        Descricao = descricao;
    }

    #endregion Constructors

    #region Methods

    protected override void Validar()
    {
    }

    public void AtribuirPermissao(List<long> ids)
    {
        foreach (var id in ids)
        {
            PerfilPermissao.Add(new (id));
        }
    }

    #endregion Methods
}