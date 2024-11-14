import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";
import "./styles.css";

function ListarProdutos() {
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    consultarProdutos();
  }, []);

  function consultarProdutos() {
    fetch("http://localhost:5117/api/produto/listar")
      .then((resposta) => resposta.json())
      .then((produtos) => {
        setProdutos(produtos);
        console.table(produtos);
      });
  }

  return (
    <div id="listarprodutos">
      <h1>Listar Produtos</h1>
      <table>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Criado em</th>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr key={produto.id}>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.criadoEm}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListarProdutos;
