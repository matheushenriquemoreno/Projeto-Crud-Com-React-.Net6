using System.ComponentModel.DataAnnotations;

namespace alunosAPI.DTO.Aluno
{
    public class AlunoCriacaoDTO
    {
        public string Nome { get; set; }
   
        public string Email { get; set; }
       
        public int Idade { get; set; }
    }
}
