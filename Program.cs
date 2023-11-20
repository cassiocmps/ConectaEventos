using ConectaEventos.Data;
using ConectaEventos.Models;
using ConectaEventos.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConectaEventosContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<FornecedorService>();
builder.Services.AddScoped<LocalService>();
builder.Services.AddScoped<PacoteService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<EventoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapWhen(context => context.Request.Path == "/", subApp =>
{
    subApp.Use((HttpContext context, Func<Task> next) =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
});

app.Run();
