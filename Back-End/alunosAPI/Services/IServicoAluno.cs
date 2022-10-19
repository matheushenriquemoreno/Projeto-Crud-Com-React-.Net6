using System.Linq.Expressions;
using alunosAPI.DTO;
using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;

namespace alunosAPI.Services
{
    public interface IServicoAluno
    {
        Task<Resultado<AlunoDTO>> Adicionar(CreateAlunoDTO aluno);
        Task<AlunoDTO> BuscarPelaMAtricula(string matricula);
        Task<IEnumerable<AlunoDTO>> BuscarTodos();
        Task<AlunoDTO> BuscarPeloId(int id);
        Task<Resultado<AlunoDTO>> AlterarAluno(AlunoDTO aluno);
        Task RemoverAluno(int id);
    }
}
