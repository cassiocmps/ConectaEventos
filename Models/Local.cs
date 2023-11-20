using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Models;

public class Local
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<LocalFoto> Fotos { get; set; } = new List<LocalFoto>();

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Local>()
            .HasOne(l => l.Endereco)
            .WithMany()
            .HasForeignKey(l => l.EnderecoId)
            .IsRequired();

        modelBuilder.Entity<Local>()
            .HasMany(l => l.Fotos)
            .WithOne(lf => lf.Local)
            .HasForeignKey(lf => lf.LocalId);
    }

}
