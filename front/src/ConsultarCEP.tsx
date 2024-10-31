import { useEffect, useState } from "react";

function ConsultarCEP(){

    const [bairro, setBairro] = useState("");
    const [localidade, setLocalidade] = useState("");
    const [logradouro, setLogradouro] = useState("");
    const [cep, setCep] = useState("");

    useEffect(() => {
        //Método utilizado para executar qualquer código enquanto
        //o componente está sendo aberto ou renderizado
        //Biblioteca de requisições - AXIOS
        //consultarCEP();
    });

    function consultarCEP(){
        fetch("https://viacep.com.br/ws/" + cep + "/json/")
        .then(resposta => resposta.json())
        .then(endereco => {
            setBairro(endereco.bairro);
            setLocalidade(endereco.localidade);
            setLogradouro(endereco.logradouro);
        });
    }

    function perderFoco(){
        // consultarCEP();
    }

    function digitar(event : any){
        setCep(event.target.value);
    }

    function clicar(){
        consultarCEP();
    }

    return(
        <div id="consultarcep">
            <h1>Consultar CEP</h1>

            <input type="text"
                placeholder="Digite um CEP"
                onBlur={perderFoco} 
                onChange={digitar}/>

            <button onClick={clicar}>Consultar CEP</button>

            <p>{localidade}</p>
            <p>{bairro}</p>
            <p>{logradouro}</p>
        </div>
    );
}

export default ConsultarCEP;

//EXERCÍCIOS
//1 - Exibir os dados do CEP no HTML
//2 - Realizar a requisição para a sua API
//3 - Resolver o problema de CORS na API
//4 - Exibir a lista de produtos no HTML