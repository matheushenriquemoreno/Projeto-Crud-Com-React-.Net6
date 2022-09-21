using alunosAPI.Models.EntidadeBase;

namespace alunosAPI.Models.Entidades
{
    public class Aluno : IEntidadeBase
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }



    }
}
