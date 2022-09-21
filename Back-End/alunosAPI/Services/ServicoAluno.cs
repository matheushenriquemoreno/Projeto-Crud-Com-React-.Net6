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


        public bool Adicionar(Aluno aluno, out List<string> Erros)
        {
            Erros = new List<string>();

            var resultado = _validator.Validate(aluno);
            
            if (resultado.IsValid)
            {
                _repositoryAluno.Adicionar(aluno);
                return true;
            }

            Erros = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            return false;

        }

        public void BuscarTodosOnde(Expression<Func<Aluno, bool>> express)
        {
            _repositoryAluno.BuscarTodosOnde(express);
        }
    }
}
