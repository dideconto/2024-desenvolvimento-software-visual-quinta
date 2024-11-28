import React from "react";
import ListarTarefas from "./components/listar-tarefa";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import ListarTarefasConcluidas from "./components/listar-concluidas-tarefa";
import ListarTarefasNaoConcluidas from "./components/listar-nao-concluidas-tarefa copy";
import CadastrarTarefa from "./components/cadastrar-tarefa";

function App() {
  return (
    <div>
      <div>
        <BrowserRouter>
          <nav>
            <ul>
              <li>
                <Link to={"/"}>Home</Link>
              </li>
              <li>
                <Link to={"/pages/tarefa/listar"}>
                  Listar Tarefas{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/tarefa/listarconcluidas"}>
                  Listar Tarefas Concluídas{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/tarefa/listarnaoconcluidas"}>
                  Listar Tarefas Não Concluídas{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/tarefa/cadastrar"}>
                  Cadastrar Tarefa{" "}
                </Link>
              </li>
            </ul>
          </nav>
          <Routes>
            <Route path="/" element={<ListarTarefas />} />
            <Route
              path="/pages/tarefa/listar"
              element={<ListarTarefas />}
            />
            <Route
              path="/pages/tarefa/listarconcluidas"
              element={<ListarTarefasConcluidas />}
            />
            <Route
              path="/pages/tarefa/listarnaoconcluidas"
              element={<ListarTarefasNaoConcluidas />}
            />
            <Route
              path="/pages/tarefa/cadastrar"
              element={<CadastrarTarefa />}
            />
          </Routes>
          <footer>
            <p>Desenvolvido por Diogo Steinke Deconto</p>
          </footer>
        </BrowserRouter>
      </div>
    </div>
  );
}

export default App;
