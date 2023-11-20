using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Models;

public class Evento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateOnly Data { get; set; }

    public decimal ValorTotal { get; set; }

    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; } = null!;

    public int LocalId { get; set; }
    public virtual Local Local { get; set; } = null!;
    
    public int? PacoteId { get; set; }
    public virtual Pacote? Pacote { get; set; }
    
    public int? TemaId { get; set; }
    public virtual Tema? Tema { get; set; }

    public virtual ICollection<EventoFuncionario> EventoFuncionarios { get; set; } = new List<EventoFuncionario>();

    public virtual ICollection<EventoProduto> EventoProdutos { get; set; } = new List<EventoProduto>();

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Cliente)
            .WithMany()
            .HasForeignKey(e => e.ClienteId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Local)
            .WithMany()
            .HasForeignKey(e => e.LocalId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Pacote)
            .WithMany()
            .HasForeignKey(e => e.PacoteId);

        modelBuilder.Entity<Evento>()
            .HasOne(e => e.Tema)
            .WithMany()
            .HasForeignKey(e => e.TemaId);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.EventoFuncionarios)
            .WithOne(ef => ef.Evento)
            .HasForeignKey(ef => ef.EventoId);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.EventoProdutos)
            .WithOne(ep => ep.Evento)
            .HasForeignKey(ep => ep.EventoId);
    }

}
