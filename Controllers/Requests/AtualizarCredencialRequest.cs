
namespace Requests
{
    public class AtualizarCredencialRequest
    {
        internal Guid Id;

        public required string Senha { get; set; }
    }
}