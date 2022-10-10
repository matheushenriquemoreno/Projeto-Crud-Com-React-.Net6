import React from "react";
import classe from'./Login.Modules.css';

const Login = () => {
    return (
        <div className="center">
            <h1>Login</h1>
            <form method="post">
                <div className="txt_field">
                    <input type="text" required/>
                        <span></span>
                        <label>Email</label>
                </div>
                <div className="txt_field">
                    <input type="password" required/>
                        <span></span>
                        <label>Senha</label>
                </div>
                <div className="pass">Esqueceu a senha?</div>
                <input type="submit" value="Acessar a conta"/>
                    <div className="signup_link">
                        Não possue cadastro? <a href="#">Cadastrar</a>
                    </div>
            </form>
        </div>
    )
}

export default Login



