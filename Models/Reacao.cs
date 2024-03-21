namespace Models 
{

    public class Reacao
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descrição { get; set; }
        public ICollection<Gatilho>? Gatilhos { get; set; }
    }
}