import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';

function DropDowns(props) {
  console.log(props.Acoes)
  return (
    <Dropdown>
      <Dropdown.Toggle variant="success" id="dropdown-basic">
       {props.titulo}
      </Dropdown.Toggle>

      <Dropdown.Menu>
        {props.Acoes.map(acao => <Dropdown.Item key={acao.nome} href={acao.url}>{acao.nome}</Dropdown.Item> )}
      </Dropdown.Menu>
    </Dropdown>
  );
}

export default DropDowns;