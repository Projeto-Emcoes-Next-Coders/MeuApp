using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
	public class Cadastro 
	{
		public required Usuario Usuario { get; set; }
		public required Credencial Credencial { get; set; }
	}

	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private static List<Usuario> DbUsuario = new List<Usuario>();
		private static List<Credencial> DbCredencial = new List<Credencial>();

		[HttpPost]
		public ActionResult Cadastrar([FromBody] Cadastro cadastro)
		{
			// Será reemplementado com EF.
			cadastro.Usuario.Id = Guid.NewGuid();
			cadastro.Credencial.Id = Guid.NewGuid();

			DbUsuario.Add(cadastro.Usuario);
			DbCredencial.Add(cadastro.Credencial);
			// Fim.

			return CreatedAtAction(nameof(ObterPorId), new { id = cadastro.Usuario.Id }, cadastro.Usuario);
		}

		[HttpGet("{id}")]
		public ActionResult<Usuario> ObterPorId(Guid Id)
		{
			// Será reemplementado com EF.
			Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == Id);
			// Fim.

			if(usuario == null) 
			{
				return NotFound();
			}

			return Ok(usuario);
		}

		[HttpPut("{id}")]
		public ActionResult<string> AtualizarPorId(Guid id, [FromBody] Usuario usuarioComDadosAtualizados)
		{
			// Será reemplementado com EF.
			Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == id);
			usuario = usuarioComDadosAtualizados;
			// Fim.

			if (usuario == null)
			{
				return NotFound();
			}

			return Ok("Usuario não encontrado.");
		}

		[HttpDelete("{id}")]
		public ActionResult<string> AtualizarPorId(Guid id)
		{
			// Será reemplementado com EF.
			Usuario? usuario = DbUsuario.FirstOrDefault(u => u.Id == id);
			// Fim.

			if (usuario == null)
			{
				return NotFound();
			}

			// Será reemplementado com EF.
			DbUsuario.Remove(usuario);
			// Fim.
				
			return Ok("Usuario não encontrado.");
		}
	}
}
