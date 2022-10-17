using System.Linq;
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

        [HttpGet("{Matricula}")]
        public async Task<IActionResult> BuscarPelaMatricula(string Matricula)
        {
            try
            {
                var aluno = await servicoAluno.BuscarPelaMAtricula(Matricula);

                return Ok(aluno);

            } catch(Exception ex)
            {
                return BadRequest();

            }
        }
        #endregion

        #region Editar Criar Excluir

        [HttpPost]
        public async Task<IActionResult> CadastrarAluno([FromBody] CreateAlunoDTO aluno)
        {

            var result = await servicoAluno.Adicionar(aluno);

            if (result.valido)
            {
                return Created("teste", new { });
            }

            return BadRequest(String.Join(", ", result.Erros));
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
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDTO aluno)
        {
            if(id == aluno.Id)
            {
                var alunoAtualizado = await servicoAluno.AlterarAluno(aluno);

                return Ok($"Aluno com matricula: {alunoAtualizado.Matricula} foi atualizado com sucesso");
            }

            return BadRequest("Ids diferentes");
        }

        #endregion
    }
}
