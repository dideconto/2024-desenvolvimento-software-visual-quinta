import { useEffect } from "react";

function ConsultarCEP(){

    useEffect(() => {
        //Método utilizado para executar qualquer código enquanto
        //o componente está sendo aberto ou renderizado
        //Biblioteca de requisições - AXIOS
        fetch("https://viacep.com.br/ws/01001000/json/")
            .then(resposta => {
                return resposta.json();
            })
            .then(cep => {
                console.log(cep);
            });
    });

    return(
        <div>
            <h1>Consultar CEP</h1>
        </div>
    );
}

export default ConsultarCEP;

//EXERCÍCIOS
//1 - Exibir os dados do CEP no HTML
//2 - Realizar a requisição para a sua API
//3 - Resolver o problema de CORS na API
//4 - Exibir a lista de produtos no HTML