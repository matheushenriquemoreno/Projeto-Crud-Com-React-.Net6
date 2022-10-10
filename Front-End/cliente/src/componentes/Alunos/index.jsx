import React from "react";
import { Link } from "react-router-dom"
import "./Alunos.css";

import { FiXCircle, FiEdit, FiUserX } from 'react-icons/fi'

const Alunos = () => {
    return (
        <div className="aluno-container teste">
            <header>

                <span>Seja bem vindo <strong> Teste</strong></span>

                <Link className="button" to="aluno/cadastrar"> Novo aluno</Link>


            </header>

            <form>
                <input type='teste' placeholder="Filtrar aluno por matricula" />
            </form>
            <h1>Alunos cadastrados</h1>
            <div className="listagem-alunos">
                <div className="aluno">
                    <ul>
                        <li>
                            <b>Matricula:</b> A <br></br>
                            <b>Nome:</b> A <br></br>
                            <b>Email:</b> <br></br>
                            <b>Idade:</b> <br></br>
                            <button type="button">
                                <FiEdit size="25" color="#17202a"></FiEdit>
                            </button>

                            <button type="button">
                                <FiUserX size="25" color="#17202a"></FiUserX>
                            </button>
                        </li>
                    </ul>
                </div>
                <div className="aluno">
                    <ul>
                        <li>
                            <b>Matricula:</b> A <br></br>
                            <b>Nome:</b> A <br></br>
                            <b>Email:</b> <br></br>
                            <b>Idade:</b> <br></br>
                            <button type="button">
                                <FiEdit size="25" color="#17202a"></FiEdit>
                            </button>

                            <button type="button">
                                <FiUserX size="25" color="#17202a"></FiUserX>
                            </button>
                        </li>
                    </ul>
                </div>
                <div className="aluno">
                    <ul>
                        <li>
                            <b>Matricula:</b> A <br></br>
                            <b>Nome:</b> A <br></br>
                            <b>Email:</b> <br></br>
                            <b>Idade:</b> <br></br>
                            <button type="button">
                                <FiEdit size="25" color="#17202a"></FiEdit>
                            </button>

                            <button type="button">
                                <FiUserX size="25" color="#17202a"></FiUserX>
                            </button>
                        </li>
                    </ul>
                </div>
                <div className="aluno">
                    <ul>
                        <li>
                            <b>Matricula:</b> A <br></br>
                            <b>Nome:</b> A <br></br>
                            <b>Email:</b> <br></br>
                            <b>Idade:</b> <br></br>
                            <button type="button">
                                <FiEdit size="25" color="#17202a"></FiEdit>
                            </button>

                            <button type="button">
                                <FiUserX size="25" color="#17202a"></FiUserX>
                            </button>
                        </li>
                    </ul>
                </div>

            </div>


        </div>
    )
}

export default Alunos