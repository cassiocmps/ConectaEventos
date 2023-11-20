using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class EventoFuncionario
{
    public int EventoId { get; set; }
    [JsonIgnore]
    public virtual Evento Evento { get; set; }

    public int FuncionarioId { get; set; }
    public virtual Funcionario Funcionario { get; set; }

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventoFuncionario>()
            .HasKey(ef => new { ef.EventoId, ef.FuncionarioId });

        modelBuilder.Entity<EventoFuncionario>()
            .HasOne(ef => ef.Evento)
            .WithMany(e => e.EventoFuncionarios)
            .HasForeignKey(ef => ef.EventoId);

        modelBuilder.Entity<EventoFuncionario>()
            .HasOne(ef => ef.Funcionario)
            .WithMany()
            .HasForeignKey(ef => ef.FuncionarioId);
    }
}
