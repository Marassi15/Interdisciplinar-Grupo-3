// eslint-disable-next-line
import React, { useState, useEffect } from 'react';
import './App.css';

import 'bootstrap/dist/css/bootstrap.min.css';

import axios from 'axios';

import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';


function App() {
  const baseUrl="https://aplicativos.avantti.com.br/medicao/swagger/index.html"

  const [data,setData] = useState([])

  const [processoSelecionado,setProcessoSelecionado] =useState({
    cd_proc: '',
    titulo_proc: ''
  })

  const[modalIncluir, setModalIncluir] = useState(false);

  const abrirFecharModalIncluir=()=>{
    setModalIncluir(!modalIncluir);
  }

  // eslint-disable-next-line
  const handleChange = e =>{
    const {name, value} = e.target;
    setProcessoSelecionado({
      ...processoSelecionado, 
      [name]:value
    });
    console.log(processoSelecionado);

    const pedidoPost = async()=>{
      await axios.post(baseUrl, processoSelecionado)
      .then(response =>{
        setData(data.concat(response.data));
        abrirFecharModalIncluir();
      }).catch(error=>{
        console.log(error);
      })
    }

    return (
    <div className="App">
      <header className="App-header">
        <h1> Medições Software</h1>
        <button className="btn btn-sucess" onclick={abrirFecharModalIncluir()}>Nova Medição</button>
      </header>
      <Modal isOpen={modalIncluir}>
        <ModalHeader>Processo de TI</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Nome do Processo</label>
            <imput type="text" className="form-control" name="titulo_proc" onchange={handleChange}></imput>
            <label>cod do Processo</label>
            <imput type="text" className="form-control" name="cd_proc" onchange={handleChange}></imput>

          </div>
        </ModalBody>
        <ModalFooter>
          <buttom className ="btn btn-primary" onclick={pedidoPost()}>incluir</buttom>{" "}
          <buttom className ="btn btn-danger" onclick={abrirFecharModalIncluir()}>cancelar</buttom>
        </ModalFooter>
      </Modal>
    </div>
  ); 
}}

export default App;
