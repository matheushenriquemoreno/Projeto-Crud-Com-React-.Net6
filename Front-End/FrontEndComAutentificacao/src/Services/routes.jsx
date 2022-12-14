import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import LoginPage from "../Pages/LoginPage";
import Alunos from "../Pages/Alunos";
import AlunoAcoes from "../Pages/AlunoAcoes";
import CadastroUserPage from "../Pages/CadastroUserPage";

export default function Rotas() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/UserCadastro" element={<CadastroUserPage />} />
        <Route path="/alunos" element={<Alunos />} />
        <Route path="/aluno/novo/:alunoId" element={<AlunoAcoes />} />
        <Route path="/*" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
  );
}
