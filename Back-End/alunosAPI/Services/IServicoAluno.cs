using System.Linq.Expressions;
using alunosAPI.Models.Entidades;

namespace alunosAPI.Services
{
    public interface IServicoAluno
    {
        Task<(bool valido, List<string> Erros)> Adicionar(Aluno aluno);
        Task<IEnumerable<Aluno>> BuscarTodosOnde(Expression<Func<Aluno, bool>> express);
        Task<IEnumerable<Aluno>> BuscarTodos();
    }
}
