namespace Models {

    public class Credencial
    {
        public Guid Id { get; set; }
        public required string email { get; set; }
        public required string senha { get; set; }
    
    }
}