import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import Login from '../componentes/Login'
import Alunos from '../componentes/Alunos'

export default function Rotas(){
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/alunos" element={<Alunos />} />
            </Routes>
        </BrowserRouter>
    )
}