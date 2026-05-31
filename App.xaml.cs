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
            Title = "Cadastro de Eventos - Dev Valdan Conceição França",
            MinimumWidth = 400,
            MinimumHeight = 600
        };

        window.Destroying += OnWindowDestroying;
        window.Created += OnWindowCreated;

        return window;
    }

    private void OnWindowCreated(object? sender, EventArgs e)
    {
        var window = sender as Window;
        if (window?.Handler?.PlatformView is Microsoft.UI.Xaml.Window winWindow)
        {
            winWindow.AppWindow.Closing += (s, args) =>
            {
                args.Cancel = true;
                winWindow.AppWindow.Hide();
            };
        }
    }

    private void OnWindowDestroying(object? sender, EventArgs e)
    {
        var window = sender as Window;
        if (window?.Handler?.PlatformView is Microsoft.UI.Xaml.Window winWindow)
        {
            winWindow.AppWindow.Closing -= null;
        }
    }
}