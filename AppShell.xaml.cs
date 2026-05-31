using Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos.Views;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ResumoPage), typeof(ResumoPage));
    }
}
