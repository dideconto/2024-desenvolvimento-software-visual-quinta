import React from "react";
import ComponenteExemplo from "./components/pages/exemplos/ComponenteExemplo";
import ConsultarCEP from "./components/pages/exemplos/ConsultarCEP";
import ListarProdutos from "./components/pages/produto/ListarProdutos";
import CadastrarProduto from "./components/pages/produto/CadastrarProduto";

function App() {
  return (
    <div id="app">
      {/* <ConsultarCEP /> */}
      <CadastrarProduto />
      <ListarProdutos />
    </div>
  );
}

export default App;
