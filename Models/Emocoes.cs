namespace Models {

    public class Emocoes
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descrição { get; set; }
    }
}