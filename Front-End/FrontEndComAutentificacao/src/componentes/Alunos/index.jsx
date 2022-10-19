import { Link, useNavigate } from "react-router-dom";
import "./Alunos.css";
import { FiXCircle, FiEdit, FiUserX, FiSearch } from "react-icons/fi";
import LogoCadastro from "../../assets/cadastro1.png";
import { useEffect, useState } from "react";
import axios from "../../Services/api";
import Button from "react-bootstrap/Button";
import Alert from "react-bootstrap/Alert";
import Aluno from "../AlunoListagem";

const Alunos = () => {
  const api = axios();
  const [matricula, setMatricula] = useState("");
  const [alunos, setalunos] = useState([]);

  const navigate = useNavigate();

  const email = localStorage.getItem("email");

  const sair = async () => {
    try {
      localStorage.clear();
      localStorage.setItem("token", "");
      navigate("/");
    } catch (erro) {
      alert("Ocorreu um erro" + erro);
    }
  };

  const editarAluno = async (idAluno) => {
    navigate(`/aluno/novo/${idAluno}`);
  };

  const filtrarMatricula = (e) => {
    e.preventDefault();
    if (matricula === "") return;

    const alunoFiltrado = alunos.filter((aluno) =>
      aluno.matricula.includes(matricula.trim())
    );

    setalunos(alunoFiltrado);
  };

  const limpar = async () => {
    setMatricula("");
    await buscaAlunos();
  };

  const buscaAlunos = () => {
    api.get("api/alunos").then((responde) => {
      setalunos(responde.data);
    });
  };

  const excluirAluno = async (id, matricula) => {
    try {
      if (
        window.confirm(`Deseja deletar o aluno de matricula: ${matricula} ? `)
      ) {
        const result = await api.delete(`api/alunos/${id}`);
        buscaAlunos();
      }
    } catch (erro) {
      alert(erro.response?.data ?? "Ocorreu um erro inesperado");
    }
  };

  useEffect(() => {
    buscaAlunos();
  }, []);

  return (
    <div className="aluno-container">
      <header>
        <img src={LogoCadastro} alt="Cadastro" />
        <span>
          Bem-Vindo, <strong>{email}</strong>!
        </span>
        <Link className="button" to="/aluno/novo/0">
          Novo Aluno
        </Link>

        <button onClick={sair}>
          <FiXCircle size={35} color="#17202a" />
        </button>
      </header>

      <form>
        <input
          type="text"
          className="inputMatricula"
          placeholder="Filtrar por Matricula..."
          value={matricula}
          onChange={(e) => {
            setMatricula(e.target.value);
            console.log(e.target.value);
          }}
        />
        <Button variant="primary" onClick={filtrarMatricula}>
          Buscar
        </Button>
        <Button variant="secondary" className="button-bostrap" onClick={limpar}>
          Limpar
        </Button>
      </form>

      <h1>Relação de Alunos</h1>
      <ul>
        {alunos.length <= 0 ? (
          <Alert variant="danger"> Nenhum aluno encontrado </Alert>
        ) : (
          alunos.map((aluno) => (
            <Aluno
              key={aluno.id}
              id={aluno.id}
              matricula={aluno.matricula}
              nome={aluno.nome}
              email={aluno.email}
              idade={aluno.idade}
              editarAluno={editarAluno}
              excluirAluno={excluirAluno}
            />
          ))
        )}
      </ul>
    </div>
  );
};

export default Alunos;
