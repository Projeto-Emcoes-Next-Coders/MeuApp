using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Requests;
using Responses;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatilhoController : ControllerBase
    {
        private readonly DbEmoday Contexto = new DbEmoday();

        [HttpPost]
        public ActionResult<CadastroGatilhoResponse> Cadastrar([FromBody] CadastroGatilhoRequest novoGatilho)
        {
            try
            {
                Gatilho gatilho = new Gatilho
                {
                    Motivo = novoGatilho.Motivo,
                    IdUsuario = novoGatilho.IdUsuario,
                    IdReacao = novoGatilho.IdReacao
                };

                Contexto.Gatilhos.Add(gatilho);
                Contexto.SaveChanges();

                return Created("ObterPeloId", new { Id = gatilho.Id, IdReacao = gatilho.IdReacao, Motivo = gatilho.Motivo });
            }
            catch
            {
                return StatusCode(500, "O problema foi sério, mas a gente passa bem!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ObterGatilhoResponse> ObterPorId(Guid id)
        {

            try
            {
                var gatilho = Contexto.Gatilhos.Find(id);
                // var produto = Contexto.Produtos.FirstOrDefault(p => p.Id == id);

                if ( gatilho == null)
                {
                    return BadRequest();
                }

                return Ok(
                    new
                    {
                        Motivo = gatilho.Motivo,
                        IdUsuario = gatilho.IdUsuario,
                        IdReacao = gatilho.IdReacao                        
                    }
                );
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
        }
    }
}