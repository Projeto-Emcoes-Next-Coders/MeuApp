namespace Responses 
{
    public class CadastroGatilhoResponse
    {
        public Guid Id { get; set; }
        public required string Motivo { get; set; }
        public Guid IdReacao { get; set; }
    }
}