using MediatR;
using SilentHill.Application.Criaturas.Queries;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar o MediatR na API e dizer para ele procurar os Handlers no projeto Application
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCriaturasQuery).Assembly));

// 2. Configurar o CORS (Crucial para o Blazor conseguir acessar a API sem bloqueio do navegador)
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Ativar o CORS antes das rotas
app.UseCors("BlazorPolicy");

// 3. O nosso Endpoint de Silent Hill usando o MediatR
app.MapGet("/api/criaturas", async (IMediator mediator) =>
{
    // A API simplesmente recebe a requisição e despacha a Query pelo MediatR
    var resultado = await mediator.Send(new GetCriaturasQuery());
    return Results.Ok(resultado);
});

app.Run();