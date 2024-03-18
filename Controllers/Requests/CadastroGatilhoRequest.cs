namespace Requests
{
    public class CadastroGatilhoRequest
    {
        public required string Motivo { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdReacao { get; set; }
    }
}