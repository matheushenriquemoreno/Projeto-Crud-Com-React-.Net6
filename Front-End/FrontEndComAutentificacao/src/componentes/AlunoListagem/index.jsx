import { FiEdit, FiUserX } from "react-icons/fi";

const Aluno = (props) => {
  return (
    <li key={props.id}>
      <b>Matricula: </b>
      {props.matricula}
      <br />
      <br />
      <b>Nome: </b>
      {props.nome}
      <br />
      <br />
      <b>Email: </b>
      {props.email}
      <br />
      <br />
      <b>Idade: </b>
      {props.idade}
      <br />
      <br />
      <button onClick={() => props.editarAluno(props.id)} type="button">
        <FiEdit size="25" color="#17202a" />
      </button>
      <button
        type="button"
        onClick={() => props.excluirAluno(props.id, props.matricula)}
      >
        <FiUserX size="25" color="#17202a" />
      </button>
    </li>
  );
};

export default Aluno;
