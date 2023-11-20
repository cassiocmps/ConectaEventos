using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class PacoteProduto
{
    public int IdPacote { get; set; }
    [JsonIgnore]
    public virtual Pacote Pacote { get; set; }

    public int IdProduto { get; set; }
    public virtual Produto Produto { get; set; }

    public int Quantidade { get; set; }

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PacoteProduto>()
            .HasKey(pp => new { pp.IdPacote, pp.IdProduto });

        modelBuilder.Entity<PacoteProduto>()
            .HasOne(pp => pp.Pacote)
            .WithMany(p => p.PacoteProdutos)
            .HasForeignKey(pp => pp.IdPacote);

        modelBuilder.Entity<PacoteProduto>()
            .HasOne(pp => pp.Produto)
            .WithMany()
            .HasForeignKey(pp => pp.IdProduto);
    }
}
