using System.Text;
using alunosAPI.Context;
using alunosAPI.Mappers;
using alunosAPI.Models.Entidades;
using alunosAPI.Models.Validadores;
using alunosAPI.Repository.RepositoryAluno;
using alunosAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace System
{
    public static class ConfiguracoesProjeto
    {
        /*Implementando a inversao de controle*/
        public static void ConfigurarDependencias(this IServiceCollection service)
        {
            service.AddTransient<IRepositoryAluno, RepositoryAluno>();
            service.AddTransient<IServicoAluno, ServicoAluno>();
            service.AddScoped<IValidator<Aluno>, AlunoValidator>();
            service.AddAutoMapper(typeof(AlunoMapper));
        }

        public static void ConfigurarBanco(this IServiceCollection service, WebApplicationBuilder builder)
        {
            service.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigurarAutentificacao(this IServiceCollection service, WebApplicationBuilder builder)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
                };
            });
        }

    }
}
