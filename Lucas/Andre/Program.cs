using Andre.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();


// app.MapGet("api/funcionario/cadastrar", ([F] FolhaDePagamento FolhaDePagamento, )) => {

// }

//GET: http://localhost:5093/api/produto/listar

// app.MapGet("/api/produto/listar",
//     ([FromServices] AppDataContext ctx) =>
// {
//     if (ctx.Funcionario.Any())
//     {
//         return Results.Ok(ctx.Funcionario.ToList());
//     }
//     return Results.NotFound("Tabela vazia!");
// });

//GET: http://localhost:5093/api/folha/listar

app.MapGet("/api/folha/listar",
    ([FromServices] AppDataContext ctx) =>
{
    if (ctx.FolhaDePagamentos.Any())
    {
        return Results.Ok(ctx.FolhaDePagamentos.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext ctx) =>
{

    //RN: Não permitir produtos com o mesmo nome
    Funcionario? funcionarioBuscado = ctx.FolhaDePagamentos.
        FirstOrDefault(x => x.Nome == funcionario.Nome);
    if (funcionarioBuscado is not null)
    {
        return Results.
            BadRequest("Já existe um produto com o mesmo nome!");
    }

    //Adicionar o produto dentro do banco de dados
    ctx.FolhaDePagamentos.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapPost("/api/folha/cadastrar", ([FromBody] FolhaDePagamento folhaDePagamento,
    [FromServices] AppDataContext ctx) =>
{

    //RN: Não permitir produtos com o mesmo nome
    Funcionario? funcionarioBuscado = ctx.FolhaDePagamentos.
        FirstOrDefault(x => x.Nome == folhaDePagamento.Nome);
    if (funcionarioBuscado is not null)
    {
        return Results.
            BadRequest("Já existe um produto com o mesmo nome!");
    }

    //Adicionar o produto dentro do banco de dados
    ctx.FolhaDePagamentos.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

// app.MapPost("api/funcionario/cadastrar", 
//     ([FromBody] FolhaDePagamento folhaDePagamento,
//     [FromServices] AppDbContext ctx)) => {

//     //     Produto? produtoBuscado = ctx.Produtos.
//     //     FirstOrDefault(x => x.Nome == produto.Nome);
//     // if (produtoBuscado is not null)
//     // {
//     //     return Results.
//     //         BadRequest("Já existe um produto com o mesmo nome!");
//     // }

//     // //Adicionar o produto dentro do banco de dados
//     // ctx.Produtos.Add(produto);
//     // ctx.SaveChanges();
//     // return Results.Created("", produto);

// }

app.Run();
