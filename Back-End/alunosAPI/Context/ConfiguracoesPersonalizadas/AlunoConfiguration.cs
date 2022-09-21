using alunosAPI.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alunosAPI.Context.ConfiguracoesPersonalizadas
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {

        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(80);
            builder.HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Matheus Henrique",
                    Email = "Matheus@gmail.com",
                    Idade = 21
                }
                );
        }

    }
}
