import React, {useEffect, useState} from "react";
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {
    const baseUrl = "https://localhost:7038/api/gestores";
    const [data, setData] = useState([]);

    const peticionGet = async () => {
        await axios.get(baseUrl)
            .then(response => {
                console.log(response.data);
                setData(response.data);
            }).catch(error => {
                console.log(error);
            })
    }

    useEffect(() => {
        peticionGet();
    }, [])

    return (
        <div className="App">
            <table className="table table-bordered">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Lanzamiento</th>
                    <th>Desarrollador</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {data.map(gestor => (

                    <tr key={gestor.id}>
                        <td>{gestor.id}</td>
                        <td>{gestor.name}</td>
                        <td>{gestor.launch}</td>
                        <td>{gestor.developer}</td>
                        <td>
                            <button className="btn btn-primary">Editar</button>
                            {"   "}
                            <button className="btn btn-danger">Eliminar</button>
                        </td>
                    </tr>
                ))}
                < /tbody>
            </table>

            <modal>
                <modalHeader>Insertar Gestor de base de datos</modalHeader>
                <modalBody>
                    <div className="form-group">
                        <label>Nombre</label>
                        <br/>
                        <input type="text" className="form-control"/>
                        <br/>
                        <label>Lanzamiento</label>
                        <br/>
                        <input type="text" className="form-control"/>
                        <br/>
                        <label>Desarrollador</label>
                        <br/>
                        <input type="text" className="form-control"/>
                        <br/>
                    </div>
                </modalBody>
                <modalFooter>
                    <button className="btn btn-primary">Insertar</button>
                    <button className="btn btn-danger">Cancelar</button>
                </modalFooter>
            </modal>
        </div>
    );
}

export default App;
