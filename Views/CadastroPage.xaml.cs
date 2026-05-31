using Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Models;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Views;

public partial class CadastroPage : ContentPage
{
    private Evento _evento;

    public CadastroPage()
    {
        InitializeComponent();
        _evento = new Evento();
        BindingContext = _evento;
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_evento.Nome))
        {
            await DisplayAlert("Campo Obrigatório", "Por favor, informe o nome do evento.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(_evento.Local))
        {
            await DisplayAlert("Campo Obrigatório", "Por favor, informe o local do evento.", "OK");
            return;
        }

        if (_evento.DataTermino < _evento.DataInicio)
        {
            await DisplayAlert("Data Inválida", "A data de término não pode ser anterior à data de início.", "OK");
            return;
        }

        if (_evento.NumeroParticipantes <= 0)
        {
            await DisplayAlert("Valor Inválido", "O número de participantes deve ser maior que zero.", "OK");
            return;
        }

        if (_evento.CustoPorParticipante < 0)
        {
            await DisplayAlert("Valor Inválido", "O custo por participante não pode ser negativo.", "OK");
            return;
        }

        var parameters = new Dictionary<string, object>
        {
            { "Evento", _evento }
        };
        await Shell.Current.GoToAsync("ResumoPage", parameters);
    }
}