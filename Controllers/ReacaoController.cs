using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReacaoController : ControllerBase
    {
    private readonly DbEmoday Contexto = new DbEmoday();
        
        [HttpGet]
         public ActionResult<IEnumerable<Usuario>> ObterLista()
        {
            try
            {
                var Reacao = Contexto.Reacaos.ToList();

                return Ok(Reacao);
            }
            catch
            {
                return StatusCode(500, "O problema foi sério, mas a gente passa bem!");
            }
        }
    }
}
