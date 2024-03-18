namespace Requests
{
    public class CadastroUsuarioRequest
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required DateOnly DataNascimento { get; set; }
        public required string Genero { get; set; }
        public required string Naturalidade { get; set; }
        public required string Telefone { get; set; }
        public required CadastroCredencialRequest Credencial { get; set; }
    }
}