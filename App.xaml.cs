namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell())
        {
            Title = "Cadastro de Eventos - Dev Valdan Conceição França"
        };

        return window;
    }
}