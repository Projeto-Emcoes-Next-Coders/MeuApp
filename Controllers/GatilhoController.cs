using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatilhoController : ControllerBase
    {
           private static List<Emocoes> DbEmocoes = new List<Emocoes>();

            [HttpPost]
        public Emocoes InserirGatilho([FromBody] Emocoes emocoes) {
           
            emocoes.Id = Guid.NewGuid();

            DbEmocoes.Add(emocoes);

            return emocoes;
        }
    }
}
