using Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Models;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Views;

public partial class CadastroPage : ContentPage
{
    public CadastroPage()
    {
        InitializeComponent();
        BindingContext = new Evento();
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        var evento = BindingContext as Evento;

        if (evento == null)
            return;

        if (string.IsNullOrWhiteSpace(evento.Nome))
        {
            await DisplayAlert("Campo Obrigatório", "Por favor, informe o nome do evento.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(evento.Local))
        {
            await DisplayAlert("Campo Obrigatório", "Por favor, informe o local do evento.", "OK");
            return;
        }

        if (evento.DataTermino < evento.DataInicio)
        {
            await DisplayAlert("Data Inválida", "A data de término não pode ser anterior à data de início.", "OK");
            return;
        }

        if (evento.NumeroParticipantes <= 0)
        {
            await DisplayAlert("Valor Inválido", "O número de participantes deve ser maior que zero.", "OK");
            return;
        }

        if (evento.CustoPorParticipante < 0)
        {
            await DisplayAlert("Valor Inválido", "O custo por participante não pode ser negativo.", "OK");
            return;
        }

        var parameters = new Dictionary<string, object>
        {
            { "Evento", evento }
        };
        await Shell.Current.GoToAsync("ResumoPage", parameters);
    }
}
