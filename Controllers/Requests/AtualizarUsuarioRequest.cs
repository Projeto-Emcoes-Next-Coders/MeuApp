namespace Requests
{
    public class AtualizarUsuarioRequest
    {
        public required Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required DateOnly DataNascimento { get; set; }
        public required string Genero { get; set; }
        public required string Naturalidade { get; set; }
        public required string Telefone { get; set; }
    }
}