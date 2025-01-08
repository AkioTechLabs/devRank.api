namespace devRank.Shared.Messages;

public partial class DevRankMessage
{
    public class Comum
    {
        public static string NenhumRegistroEncontrado => "Nenhum registro localizado!";
        public static string RegistroInseridoComSucesso => "Registro inserido com sucesso!";
        public static string RegistroAtualizadoComSucesso => "Registro atualizado com sucesso!";
        public static string CampoObrigatorio(string campo) => $"{campo} é obrigatório!";
        public static string LimiteDeCaracteres(int limiteMinimo, int limiteMaximo) =>
            $"O tamanho mínimo é de {limiteMinimo} e máximo de {limiteMaximo} caracteres!";
    }
}