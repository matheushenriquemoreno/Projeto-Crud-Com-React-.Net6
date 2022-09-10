using System.Linq.Expressions;
using alunosAPI.Models;

namespace alunosAPI.Services
{
    public interface IAlunoService
    {

        void Adicionar();

        void BuscarOnde(Expression<Func<Aluno, bool>> express);


    }
}
