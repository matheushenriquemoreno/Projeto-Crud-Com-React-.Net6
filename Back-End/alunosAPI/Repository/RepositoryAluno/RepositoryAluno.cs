using alunosAPI.Context;
using alunosAPI.Models.Entidades;
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
