import { useEffect, useState } from 'react'
import './styles/App.css'
import DropDowns from './componentes/DropDowns'
import ModalCadastrarAluno from './componentes/ModalCadastrarAluno'
import logoCadastro from './assets/cadastro.png';
import axios from 'axios'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';


function App() {
  const urlBusca = "https://localhost:7103/api/alunos";

  const [Alunos, setAlunos] = useState([]);

  const pedidoGet = async () => {
    await axios.get(urlBusca)
      .then(response => {
        console.log(response.data)
        setAlunos(response.data)
      })
      .catch(error => {
        console.log(error);
      })
  }

  useEffect(() => {
    pedidoGet()
  }, [])

  return (
    <div className="aluno-container">

      <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">Gerenciamento de alunos</Navbar.Brand>
          <Nav className="me-auto">
          </Nav>
          
          <ModalCadastrarAluno
          aoSalvar={pedidoGet}
        />

        </Container>
      </Navbar>


      <table className="table table-striped table-dark span-12">
        <thead className="">
          <tr>
            <th>Matricula</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Idade</th>
            <th>Operação</th>
          </tr>
        </thead>
        <tbody>
          {
            Alunos.map(aluno =>
              <tr key={aluno.id}>
                <td>{aluno.matricula}</td>
                <td>{aluno.nome}</td>
                <td>{aluno.email}</td>
                <td>{aluno.idade}</td>
                <td>
                  <DropDowns
                    titulo='Acoes'
                    Acoes={[{
                      url: `urlQualquer/${aluno.Id}`,
                      nome: "Editar"
                    },
                    {
                      url: `urlQualquer/${aluno.Id}`,
                      nome: "Excluir"
                    },
                    ]}
                  />
                </td>
              </tr>
            )
          }
        </tbody>
      </table>
    </div>
  )
}

export default App
