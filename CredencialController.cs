using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredencialController : ControllerBase
    {

              private static List<Usuario> DbUsuario = new List<Usuario>();

           [HttpPatch]
            public Usuario CadastrarCredencial([FromBody] Usuario usuario) {

            DbUsuario.Add(usuario);

            return usuario;

        }
    }
}
