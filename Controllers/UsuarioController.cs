using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Contexts;
using Models;
using Requests;
using Responses;

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
		private readonly DbEmoday Contexto = new DbEmoday();

		[HttpPost]
		public ActionResult<CadastroUsuarioResponse> Cadastrar([FromBody] CadastroUsuarioRequest cadastroUsuario)
		{
			try
            {
                Usuario usuario = new Usuario
                {
                    Nome = cadastroUsuario.Nome,
                    Sobrenome = cadastroUsuario.Sobrenome,
                    DataNascimento = cadastroUsuario.DataNascimento,
                    Genero = cadastroUsuario.Genero,
                    Naturalidade = cadastroUsuario.Naturalidade,
                    Telefone = cadastroUsuario.Telefone
                };

                Credencial credencial = new Credencial
                {
                    Email = cadastroUsuario.Credencial.Email,
                    Senha = cadastroUsuario.Credencial.Senha,
                    Usuario = usuario
                };

                Contexto.Usuarios.Add(usuario);
                Contexto.Credencials.Add(credencial);
                Contexto.SaveChanges();

                return Created();
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
		}

		[HttpGet]
        public ActionResult<IEnumerable<Usuario>> ObterLista()
        {
            try
            {
                var Usuarios = Contexto.Usuarios.ToList();

                return Ok(Usuarios);
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
		}

		[HttpGet("{id}")]
		public ActionResult<Usuario> ObterPorId(Guid Id)
		{
			
			try
            {
                var Usuario = Contexto.Usuarios.Find(Id);
                // var produto = Contexto.Produtos.FirstOrDefault(p => p.Id == id);

                if (Usuario == null)
                {
                    return BadRequest();
                }

                return Ok(Usuario);
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
		}

		[HttpPut("{id}")]
		public ActionResult<string> AtualizarPorId(Guid Id, [FromBody] Usuario UsuarioAtualizado)
		{

			try
            {
                var Usuario = Contexto.Usuarios.Find(Id);
                // var produto = Contexto.Produtos.FirstOrDefault(p => p.Id == id);

                if (Usuario == null || Usuario.Id != UsuarioAtualizado.Id)
                {
                    return BadRequest();
                }

                Contexto.Usuarios.Entry(UsuarioAtualizado).State = EntityState.Modified;
                Contexto.SaveChanges();

                // return NoContent();
                return Ok(UsuarioAtualizado);
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
		}

		[HttpDelete("{id}")]
		public ActionResult<string> AtualizarPorId(Guid id)
		{
			 try
            {
                var Usuario = Contexto.Usuarios.Find(id);
                // var produto = Contexto.Produtos.FirstOrDefault(p => p.Id == id);

                if (Usuario == null)
                {
                    return BadRequest();
                }

                Contexto.Usuarios.Remove(Usuario);
                Contexto.SaveChanges();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
		}
	}
}
