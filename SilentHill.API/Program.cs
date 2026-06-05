using MediatR;
using SilentHill.Application.Criaturas.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCriaturasQuery).Assembly));

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

app.UseCors("BlazorPolicy");

app.MapGet("/api/criaturas", async (IMediator mediator) =>
{
    var resultado = await mediator.Send(new GetCriaturasQuery());
    return Results.Ok(resultado);
});

app.Run();