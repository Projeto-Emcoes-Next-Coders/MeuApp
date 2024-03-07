using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredencialController : ControllerBase
    {
              private static List<Credencial> Dbcredencial = new List<Credencial>();

        [HttpPatch("{id}")]

        public string AtualizarPorId(Guid id, [FromBody] Credencial credencialComDadosAtualizados )
        {
            Credencial? credencial = Dbcredencial.FirstOrDefault(u => u.Id == id);
            credencial = credencialComDadosAtualizados;

            if(credencial != null)
            {
              return "Credencial Atualizada";   
            }

            else 
             {
                return "Credencial não encontrada.";  
             }
        }
    }
}
