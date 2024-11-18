import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";
import styles from "./ProdutoLista.module.css";
import { Link } from "react-router-dom";
import axios from "axios";

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

  function deletar(id: string) {
    axios
      .delete(`http://localhost:5020/api/produto/deletar/${id}`)
      .then((resposta) => {
        console.log(resposta.data);
      });
  }

  return (
    <div id="listarprodutos" className="container">
      <h1>Listar Produtos</h1>
      <table className={styles.table}>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Criado em</th>
            <th>Deletar</th>
            <th>Alterar</th>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr key={produto.id}>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.criadoEm}</td>
              <td>
                <button onClick={() => deletar(produto.id!)}>
                  Deletar
                </button>
              </td>
              <td>
                <Link to={`/pages/produto/alterar/${produto.id}`}>
                  Alterar
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListarProdutos;
