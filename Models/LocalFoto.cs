using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class LocalFoto
{
    public int Id { get; set; }

    public string NomeArquivo { get; set; } = null!;

    public int LocalId { get; set; }
    [JsonIgnore]
    public virtual Local Local { get; set; } = null!;

    public static void ConfigureModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocalFoto>()
            .HasOne(lf => lf.Local)
            .WithMany(l => l.Fotos)
            .HasForeignKey(lf => lf.LocalId)
            .IsRequired();
    }
}
