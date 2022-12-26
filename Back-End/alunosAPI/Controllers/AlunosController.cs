using System.Linq;
using System.Net;
using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;
using alunosAPI.Services;
using AutoMapper;
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

        #region Buscas

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var alunos = await servicoAluno.BuscarTodos();

            return Ok(alunos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPeloId(int id)
        {
            var aluno = await servicoAluno.BuscarPeloId(id);

            if (aluno is null)
                return NotFound("Aluno não foi encotrado!");

            return Ok(aluno);
        }

        [HttpGet("Matricula/{Matricula}")]
        public async Task<IActionResult> BuscarPelaMatricula(string Matricula)
        {
            try
            {
                var aluno = await servicoAluno.BuscarPelaMAtricula(Matricula);

                return Ok(aluno);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);

            }
        }
        #endregion

        #region Editar Criar Excluir

        [HttpPost]
        public async Task<IActionResult> CadastrarAluno([FromBody] CreateAlunoDTO aluno)
        {
            try
            {
                var result = await servicoAluno.Adicionar(aluno);

                if (result.Valido)
                {
                    return Created("api/alunos/", new { result.Entidade.Id });
                }

                return BadRequest(String.Join(", ", result.Erros));

            } catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoverAluno(int id)
        {
            try
            {
                await servicoAluno.RemoverAluno(id);
                return Ok("Aluno excluido com sucesso");
            }
            catch (NullReferenceException ex)
            {
                return NotFound("Aluno ja não consta mais na base de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDTO alunoDTO)
        {
            if (id != alunoDTO.Id)
                return BadRequest("Ids diferentes");

            var result = await servicoAluno.AlterarAluno(alunoDTO);

            if (result.Valido)
            {
                return Ok($"Aluno com matricula: {result.Entidade.Matricula} foi atualizado com sucesso");
            }

            return BadRequest(String.Join(", ", result.Erros));
        }

        #endregion
    }
}
