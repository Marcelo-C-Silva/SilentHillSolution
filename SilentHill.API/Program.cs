using MediatR;
using Microsoft.EntityFrameworkCore;
using SilentHill.Application.Criaturas;
using SilentHill.Application.Criaturas.Commands;
using SilentHill.Application.Criaturas.Queries;
using SilentHill.Infrastructure.Persistence;
using SilentHill.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDb") ?? "Data Source=silenthill.db"));

builder.Services.AddScoped<ICriaturaRepository, CriaturaRepository>();

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("BlazorPolicy");

app.MapGet("/api/criaturas", async (IMediator mediator) =>
{
    var resultado = await mediator.Send(new GetCriaturasQuery());
    return Results.Ok(resultado);
});

app.MapPost("/api/criaturas", async (CreateCriaturaCommand command, IMediator mediator) =>
{
    var resultado = await mediator.Send(command);
    return Results.Created($"/api/criaturas/{resultado.Id}", resultado);
});

app.Run();
