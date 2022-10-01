import { useEffect, useState } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'

import axios from 'axios'
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap'


function App() {

  return (
    <div className="App">
      
    <h3> cadastro de alunos</h3>

    <header>
      <button className='btn btn-success'> cadastrar alunos </button>
    </header>
    <table className="table table-bordered">
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Idade</th>
            <th>Operação</th>
          </tr>
        </thead>
        <tbody>
    
        </tbody>
      </table>

    </div>
  )
}

export default App
