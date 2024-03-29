﻿using alunosAPI.Models.EntidadeBase;

namespace alunosAPI.Models.Entidades
{
    public class Aluno : IEntidadeBase
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }

        public string Matricula { get; set; }

        public Aluno()
        {

        }

        public Aluno(string nome, string email, int idade, string matricula)
        {
            Nome = nome;
            Email = email;
            Idade = idade;
            Matricula = matricula;
        }
    }
}
