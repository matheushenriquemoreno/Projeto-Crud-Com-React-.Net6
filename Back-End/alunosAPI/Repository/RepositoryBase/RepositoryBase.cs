using System.Linq.Expressions;
using alunosAPI.Context;
using alunosAPI.Models.EntidadeBase;
using Microsoft.EntityFrameworkCore;

namespace alunosAPI.Repository.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T>  where T :  class,IEntidadeBase
    {

        private readonly DbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Entidade() => _context.Set<T>();

        public async Task Adicionar(T entidade)
        {
            await Entidade().AddAsync(entidade);
            await Salvar();
        }

        public async Task Atualizar(T entidade)
        {
           _context.Entry(entidade).State = EntityState.Modified;
            await Salvar();
        }

        public async Task<T> BuscarPeloID(int id)
        {
           return await Entidade().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> BuscarTodos()
        {
            return await Entidade().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> BuscarTodosOnde(Expression<Func<T, bool>> express)
        {
            return await Entidade().Where(express).ToListAsync();
        }

        public async Task Excluir(T entidade)
        {
            Entidade().Remove(entidade);
           await Salvar();
        }

        public async Task Salvar()
        {
          await _context.SaveChangesAsync();
        }
    }
}
