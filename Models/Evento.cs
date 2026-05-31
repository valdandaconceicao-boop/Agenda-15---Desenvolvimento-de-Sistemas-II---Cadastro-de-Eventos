using System;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Models;

public class Evento
{
    public string Nome { get; set; } = string.Empty;

    public DateTime DataInicio { get; set; } = DateTime.Today;

    public DateTime DataTermino { get; set; } = DateTime.Today.AddDays(1);

    public int NumeroParticipantes { get; set; }

    public string Local { get; set; } = string.Empty;

    public decimal CustoPorParticipante { get; set; }

    public TimeSpan Duracao => DataTermino - DataInicio;

    public int DuracaoDias
    {
        get
        {
            int dias = Duracao.Days;
            return dias < 0 ? 0 : dias;
        }
    }

    public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;
}
