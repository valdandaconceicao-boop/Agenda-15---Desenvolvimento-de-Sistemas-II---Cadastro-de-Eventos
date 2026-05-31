using Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Models;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Views;

public partial class ResumoPage : ContentPage, IQueryAttributable
{
    private Evento? _evento;

    public ResumoPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Evento", out var eventoObj) && eventoObj is Evento evento)
        {
            _evento = evento;
            BindingContext = _evento;
        }
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
