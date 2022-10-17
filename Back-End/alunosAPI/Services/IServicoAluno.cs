using System.Linq.Expressions;
using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;

namespace alunosAPI.Services
{
    public interface IServicoAluno
    {
        Task<(bool valido, List<string> Erros)> Adicionar(CreateAlunoDTO aluno);
        Task<AlunoDTO> BuscarPelaMAtricula(string matricula);
        Task<IEnumerable<AlunoDTO>> BuscarTodos();
        Task<AlunoDTO> BuscarPeloId(int id);
        Task<AlunoDTO> AlterarAluno(AlunoDTO aluno);
        Task RemoverAluno(int id);
    }
}
