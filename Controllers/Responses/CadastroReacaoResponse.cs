namespace Responses 
{
    public class CadastroReacaoResponse
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }   
        public required string Descrição { get; set; }
    
    }
}