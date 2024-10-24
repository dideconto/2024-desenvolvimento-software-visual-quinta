//REGRAS PARA CRIAÇÃO DE UM COMPONENTE
//1 - A primeira letra do componente de ser maiúscula
//2 - Todo componente deve ser uma função
//3 - Todo componente DEVE RETORNAR APENAS UM elemento HTML
//4 - Todo componente deve ser exportado

function ComponenteExemplo(){
    return(
        <div>
            <h1>Primeiro post</h1>
            <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Excepturi deserunt quasi dolores nobis numquam eum voluptatibus nam. Minus perspiciatis distinctio accusantium voluptatum iste odit beatae hic, mollitia tempore, quos numquam.</p>
        </div>
    );
}

export default ComponenteExemplo;