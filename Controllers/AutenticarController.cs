using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly DbEmoday Contexto = new DbEmoday();

        [HttpPost]
        public ActionResult<dynamic> Autenticar([FromBody]Credencial credencial)
        {
            Usuario? usuario = DbEmoday.First(
                u =>
                    u.Email == credencial.Email
            )
        }

    }
}
