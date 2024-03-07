namespace Models {

    public class Usuario
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string data_nascimento { get; set; }
        public required string Genero { get; set; }
        public required string Naturalidade { get; set; }
        public required string Telefone { get; set; }
         public required Credencial credencial { get; set; }
         
    }
}