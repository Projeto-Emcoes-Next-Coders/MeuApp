using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
          private static List<Usuario> DbUsuario = new List<Usuario>();

        [HttpPost]
        public ActionResult<string> Cadastrar([FromBody] Usuario usuario) 
        {
            usuario.Id = Guid.NewGuid();

            DbUsuario.Add(usuario);

            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]

        public Usuario ObterPorId(Guid Id)
        {
            Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == Id);

            return usuario;
        }

         [HttpPut("{id}")]

        public string AtualizarPorId(Guid id, [FromBody] Usuario usuarioComDadosAtualizados )
        {
            Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == id);
            usuario = usuarioComDadosAtualizados;

            if(usuario != null)
            {
              return "Atualizado";   
            }

            else 
             {
                return "Usuario não encontrado.";  
             }
        }

         [HttpDelete("{id}")]

        public ActionResult<string> AtualizarPorId(Guid id)
        {
            Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == id);
            DbUsuario.Remove(usuario);

            
            if(usuario != null)
            {
              return "Usuario Deletado.";  
            }

            else 
             {
                return "Usuario não encontrado.";  
             }
        }
    }
}
