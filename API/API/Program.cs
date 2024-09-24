//Testar as APIs
// - Rest Client - Extensão do VS Code
// - Postman
// - Insomnia
//Minimal APIs

using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de produtos
List<Produto> produtos =
[
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
];

//Endpoints - Funcionalidade
//Request/Requisição - URL e o método/verbo HTTP
//Response/Resposta - Dados (json ou xml) e códigos de status HTTP
app.MapGet("/", () => "API de Produtos");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count > 0)
    {
        return Results.Ok(produtos);
    }
    return Results.NotFound();
});

//GET: /api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id) =>
{
    Produto? produto = produtos.Find(x => x.Id == id);
    if (produto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(produto);
});

//POST: /api/produto/cadastrar/param_nome
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    produtos.Add(produto);
    return Results.Created("", produto);
});

//DELETE: /api/produto/deletar/{id}
app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] string id) =>
{
    Produto? produto = produtos.Find(x => x.Id == id);
    if (produto == null)
    {
        return Results.NotFound();
    }
    produtos.Remove(produto);
    return Results.Ok(produto);
});

//PUT: /api/produto/alterar/{id}
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) =>
{
    Produto? produto = produtos.Find(x => x.Id == id);
    if (produto == null)
    {
        return Results.NotFound();
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Quantidade = produtoAlterado.Quantidade;
    produto.Preco = produtoAlterado.Preco;
    return Results.Ok(produto);
});

app.Run();