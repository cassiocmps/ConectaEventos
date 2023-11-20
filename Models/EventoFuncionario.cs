using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class EventoFuncionario
{
    [JsonIgnore]
    public virtual Evento Evento { get; set; }
    public int EventoId { get; set; }

    [JsonIgnore]
    public virtual Funcionario Funcionario { get; set; }
    public int FuncionarioId { get; set; }
}
