using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Requests;
using Responses;

namespace Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CredencialController : ControllerBase
  {
    private readonly DbEmoday Contexto = new DbEmoday();

    [HttpPatch("{idUsuario}")]
    public ActionResult AtualizarPorId(Guid idUsuario, [FromBody] AtualizarCredencialRequest credencialAtualizada)
    {
      try
      {
        var credencial = Contexto.Credencials.Find(idUsuario);

        if (credencial == null)
        {
          return BadRequest();
        }

        credencial.Senha = credencialAtualizada.Senha;

        Contexto.Credencials.Entry(credencial).State = EntityState.Modified;
        Contexto.SaveChanges();

        return NoContent();
      }
      catch
      {
        return StatusCode(500, "O problema foi sério, mas a gente passa bem!");
      }

    }
  }
}
