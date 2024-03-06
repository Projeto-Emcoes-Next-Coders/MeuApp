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
        public Usuario Cadastrar([FromBody] Usuario usuario) {
           
            usuario.Id = Guid.NewGuid();

            DbUsuario.Add(usuario);

            return usuario;

        }


        [HttpGet]

        public IEnumerable<Usuario> ObterTodos(){

            return  DbUsuario;

        }


        [HttpGet("{Id}")]

        public Usuario ObterPorId(Guid id)
        {
            Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == id);

            return usuario;

        }


         [HttpPatch("{Id}")]

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


         [HttpDelete("{Id}")]

        public string AtualizarPorId(Guid id)
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
