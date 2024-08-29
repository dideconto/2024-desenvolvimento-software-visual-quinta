//Testar as APIs
// - Rest Client - Extensão do VS Code
// - Postman
// - Insomnia
//Minimal APIs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Endpoints - Funcionalidade
//Request/Requisição - URL e o método/verbo HTTP
app.MapGet("/", () => "Hello World em C#!");

app.MapGet("/segundafuncionalidade", () => "Segunda funcionalidade");

app.MapGet("/retornarendereco", () =>
{
    dynamic endereco = new
    {
        rua = "Praça Osório",
        numero = 125
    };
    return endereco;
});

//Criar novas funcionalidades/Endpoints para receber dados
// - Pelo URL da requisição
// - Corpo da requisição
//Guardar as informações em uma lista

app.Run();
