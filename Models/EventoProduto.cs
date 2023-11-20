using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class EventoProduto
{
    public int EventoId { get; set; }
    [JsonIgnore]
    public virtual Evento Evento { get; set; }

    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventoProduto>()
            .HasKey(ep => new { ep.EventoId, ep.ProdutoId });

        modelBuilder.Entity<EventoProduto>()
            .HasOne(ep => ep.Evento)
            .WithMany(e => e.EventoProdutos)
            .HasForeignKey(ep => ep.EventoId);

        modelBuilder.Entity<EventoProduto>()
            .HasOne(ep => ep.Produto)
            .WithMany()
            .HasForeignKey(ep => ep.ProdutoId);
    }
}
