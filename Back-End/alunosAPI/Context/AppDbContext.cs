using System.Reflection;
using alunosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace alunosAPI.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Aluno> Alunos { get; set; }

    }
}
