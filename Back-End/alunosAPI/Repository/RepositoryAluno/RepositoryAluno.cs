using alunosAPI.Context;
using alunosAPI.Models;
using alunosAPI.Repository.RepositoryBase;

namespace alunosAPI.Repository.RepositoryAluno
{
    public class RepositoryAluno : RepositoryBase<Aluno>, IRepositoryAluno
    {
        public RepositoryAluno(AppDbContext context) : base(context)
        {
        }
    }
}
