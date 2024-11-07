import { useState } from "react";
import "./styles.css";
import { Produto } from "../../../models/Produto";

function CadastrarProduto() {
  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [quantidade, setQuantidade] = useState("");
  const [preco, setPreco] = useState("");

  function enviarProduto(e: any) {
    const produto: Produto = {
      nome: nome,
      descricao: descricao,
      preco: Number(preco),
      quantidade: Number(quantidade),
    };

    //AXIOS - Biblioteca para requisições HTTP - Recomendação

    fetch("http://localhost:5117/api/produto/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(produto),
    })
      .then((resposta) => resposta.json())
      .then((produto) => {
        console.log(produto);
      });
    e.preventDefault();
  }

  return (
    <div id="cadastro-produto">
      <h1>Cadastrar Produto</h1>
      <form onSubmit={enviarProduto} id="formProduto">
        <div className="form-group">
          <label htmlFor="nome">Nome</label>
          <input
            onChange={(e: any) => setNome(e.target.value)}
            type="text"
            id="nome"
            name="nome"
            required
            placeholder="Digite o nome do produto"
          />
        </div>

        <div className="form-group">
          <label htmlFor="descricao">Descrição</label>
          <textarea
            onChange={(e: any) => setDescricao(e.target.value)}
            id="descricao"
            name="descricao"
            required
            placeholder="Digite a descrição do produto"
          ></textarea>
        </div>

        <div className="form-group">
          <label htmlFor="quantidade">Quantidade</label>
          <input
            onChange={(e: any) => setQuantidade(e.target.value)}
            type="number"
            id="quantidade"
            name="quantidade"
            required
            placeholder="Digite a quantidade disponível"
          />
        </div>

        <div className="form-group">
          <label htmlFor="preco">Preço</label>
          <input
            onChange={(e: any) => setPreco(e.target.value)}
            type="number"
            id="preco"
            name="preco"
            required
            step="0.01"
            placeholder="Digite o preço do produto"
          />
        </div>

        <div className="form-actions">
          <button type="submit">Cadastrar Produto</button>
        </div>
      </form>
    </div>
  );
}

export default CadastrarProduto;
