using System.ComponentModel.DataAnnotations;

namespace alunosAPI.DTO.Aluno
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
    }
}
