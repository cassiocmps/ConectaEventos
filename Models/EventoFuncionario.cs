using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class EventoFuncionario
{
    public int EventoId { get; set; }
    public virtual Evento Evento { get; set; }

    public int FuncionarioId { get; set; }
    public virtual Funcionario Funcionario { get; set; }
}
