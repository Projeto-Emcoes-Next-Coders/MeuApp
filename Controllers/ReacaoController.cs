using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Responses;
using Requests;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReacaoController : ControllerBase
    {
        private readonly DbEmoday Contexto = new DbEmoday();

        [HttpPost]
        [Authorize(Roles = "Desenvolvedor")]
        public ActionResult<CadastroReacaoResponse> Cadastrar([FromBody] CadastroReacaoRequest ReacaoCadastrada)
        {
            try
            {
                Reacao reacao = new Reacao
                {
                    Nome = ReacaoCadastrada.Nome,
                    Descrição = ReacaoCadastrada.Descrição
                };

                Contexto.Reacaos.Add(reacao);
                Contexto.SaveChanges();

                return Created("ObterporId", new { id = reacao.Id });
            }
            catch
            {
                return StatusCode(500, "O problema foi sério, mas a gente passa bem!");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ObterReacoesResponse>> ObterLista()
        {
            try
            {
                var reacoes = Contexto.Reacaos
                    .Select(r => new
                    {
                        Id = r.Id,
                        Nome = r.Nome,
                        Descrição = r.Descrição
                    })
                    .ToList();

                return Ok(reacoes);
            }
            catch
            {
                return StatusCode(500, "Houve um problema, tente novamente!");
            }
        }


    }
}