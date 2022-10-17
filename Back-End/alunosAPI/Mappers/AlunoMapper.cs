using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;
using AutoMapper;

namespace alunosAPI.Mappers
{
    public class AlunoMapper : Profile
    {
        public AlunoMapper()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<CreateAlunoDTO, Aluno>();
        }
    }
}
