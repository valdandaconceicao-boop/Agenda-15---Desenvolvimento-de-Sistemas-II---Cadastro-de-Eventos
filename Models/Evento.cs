using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Models;

public class Evento : INotifyPropertyChanged
{
    private string _nome = string.Empty;
    private DateTime _dataInicio = DateTime.Today;
    private DateTime _dataTermino = DateTime.Today.AddDays(1);
    private int _numeroParticipantes;
    private string _local = string.Empty;
    private decimal _custoPorParticipante;

    public string Nome
    {
        get => _nome;
        set { _nome = value ?? string.Empty; OnPropertyChanged(); }
    }

    public DateTime DataInicio
    {
        get => _dataInicio;
        set { _dataInicio = value; OnPropertyChanged(); OnPropertyChanged(nameof(Duracao)); OnPropertyChanged(nameof(DuracaoDias)); }
    }

    public DateTime DataTermino
    {
        get => _dataTermino;
        set { _dataTermino = value; OnPropertyChanged(); OnPropertyChanged(nameof(Duracao)); OnPropertyChanged(nameof(DuracaoDias)); }
    }

    public int NumeroParticipantes
    {
        get => _numeroParticipantes;
        set { _numeroParticipantes = value; OnPropertyChanged(); OnPropertyChanged(nameof(CustoTotal)); }
    }

    public string Local
    {
        get => _local;
        set { _local = value ?? string.Empty; OnPropertyChanged(); }
    }

    public decimal CustoPorParticipante
    {
        get => _custoPorParticipante;
        set { _custoPorParticipante = value; OnPropertyChanged(); OnPropertyChanged(nameof(CustoTotal)); }
    }

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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}