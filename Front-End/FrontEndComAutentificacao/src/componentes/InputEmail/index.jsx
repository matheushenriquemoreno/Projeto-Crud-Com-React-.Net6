import {useState} from "React"

const InputEmail = (props) => {

  props.emailEstaValido(validEmail())

  function validEmail(){
    return /^[\w+.]+@\w+\.\w{2,}(?:\.\w{2})?$/.test(props.value ?? "")
  }

  return (
        <input
        type="email"
        placeholder={props.placeholder}
        value={props.value}
        onChange={(e) => props.aoDigitar(e.target.value)}
      />
    )
}

export default InputEmail;