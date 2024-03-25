using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Contexts;
using Models;
using Requests;
using Responses;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    public class Cadastro
    {
        public required Usuario Usuario { get; set; }
        public required Credencial Credencial { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")] 
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
                
                /*
                return CreatedAtAction(
                    nameof(ObterPorId), 
                    new { id = usuario.Id },
                    usuario
                );
                */
                return Created(nameof(ObterPorId), new { id = usuario.Id });
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ObterUsuariosResponse> ObterPorId(Guid id)
        {

            try
            {
                var usuario = Contexto.Usuarios.Find(id);
                // var produto = Contexto.Produtos.FirstOrDefault(p => p.Id == id);

                if (usuario == null)
                {
                    return BadRequest();
                }

                return Ok(
                    new 
                    {
                        Nome = usuario.Nome,
                        Sobrenome = usuario.Sobrenome,
                        DataNascimento = usuario.DataNascimento,
                        Genero = usuario.Genero,
                        Naturalidade = usuario.Naturalidade,
                        Telefone = usuario.Telefone
                    }
                );
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<AtualizarUsuarioResponse> AtualizarPorId(Guid id, [FromBody] AtualizarUsuarioRequest usuarioAtualizado)
        {
            try
            {
                var usuario = Contexto.Usuarios.Find(id);

                if (usuario == null || usuario.Id != usuarioAtualizado.Id)
                {
                    return BadRequest();
                }

                usuario.Nome = usuarioAtualizado.Nome;
                usuario.Sobrenome = usuarioAtualizado.Sobrenome;
                usuario.DataNascimento = usuarioAtualizado.DataNascimento;
                usuario.Genero = usuarioAtualizado.Genero;
                usuario.Naturalidade = usuarioAtualizado.Naturalidade;
                usuario.Telefone = usuarioAtualizado.Telefone;

                Contexto.Usuarios.Entry(usuario).State = EntityState.Modified;
                Contexto.SaveChanges();

                return Ok(
                    new 
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Sobrenome = usuario.Sobrenome,
                        DataNascimento = usuario.DataNascimento,
                        Genero = usuario.Genero,
                        Naturalidade = usuario.Naturalidade,
                        Telefone = usuario.Telefone
                    }
                );
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente mais tarde!");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> AtualizarPorId(Guid id)
        {
            try
            {
                var usuario = Contexto.Usuarios.Find(id);

                if (usuario == null)
                {
                    return BadRequest();
                }

                Contexto.Usuarios.Remove(usuario);
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
