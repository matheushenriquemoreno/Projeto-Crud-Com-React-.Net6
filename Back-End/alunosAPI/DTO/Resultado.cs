using alunosAPI.Models.EntidadeBase;

namespace alunosAPI.DTO
{
    public class Resultado<T> 
    {
        public bool Valido { get; set; }
        public List<string> Erros { get; set; }
        public T Entidade { get; set; }

        public Resultado()
        {
            Valido = false;
            Erros = new List<string>();
        }
    }
}
