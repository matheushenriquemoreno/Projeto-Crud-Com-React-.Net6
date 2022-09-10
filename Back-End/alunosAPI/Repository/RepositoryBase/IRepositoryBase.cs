using System.Linq.Expressions;
using alunosAPI.Models.EntidadeBase;

namespace alunosAPI.Repository.RepositoryBase
{
    public interface IRepositoryBase<T> where T : class, IEntidadeBase
    {
        Task<T> BuscarPeloID(int id);

        Task<IEnumerable<T>> BuscarTodos();

        Task<IEnumerable<T>> BuscarTodosOnde(Expression<Func<T, bool>> express);

        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Salvar();
        void Excluir(T entidade);

    }
}
