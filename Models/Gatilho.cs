namespace Models 
{
    public class Gatilho
    {
        public Guid Id { get; set; }
        public required string Motivo { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public Guid IdReacao { get; set; }
        public Reacao? Reacao { get; set; }
        
    }
}