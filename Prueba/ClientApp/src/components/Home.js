import React, { Component } from 'react';
import axios from 'axios';

export class Home extends Component {
  static displayName = Home.name;
    
    constructor(props) {
        super(props);

        this.state = {
            comboInput: '',
            ordenacionInput: '',
            comboResult: '',
            ordenacionResult: ''
        }

        this.response = "";
    }

    async getNumberOfConsecutiveLetters() {
        var self = this;
        axios.get('api/home/GetCombo/', { params: { cadena: self.state.comboInput } })
            .then(function (response) {
                self.setState({ comboResult: response.data });
            })
            .catch(function (response) {
                console.log(response);
            });
    }

    countLetters = () => {
        (async () => {
            await this.getNumberOfConsecutiveLetters();
        })();
    }


    async getOrdenacionPedidos() {
        var self = this;
        
        axios.get('api/home/GetOrdenacion/', { params: { cadena: self.state.ordenacionInput } })
            .then(function (response) {
                self.setState({ ordenacionResult: response.data });
            })
            .catch(function (response) {
                console.log(response);
            });
    }

    ordenarPedido = () => {
        (async () => {
            await this.getOrdenacionPedidos();
        })();
    }

    handleChangeCombo = (event) => {
        this.setState({ comboInput: event.target.value });
    }

    handleChangeOrdenacion = (event) => {
        this.setState({ ordenacionInput: event.target.value });
    }

    

  render () {
    return (
    <div>
        {/* CALCULAR COMBINACION 2 LETRAS */}
        <div className="row border border-dark rounded-lg p-2 m-2 h-50">
            <div className="col-12">
                <label className="col-12 text-left font-weight-bold">Cálculo de la combinación de dos letras más larga:</label>
                <textarea id="combo" name="combo" className="col-12" value={this.state.comboInput} onChange={this.handleChangeCombo} />
            </div>

            <div className="col-3">
                <button className="col-12" type="button" onClick={this.countLetters}> Calcular </button>
            </div>

            {/* RESULT COMBO: */}
            <div className="col-9">
                <b className="col-3 align-top"> RESULTADO: </b>
                <input className="col-9" type="text" value={this.state.comboResult} disabled />
            </div>
        </div>

        {/* ORDENAR LINEAS DE PEDIDO */}
        <div className="row  border border-dark rounded-lg p-2 m-2 h-50">
            <div className="col-12">
                <label className="col-12 text-left font-weight-bold">Ordenación de líneas de pedido:</label>
                <textarea id="ordena" name="ordena" className="col-12" value={this.state.ordenacionInput} onChange={this.handleChangeOrdenacion} />
            </div>

            <div className="col-3">
                <button className="col-12" type="button" onClick={this.ordenarPedido}> Calcular </button>
            </div>

            {/* RESULT ORDER: */}
            <div className="col-9">
                <b className="col-3 align-top"> RESULTADO: </b>
                <textarea className="col-9" type="text" value={this.state.ordenacionResult} disabled />
            </div>
        </div>
    </div>
    );
  }
}
