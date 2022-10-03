import { useEffect, useState } from 'react'
import ModalConfirmacao from '../Modals'
import axios from 'axios'

const ModalCadastrarAluno = (props) => {

    const [nome, setNome] = useState('');
    const [email, setEmail] = useState('');
    const [idade, setidade] = useState('');
        
    const aoDigitarNome = (evento) => {
        setNome(evento.target.value)
    }

    const aoDigitarEmail = (evento) => {
        setEmail(evento.target.value)
    }

    const aoDigitarIdade = (evento) => {
        setidade(evento.target.value)
    }

    const enviarDados = async () => {
        axios.post("https://localhost:7103/api/alunos", {
            nome,
            email,
            idade
        })
        .then(res => console.log(res));
        props.aoSalvar();
    }

    return (
        <ModalConfirmacao 
        titulo='cadastrar'
        funcaoAoSalvar={enviarDados}
        >
            <form className="form-group">
                <label>Nome: </label>
                <br />
                <input type="text" value={nome} className="form-control" name="nome" onChange={aoDigitarNome} />
                <br />
                <label>Email: </label>
                <br />
                <input type="text" value={email} className="form-control" name="email" onChange={aoDigitarEmail} />
                <br />
                <label>Idade: </label>
                <br />
                <input type="text" value={idade} className="form-control" name="idade" onChange={aoDigitarIdade} />
                <br />
            </form>
        </ModalConfirmacao>
    )
}

export default ModalCadastrarAluno;
