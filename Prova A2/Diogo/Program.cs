using System.Security.Cryptography;
using Diogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Prova A2 em dupla com consulta!");

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created($"/produto/{funcionario.Id}", funcionario);
});

app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Funcionarios.ToList());
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha,
    [FromServices] AppDataContext ctx) =>
{
    //Validar se o funcionário existe
    Funcionario? funcionario =
        ctx.Funcionarios.Find(folha.FuncionarioId);

    if (funcionario is null)
        return Results.NotFound("Funcionário não encontrado");

    folha.Funcionario = funcionario;

    //Calcular o salário bruto
    folha.SalarioBruto = folha.Quantidade * folha.Valor;

    //Calcular o IRRF
    if (folha.SalarioBruto <= 1903.98)
        folha.ImpostoIRRF = 0;
    if (folha.SalarioBruto <= 2826.65)
        folha.ImpostoIRRF = (folha.SalarioBruto * .075) - 142.80;
    if (folha.SalarioBruto <= 3751.05)
        folha.ImpostoIRRF = (folha.SalarioBruto * .15) - 354.80;
    if (folha.SalarioBruto <= 4664.68)
        folha.ImpostoIRRF = (folha.SalarioBruto * .225) - 636.13;
    else
        folha.ImpostoIRRF = (folha.SalarioBruto * .275) - 869.36;

    //Calcular o INSS
    if (folha.SalarioBruto <= 1693.72)
        folha.ImpostoINSS = folha.SalarioBruto * .08;
    if (folha.SalarioBruto <= 2822.90)
        folha.ImpostoINSS = folha.SalarioBruto * .09;
    if (folha.SalarioBruto <= 5645.80)
        folha.ImpostoINSS = folha.SalarioBruto * .11;
    else
        folha.ImpostoINSS = 621.04;

    //Calcular o FGTS
    folha.ImpostoFGTS = folha.SalarioBruto * .08;

    //Calcular o salário líquido
    folha.SalarioLiquido = folha.SalarioBruto - folha.ImpostoIRRF - folha.ImpostoINSS;

    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created($"/produto/{folha.Id}", folha);
});

app.MapGet("/api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Folhas.Include(x => x.Funcionario).ToList());
});

app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", ([FromServices] AppDataContext ctx,
    [FromRoute] int mes, [FromRoute] int ano, [FromRoute] string cpf) =>
{
    Folha? folha = ctx.Folhas.
        Include(x => x.Funcionario).
        FirstOrDefault(f => f.Funcionario.CPF == cpf && f.Mes == mes && f.Ano == ano);
    if (folha is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folha);
});

app.Run();
