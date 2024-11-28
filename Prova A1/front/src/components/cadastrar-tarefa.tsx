import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Categoria } from "../models/categoria";
import { Tarefa } from "../models/tarefa";

function CadastrarTarefa() {
  const navigate = useNavigate();
  const [titulo, setTitulo] = useState("");
  const [descricao, setDescricao] = useState("");
  const [categoriaId, setCategoriaId] = useState("");
  const [categorias, setCategorias] = useState<Categoria[]>([]);

  useEffect(() => {
    carregarCategorias();
  }, []);

  function carregarCategorias() {
    //FETCH ou AXIOS
    fetch("http://localhost:5000/categoria/listar")
      .then((resposta) => resposta.json())
      .then((categorias: Categoria[]) => {
        setCategorias(categorias);
      });
  }

  function cadastrarTarefa(e: any) {
    const tarefa: Tarefa = {
      titulo: titulo,
      descricao: descricao,
      categoriaId: categoriaId,
    };

    //FETCH ou AXIOS
    fetch("http://localhost:5000/tarefas/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(tarefa),
    })
      .then((resposta) => resposta.json())
      .then((tarefa: Tarefa) => {
        navigate("/pages/tarefa/listar");
      });
    e.preventDefault();
  }

  return (
    <div>
      <h1>Cadastrar Tarefa</h1>
      <form onSubmit={cadastrarTarefa}>
        <label>Título:</label>
        <input
          type="text"
          placeholder="Digite o título"
          onChange={(e: any) => setTitulo(e.target.value)}
          required
        />
        <br />
        <label>Descricao:</label>
        <input
          type="text"
          placeholder="Digite o descrição"
          onChange={(e: any) => setDescricao(e.target.value)}
        />
        <br />
        <label>Categorias:</label>
        <select onChange={(e: any) => setCategoriaId(e.target.value)}>
          {categorias.map((categoria) => (
            <option
              value={categoria.categoriaId}
              key={categoria.categoriaId}
            >
              {categoria.nome}
            </option>
          ))}
        </select>
        <br />
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default CadastrarTarefa;
