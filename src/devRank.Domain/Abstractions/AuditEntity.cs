namespace Nature.Domain.Abstractions;

public abstract class AuditEntity : Entity
{
    #region Properties

    public DateTime DataCriacao { get; private set; } = DateTime.Now;
    public DateTime? DataAlteracao { get; private set; }

    #endregion Properties

    #region Methods

    protected void AtualizarData()
    {
        DataAlteracao = DateTime.Now;
    }

    #endregion Methods
}