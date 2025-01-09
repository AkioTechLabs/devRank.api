using System.ComponentModel;

namespace devRank.Shared.Enums.Usuario;

public enum TipoPonto
{
    [Description("Aprovado em Pull Request")]
    AprovadoPullRequest = 1,

    [Description("Reprovado em Pull Request")]
    ReprovadoPullRequest = 2,

    [Description("Aprovado em Teste")]
    AprovadoTeste = 3,

    [Description("Reprovado em Teste")]
    ReprovadoTeste = 4,

    [Description("Pull Request demorado ou atraso na task")]
    PrDemoradoOuAtrasoTask = 5,

    [Description("Fora do padrão esperado")]
    ForaDoPadrao = 6,

    [Description("Contribuição ou colaboração com equipe")]
    Colaboracao = 7,

    [Description("Documentação")]
    Documentacao = 8,

    [Description("Execução rápida e eficiente (Fast Codes)")]
    FastCodes = 9,

    [Description("Falta de comunicação")]
    FaltaComunicao = 10,

    [Description("Reprovação repetida em mais de um pr")]
    ReprovacaoRepetidads = 11,

    [Description("Retrabalho sendo feito")]
    Retrabalho = 12
}
