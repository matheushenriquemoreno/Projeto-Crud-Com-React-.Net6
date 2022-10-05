using System.Linq;
using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;
using alunosAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunosController : ControllerBase
    {
        private readonly IServicoAluno servicoAluno;

        public AlunosController(IServicoAluno servicoAluno)
        {
            this.servicoAluno = servicoAluno;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAluno([FromBody] AlunoCriacaoDTO aluno)
        {

            var result = await servicoAluno.Adicionar( new Aluno()
            {
                Idade = aluno.Idade,
                Email = aluno.Email,
                Nome = aluno.Nome
            });

            if (result.valido)
            {
                return Created("teste", new { });
            }

            return BadRequest(String.Join(", ", result.Erros));
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var alunos = await servicoAluno.BuscarTodos();

            return Ok(alunos);
        }
    }
}
