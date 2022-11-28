import {useState} from "React"
import InputEmail from "../InputEmail"
import "../Login/login.css"
import Alert from "react-bootstrap/Alert";
import { useEffect } from "react";

const Validacao = {
  ErroSenha: {
    Erro: false,
    Messsage: "Senha não comdiz com o padrão informado"
    },
  ErroComfirmacaoSenha: {
      Erro: false,
      Messsage: "Senhas não são informadas."
  },
  ErroEmail: {
    Erro: false,
    Messsage: "Email não Valido."
},
}
const propriedades = Object.keys(Validacao);

const CadastroUser =  () => {
    const [email, setEmail] = useState("")
    const [senha, setSenha] = useState("")
    const [confirmacaoSenha, setConfirmacaoSenha] = useState("")
    const [emailValido, seEmailValido] = useState(true);
    
    const validaPadraoSenha = (senha) => {
      var reguex = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/)
      return reguex.test(senha);
    }

    function validaSenha(senha){
      Validacao.ErroSenha.Erro = validaPadraoSenha(senha);
      setSenha(senha);
    }

    const VerificaSenhasIguais = () => {
      Validacao.ErroComfirmacaoSenha.Erro = senha === confirmacaoSenha;
    }

    const cadastrarUsuario = (e) => {
      e.preventDefault();
      VerificaSenhasIguais();
     
      console.log({
        email,
        senha,
        confirmacaoSenha
      })

    }

    useEffect(() => {

    }, [Validacao]) 


    return ( 
    <div className="fundo">
    <div className="center">
      <h1>Cadastro</h1>
      <form  onSubmit={cadastrarUsuario} >
        <div className="txt_field">
         <InputEmail placeholder="email"
                    aoDigitar={setEmail}
                    value={email}
                    emailEstaValido={retorno => seEmailValido(retorno)}

          />
          <span></span>
          <label>Email</label>
        </div>
      <div>
        <p style={{color: "red"}}>  </p>
      </div>

        <div className="txt_field">
          <input
            type="password"
            placeholder=""
            value={senha}
            onChange={(e) => validaSenha(e.target.value)}
          />
          <span></span>
          <label>Senha</label>
        </div>
        <div className="txt_field">
          <input
            type="password"
            placeholder=""
            value={confirmacaoSenha}
            onChange={(e) => setConfirmacaoSenha(e.target.value)}
          />
          <span></span>
          <label>Confirmar Senha</label>
        </div>
        <Alert variant="secondary">
            Sua senha precisa ter: <br></br>
            - minimo de 8 Caracteres, <br></br>
            - uma letra maiuscula <br></br>
            - uma letra minuscula,<br></br>
            - um numero,<br></br>
            - e algum caracter[#$^+=!*()@%&]
        </Alert>
             


        <input type="submit" value="Cadastrar" className="enviar" />
        <div className="signup_link"> </div>
      </form>
    </div>
  </div>

    )


}


export default CadastroUser;