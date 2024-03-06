using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmocoesController : ControllerBase
    {

        
        private static List<Emocoes> DbEmocoes = new List<Emocoes>();

    
        [HttpGet]

        public IEnumerable<Emocoes> ObterTodos(){

            return  DbEmocoes;

          
        }
    }
}
