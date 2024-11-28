import { useEffect, useState } from "react";
import { Tarefa } from "../models/tarefa";
import axios from "axios";

function ListarTarefas() {
  const [tarefas, setTarefas] = useState<Tarefa[]>([]);

  useEffect(() => {
    carregarTarefas();
  }, []);

  function carregarTarefas() {
    //FETCH ou AXIOS
    fetch("http://localhost:5000/tarefas/listar")
      .then((resposta) => resposta.json())
      .then((tarefas: Tarefa[]) => {
        console.table(tarefas);
        setTarefas(tarefas);
      });
  }

  function alterar(id: string) {
    console.log(`Id: ${id}`);
    axios
      .put(`http://localhost:5000/tarefas/alterar/${id}`)
      .then((resposta) => {
        setTarefas(resposta.data);
      });
  }

  return (
    <div>
      <h1>Listar Tarefas</h1>
      <table border={1}>
        <thead>
          <tr>
            <th>#</th>
            <th>Títulos</th>
            <th>Descrição</th>
            <th>Status</th>
            <th>Criado Em</th>
            <th>Alterar Status</th>
          </tr>
        </thead>
        <tbody>
          {tarefas.map((tarefa) => (
            <tr key={tarefa.tarefaId}>
              <td>{tarefa.tarefaId}</td>
              <td>{tarefa.titulo}</td>
              <td>{tarefa.descricao}</td>
              <td>{tarefa.status}</td>
              <td>{tarefa.criadoEm}</td>
              <td>
                <button
                  onClick={() => {
                    alterar(tarefa.tarefaId!);
                  }}
                >
                  Alterar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListarTarefas;
