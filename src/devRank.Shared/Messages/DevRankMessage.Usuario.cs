namespace devRank.Shared.Messages;

public partial class DevRankMessage
{
    public class Usuario
    {
        public static string EmailJaCadastrado => "Este e-mail já está cadastrado. Por favor, utilize outro endereço de e-mail ou recupere sua senha.";
        public static string UsuarioInvalido => "Usuario ou Senha está inválido!";
        public static string RefreshTokenInvalido => "Resfresh Token está inválido ou fora do tempo, faça login novamente!";
        public static string UsuarioNaoPodeSerAvaliado => "Usuario não pode ser avaliado!";
    }
}