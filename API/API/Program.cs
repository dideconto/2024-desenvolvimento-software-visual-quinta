//Testar as APIs
// - Rest Client - Extensão do VS Code
// - Postman
// - Insomnia
//Minimal APIs

using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de produtos
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Camiseta", Preco = 29.99, Quantidade = 100 },
    new Produto { Nome = "Calça Jeans", Preco = 89.99, Quantidade = 50 },
    new Produto { Nome = "Tênis Esportivo", Preco = 199.99, Quantidade = 30 },
    new Produto { Nome = "Boné", Preco = 15.99, Quantidade = 200 },
    new Produto { Nome = "Jaqueta de Couro", Preco = 299.99, Quantidade = 20 },
    new Produto { Nome = "Óculos de Sol", Preco = 49.99, Quantidade = 75 },
    new Produto { Nome = "Mochila", Preco = 59.99, Quantidade = 40 },
    new Produto { Nome = "Relógio", Preco = 149.99, Quantidade = 10 },
    new Produto { Nome = "Camisa Social", Preco = 39.99, Quantidade = 60 },
    new Produto { Nome = "Tênis Casual", Preco = 129.99, Quantidade = 25 }
};

//Endpoints - Funcionalidade
//Request/Requisição - URL e o método/verbo HTTP
app.MapGet("/", () => "API de Produtos!");

//GET: http://localhost:5117/produto/listar
app.MapGet("/produto/listar", () =>
{
    return produtos;
});

//POST: http://localhost:5117/produto/cadastrar
app.MapPost("/produto/cadastrar/{nome}", (string nome) =>
{
    Produto produto = new Produto();
    produto.Nome = nome;
    produtos.Add(produto);
    return produtos;
});

//Criar novas funcionalidades/Endpoints para receber dados
// - Corpo da requisição
// - Estudar e entender qual é o código HTTP adequado 
//para um cadastro

app.Run();

// Produto produto = new Produto();
// produto.Preco = 789456;
// produto.setPreco(8800);
// Console.WriteLine("Preço: " + produto.Preco);
// Console.WriteLine("Preço: " + produto.getPreco());