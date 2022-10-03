using alunosAPI.Context;
using alunosAPI.Models.Entidades;
using alunosAPI.Models.Validadores;
using alunosAPI.Repository.RepositoryAluno;
using alunosAPI.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace System
{
    public static class InjetandoDependencias
    {

        public static void ConfigurarDependencias(this IServiceCollection service)
        {
            service.AddTransient<IRepositoryAluno, RepositoryAluno>();
            service.AddTransient<IServicoAluno, ServicoAluno>();
            service.AddScoped<IValidator<Aluno>, AlunoValidator>();
        }

        public static void ConfigurarBanco(this IServiceCollection service, WebApplicationBuilder builder)
        {
            service.AddDbContext<AppDbContext>(x => {
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

        }
    }
}
