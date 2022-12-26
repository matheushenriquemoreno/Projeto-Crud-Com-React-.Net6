import React, { useEffect, useState } from "react";
import "./estyles.css";
import { FiCornerDownLeft, FiUserPlus } from "react-icons/fi";
import { Link, useParams, useNavigate } from "react-router-dom";
import axios from "../../Services/api";

const NovoAluno = () => {
  const api = axios();
  const { alunoId } = useParams();
  const EhCadastro = alunoId === "0";
  const navigate = useNavigate();

  const [id, setId] = useState(alunoId);
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [idade, setIdade] = useState(0);

  const carregarAluno = async () => {
    const responde = await api.get(`api/alunos/${alunoId}`);

    setId(responde.data.id);
    setEmail(responde.data.email);
    setIdade(responde.data.idade);
    setNome(responde.data.nome);
  };

  const adicionarOuEditar = async (e) => {
    e.preventDefault();

    const data = {
      nome,
      email,
      idade,
    };

    if (EhCadastro) {
      await adicionar(data);
    } else {
      data.id = id;
      await editar(data);
    }
  };

  const adicionar = async (data) => {
    try {
      console.log(data);
      const result = await api.post(`api/alunos`, data);

      alert("Aluno cadastrado com sucesso");
    } catch (erro) {
      alert(erro.response?.data ?? "Ocorreu um erro inesperado");
    }
  };

  const editar = async (data) => {
    try {
      const result = await api.put(`api/alunos/${data.id}`, data);

      alert(result.data);
    } catch (erro) {
      alert(erro.response?.data ?? "Ocorreu um erro inesperado");
    }
  };

  useEffect(() => {
    if (EhCadastro) return;
    carregarAluno();
  }, [alunoId]);

  return (
    <div className="novo-aluno-container">
      <div className="content">
        <section className="form">
          <FiUserPlus size="105" color="#17202a" />
          <h1>{alunoId === "0" ? "Incluir novo aluno" : "Atualizar Aluno"}</h1>
          <Link className="back-link" to="/alunos">
            <FiCornerDownLeft size={25} color="#17202a" />
            retornar
          </Link>
        </section>
        <form className="" onSubmit={adicionarOuEditar}>
          <label>Nome</label>
          <input
            type="text"
            className="input"
            name="nome"
            value={nome}
            placeholder="Nome"
            onChange={(e) => setNome(e.target.value)}
          />
          <label>Email</label>

          <input
            type="text"
            className="input"
            name="email"
            value={email}
            placeholder="Email"
            onChange={(e) => setEmail(e.target.value)}
          />

          <label>Idade</label>
          <input
            type="number"
            className="input"
            name="idade"
            value={idade}
            placeholder="Idade"
            onChange={(e) => setIdade(e.target.value)}
          />

          <button className="button">
            {alunoId === "0" ? "Incluir" : "Atualizar"}
          </button>
        </form>
      </div>
    </div>
  );
};

export default NovoAluno;
