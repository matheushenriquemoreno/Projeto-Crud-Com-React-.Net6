import React, { useEffect, useState } from "react";
import "./Login.css";
import apiLogin from "../../Services/apiLogin";
import { useNavigate, useSearchParams, Link } from "react-router-dom";

const Login = () => {

  const [searchParams] = useSearchParams();
  const tokenExpirou = searchParams.get("expirou");

  const navigate = useNavigate();

  const logar = async (e) => {
    e.preventDefault();

    const data = { email, senha };

    try {
      const response = await apiLogin.post("/Api/Login/LogarUsuario", data);

      localStorage.setItem("email", email);
      localStorage.setItem("token", response.data.token);
      localStorage.setItem("expiracao", response.data.expiracao);

      navigate("/alunos");
    } catch (erro) {
      alert("O Login falhou " + erro);
    }
  };

  useEffect(() => {
    if (tokenExpirou) alert("token expirou!");
  }, []);

  return (
    <div className="fundo">
      <div className="center">
        <h1>Login</h1>
        <form onSubmit={logar}>
          <div className="txt_field">
            <input
              placeholder=""
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <span></span>
            <label>Email</label>
          </div>
          <div className="txt_field">
            <input
              type="password"
              placeholder=""
              value={senha}
              onChange={(e) => setSenha(e.target.value)}
            />
            <span></span>
            <label>Senha</label>
          </div>
          <input type="submit" value="Login" className="enviar" />
          <div className="signup_link">
            Novo Cliente?  

            <Link to="/userCadastro">
            Cadastrar
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;
