using alunosAPI.DTO;
using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;
using AutoMapper;
using FluentValidation;

namespace alunosAPI.Services.ServiceBase
{
    public class ServiceBase<T>
    {
        protected readonly IValidator<T> Validator;
        protected readonly IMapper Mapper;

        public ServiceBase(IValidator<T> validator, IMapper mapper)
        {
            Validator = validator;
            Mapper = mapper;
        }

        protected Resultado<TDTO> VerificaEntidadeEstaValida<TDTO>(T aluno)
        {
            var resultado = Validator.Validate(aluno);

            var retorno = new Resultado<TDTO>();

            retorno.Entidade = Mapper.Map<TDTO>(aluno);

            if (resultado.IsValid)
            {
                retorno.Valido = true;
                return retorno;
            }

            retorno.Erros = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            return retorno;
        }
    }
}

