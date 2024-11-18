//Testar as APIs
// - Rest Client - Extensão do VS Code
// - Postman
// - Insomnia
//Minimal APIs

using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddCors(
    options =>
        options.AddPolicy("Acesso Total",
            configs => configs
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
);
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

//GET: /api/categoria/listar
app.MapGet("/api/categoria/listar", ([FromServices] AppDataContext ctx) =>
{
    // if (ctx.Produtos.Count() > 0)
    if (ctx.Categorias.Any())
    {
        return Results.Ok(ctx.Categorias.ToList());
    }
    return Results.NotFound();
});

//POST: /api/categoria/cadastrar
app.MapPost("/api/categoria/cadastrar", ([FromBody] Categoria categoria,
    [FromServices] AppDataContext ctx) =>
{
    ctx.Categorias.Add(categoria);
    ctx.SaveChanges();
    return Results.Created("", categoria);
});

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    // if (ctx.Produtos.Count() > 0)
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.Include(x => x.Categoria).ToList());
    }
    return Results.NotFound();
});

//GET: /api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda em c#
    // Produto? produto = ctx.Produtos.FirstOrDefault(x => x.Quantidade> 10);
    // List<Produto> lista = ctx.Produtos.Where(x => x.Nome == "Coca").ToList();   
    Produto? produto = ctx.Produtos.Find(id);
    if (produto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(produto);
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto,
    [FromServices] AppDataContext ctx) =>
{
    Categoria? categoria = ctx.Categorias.Find(produto.CategoriaId);
    if (categoria is null)
    {
        return Results.NotFound();
    }
    produto.Categoria = categoria;
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

//DELETE: /api/produto/deletar/{id}
app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);
    if (produto == null)
    {
        return Results.NotFound();
    }
    ctx.Produtos.Remove(produto);
    ctx.SaveChanges();
    return Results.Ok(produto);
});

//PUT: /api/produto/alterar/{id}
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id,
    [FromBody] Produto produtoAlterado,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);
    if (produto == null)
    {
        return Results.NotFound();
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Quantidade = produtoAlterado.Quantidade;
    produto.Preco = produtoAlterado.Preco;
    ctx.Produtos.Update(produto);
    ctx.SaveChanges();
    return Results.Ok(produto);
});

app.UseCors("Acesso Total");
app.Run();