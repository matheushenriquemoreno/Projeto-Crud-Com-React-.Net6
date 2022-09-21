using System.Linq.Expressions;
using alunosAPI.Models.Entidades;

namespace alunosAPI.Services
{
    public interface IServicoAluno
    {

        bool Adicionar(Aluno aluno, out List<string> Erros);

        void BuscarTodosOnde(Expression<Func<Aluno, bool>> express);


    }
}
