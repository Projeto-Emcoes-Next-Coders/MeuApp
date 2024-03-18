using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CredencialController : ControllerBase
  {
    private readonly DbEmoday Contexto = new DbEmoday();

    [HttpPatch("{id}")]
    public ActionResult<string> AtualizarPorId(Guid Id, [FromBody] Credencial CredencialAtualizada)
    {

      try
      {
        var Credencial = Contexto.Credencials.Find(Id);
        // var produto = Contexto.Produtos.FirstOrDefault(p => p.Id == id);

        if ( Credencial == null || Credencial.Id != CredencialAtualizada.Id)
        {
          return BadRequest();
        }

        Contexto.Credencials.Entry(CredencialAtualizada).State = EntityState.Modified;
        Contexto.SaveChanges();

        // return NoContent();
        return Ok(CredencialAtualizada);
      }
      catch
      {
        return StatusCode(500, "O problema foi sério, mas a gente passa bem!");
      }

    }
  }
}
