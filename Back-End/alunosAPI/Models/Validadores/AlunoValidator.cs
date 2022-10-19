using alunosAPI.Models.Entidades;
using FluentValidation;

namespace alunosAPI.Models.Validadores
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {

            RuleFor(x => x.Nome).NotEmpty().MaximumLength(80);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Idade).NotEmpty().WithMessage("A idade tem que ser informada");
            RuleFor(x => x.Idade).Custom((idade, aluno) =>
            {
                if (idade > 80)
                {
                    aluno.AddFailure("Não e valido Idade Maior que 80!");
                }
            });
        }
    }
}
