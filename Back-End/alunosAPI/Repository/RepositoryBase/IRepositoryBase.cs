using System.Linq.Expressions;
using alunosAPI.Models.EntidadeBase;

namespace alunosAPI.Repository.RepositoryBase
{
    public interface IRepositoryBase<T> where T : class, IEntidadeBase
    {
        Task<T> BuscarPeloID(int id);

        Task<IEnumerable<T>> BuscarTodos();

        Task<IEnumerable<T>> BuscarTodosOnde(Expression<Func<T, bool>> express);

        Task Adicionar(T entidade);

        Task Atualizar(T entidade);

        Task Salvar();
        Task Excluir(T entidade);

    }
}
