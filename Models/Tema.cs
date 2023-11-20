using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class Tema
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string Decoracao { get; set; } = null!;

    public decimal Valor { get; set; }
}
