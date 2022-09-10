using alunosAPI.Context;
using alunosAPI.Repository.RepositoryAluno;
using Microsoft.EntityFrameworkCore;

namespace System
{
    public static class InjetandoDependencias
    {

        public static void ConfigurarDependencias(this IServiceCollection service)
        {
            service.AddTransient<IRepositoryAluno, RepositoryAluno>();
        }

        public static void ConfigurarBanco(this IServiceCollection service, WebApplicationBuilder builder)
        {
            service.AddDbContext<AppDbContext>(x => {
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

        }
    }
}
