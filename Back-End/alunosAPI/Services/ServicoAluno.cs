using System;
using System.Collections;
using System.Linq.Expressions;
using alunosAPI.Models.Entidades;
using alunosAPI.Repository.RepositoryAluno;
using FluentValidation;

namespace alunosAPI.Services
{
    public class ServicoAluno : IServicoAluno
    {

        private readonly IRepositoryAluno _repositoryAluno;
        private readonly IValidator<Aluno> _validator;

        public ServicoAluno(IRepositoryAluno repositoryAluno, IValidator<Aluno> validator)
        {
            _repositoryAluno = repositoryAluno;
            _validator = validator;
        }

        public async Task<(bool valido, List<string> Erros)> Adicionar(Aluno aluno)
        {
            var Erros = new List<string>();

            var resultado = _validator.Validate(aluno);
            
            if (resultado.IsValid)
            {
                aluno.Matricula = CriarMatriculaAluno();
                await _repositoryAluno.Adicionar(aluno);
                return (true, Erros);
            }

            Erros = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            return (false, Erros);
        }

        private string CriarMatriculaAluno()
        {

            var matricula = CriaStringMatricula();

            while (_repositoryAluno.BuscarTodosOnde(x => x.Matricula == matricula).Result.FirstOrDefault() != null)
            {
                matricula = CriaStringMatricula();
            }

            return matricula;
        }
        private string CriaStringMatricula()
        {
            Random randNum = new Random();

            var parte1Matricula = randNum.Next(1000, 9999);

            var parte2MAtricula = randNum.Next(10, 99);

           return $"{parte1Matricula}-{parte2MAtricula}";

        }

        public async Task<IEnumerable<Aluno>> BuscarTodosOnde(Expression<Func<Aluno, bool>> express)
        {
            return await _repositoryAluno.BuscarTodosOnde(express);
        }

        public async Task<IEnumerable<Aluno>> BuscarTodos()
        {
          return  await _repositoryAluno.BuscarTodos();
        }
    }
}
