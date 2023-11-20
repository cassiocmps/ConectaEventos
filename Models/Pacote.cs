using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class Pacote
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int FornecedorId { get; set; }
    [JsonIgnore]
    public virtual Fornecedor? Fornecedor{ get; set; }

    public int? TemaId { get; set; }
    [JsonIgnore]
    public virtual Tema? Tema { get; set; }

    public virtual ICollection<PacoteProduto> PacoteProdutos { get; set; } = new List<PacoteProduto>();

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pacote>()
            .HasOne(p => p.Fornecedor)
            .WithMany(f => f.Pacotes)
            .HasForeignKey(p => p.FornecedorId);

        modelBuilder.Entity<Pacote>()
            .HasOne(p => p.Tema)
            .WithMany()
            .HasForeignKey(p => p.TemaId);

        modelBuilder.Entity<Pacote>()
            .HasMany(p => p.PacoteProdutos)
            .WithOne(pp => pp.Pacote)
            .HasForeignKey(pp => pp.IdPacote);
    }
}
