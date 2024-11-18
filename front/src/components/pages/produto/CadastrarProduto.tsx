import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";
import styles from "./CadastrarProduto.module.css";

function CadastrarProduto() {
  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [quantidade, setQuantidade] = useState("");
  const [preco, setPreco] = useState("");
  const [categoriaId, setCategoriaId] = useState(0);
  //Criar a interface de categoria e realizar a tipagem
  const [categorias, setCategorias] = useState<any[]>([]);

  useEffect(() => {
    fetch("http://localhost:5117/api/categoria/listar")
      .then((resposta) => resposta.json())
      .then((categorias) => {
        setCategorias(categorias);
        console.table(categorias);
      });
  }, []);

  function enviarProduto(e: any) {
    const produto: Produto = {
      nome: nome,
      descricao: descricao,
      preco: Number(preco),
      quantidade: Number(quantidade),
      categoriaId: categoriaId,
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
    <div id="cadastro-produto" className={styles["cadastro-produto"]}>
      <h1 className={styles.h1}>Cadastrar Produto</h1>
      <form onSubmit={enviarProduto} className={styles.form}>
        <div className={styles["form-group"]}>
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

        <div className={styles["form-group"]}>
          <label htmlFor="descricao">Descrição</label>
          <textarea
            onChange={(e: any) => setDescricao(e.target.value)}
            id="descricao"
            name="descricao"
            required
            placeholder="Digite a descrição do produto"
          ></textarea>
        </div>

        <div className={styles["form-group"]}>
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

        <div className={styles["form-group"]}>
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

        <div className={styles["form-group"]}>
          <label htmlFor="categorias">Categorias</label>
          <select
            id="categoria"
            onChange={(e: any) => setCategoriaId(e.target.value)}
          >
            {categorias.map((categoria) => (
              <option key={categoria.id} value={categoria.id}>
                {categoria.nome}
              </option>
            ))}
          </select>
        </div>

        <div className={styles["form-actions"]}>
          <button type="submit">Cadastrar Produto</button>
        </div>
      </form>
    </div>
  );
}

export default CadastrarProduto;
