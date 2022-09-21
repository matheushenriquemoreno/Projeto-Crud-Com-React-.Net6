using alunosAPI.Models.Entidades;
using FluentValidation;

namespace alunosAPI.Models.Validadores
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {

            RuleFor(x => x.Nome).NotEmpty().MaximumLength(80);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Idade).NotEmpty().Custom((idade, aluno) => {
                if(idade < 1)
                {
                    aluno.AddFailure("Não e valido Idade menor que 1");
                }
                if(idade > 150)
                {
                    aluno.AddFailure("Não e valido Idade Maior que 150");
                }
            } );
        }
    }
}
