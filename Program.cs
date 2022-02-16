using Agenda.Data;
using Agenda.Data.Repositorios;
using Agenda.Model;
using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Services;
using Agendamento.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando banco de dados
builder.Services.AddDbContext<ContatoContexto>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("AgendaDB")));

builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
