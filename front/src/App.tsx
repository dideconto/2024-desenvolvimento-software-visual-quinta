import React from "react";
import ComponenteExemplo from "./components/pages/exemplos/ComponenteExemplo";
import ConsultarCEP from "./components/pages/exemplos/ConsultarCEP";
import ListarProdutos from "./components/pages/produto/ListarProdutos";
import CadastrarProduto from "./components/pages/produto/CadastrarProduto";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import "./styles.css";
import ProdutoAlterar from "./components/pages/produto/ProdutoAlterar";

function App() {
  return (
    <div id="app">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/"> Home </Link>
            </li>
            <li>
              <Link to="/pages/produto/listar">
                {" "}
                Listar Produtos{" "}
              </Link>
            </li>
            <li>
              <Link to="/pages/produto/cadastrar">
                {" "}
                Cadastrar Produto{" "}
              </Link>
            </li>
            <li>
              <Link to="/pages/endereco/consultar">
                {" "}
                Consultar CEP{" "}
              </Link>
            </li>
          </ul>
        </nav>
        <div id="conteudo">
          <Routes>
            <Route path="/" element={<ListarProdutos />} />
            <Route
              path="/pages/produto/listar"
              element={<ListarProdutos />}
            />
            <Route
              path="/pages/produto/cadastrar"
              element={<CadastrarProduto />}
            />
            <Route
              path="/pages/endereco/consultar"
              element={<ConsultarCEP />}
            />
            <Route
              path="/pages/produto/alterar/:id"
              element={<ProdutoAlterar />}
            />
          </Routes>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
