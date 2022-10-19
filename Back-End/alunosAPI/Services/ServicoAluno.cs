using System;
using System.Collections;
using System.Linq.Expressions;
using alunosAPI.DTO;
using alunosAPI.DTO.Aluno;
using alunosAPI.Models.Entidades;
using alunosAPI.Repository.RepositoryAluno;
using AutoMapper;
using FluentValidation;

namespace alunosAPI.Services
{
    public class ServicoAluno : IServicoAluno
    {
        private readonly IRepositoryAluno _repositoryAluno;
        private readonly IValidator<Aluno> _validator;
        private readonly IMapper _mapper;

        public ServicoAluno(IRepositoryAluno repositoryAluno, IValidator<Aluno> validator, IMapper mapper)
        {
            _repositoryAluno = repositoryAluno;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<AlunoDTO> BuscarPelaMAtricula(string matricula)
        {
            var aluno = await _repositoryAluno.BuscarTodosOnde(x => x.Matricula.Equals(matricula));

            var alunosDTO = _mapper.Map<AlunoDTO>(aluno.FirstOrDefault());

            return alunosDTO;
        }
        public async Task<IEnumerable<AlunoDTO>> BuscarTodos()
        {
            var alunos = await _repositoryAluno.BuscarTodos();

            var alunosDTO = _mapper.Map<IEnumerable<AlunoDTO>>(alunos);

            return alunosDTO;
        }
        public async Task<AlunoDTO> BuscarPeloId(int id)
        {
           var aluno = await _repositoryAluno.BuscarPeloID(id);

            return _mapper.Map<AlunoDTO>(aluno);
        }
        public async Task<Resultado<AlunoDTO>> Adicionar(CreateAlunoDTO alunoDTO)
        {
            var aluno = _mapper.Map<Aluno>(alunoDTO);

            var resultado = verificaUsuario<AlunoDTO>(aluno);

            if (resultado.Valido)
            {
                aluno.Matricula = CriarMatriculaAluno();
                await _repositoryAluno.Adicionar(aluno);
            }

            resultado.Entidade = _mapper.Map<AlunoDTO>(aluno);

            return resultado;
        }
        public async Task<Resultado<AlunoDTO>> AlterarAluno(AlunoDTO alunoDTO)
        {
            var AlunoAtualizar = await _repositoryAluno.BuscarPeloID(alunoDTO.Id);

            AlunoAtualizar.Nome = alunoDTO.Nome;
            AlunoAtualizar.Email = alunoDTO.Email;
            AlunoAtualizar.Idade = alunoDTO.Idade;

            var resultado = verificaUsuario<AlunoDTO>(AlunoAtualizar);

            if (resultado.Valido)
            {
                await _repositoryAluno.Atualizar(AlunoAtualizar);
            }

            resultado.Entidade = _mapper.Map<AlunoDTO>(AlunoAtualizar);

            return resultado;
        }
        public async Task RemoverAluno(int id)
        {
            var aluno = await _repositoryAluno.BuscarPeloID(id);

            if (aluno is null)
                throw new NullReferenceException();

            await _repositoryAluno.Excluir(aluno);
        }

        #region Metodos privados
        private Resultado<T> verificaUsuario<T>(Aluno aluno)
        {
            var resultado = _validator.Validate(aluno);

            var retorno = new Resultado<T>();

            if (resultado.IsValid)
            {
                retorno.Valido = true;
                return retorno;
            }

            retorno.Erros = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            return retorno;
        }
        private string CriarMatriculaAluno()
        {

            var matricula = CriaStringMatricula();

            while (_repositoryAluno.BuscarTodosOnde(x => x.Matricula == matricula).Result.FirstOrDefault() != null)
            {
                matricula = CriaStringMatricula();
            }

            return matricula;
        }
        private string CriaStringMatricula()
        {
            Random randNum = new Random();

            var parte1Matricula = randNum.Next(1000, 9999);

            var parte2MAtricula = randNum.Next(10, 99);

            return $"{parte1Matricula}-{parte2MAtricula}";
        }

        #endregion
    }
}
