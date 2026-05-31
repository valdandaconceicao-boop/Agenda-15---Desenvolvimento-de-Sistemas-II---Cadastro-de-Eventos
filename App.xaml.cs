using Microsoft.Extensions.Logging;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos;

public partial class App : Application
{
    private static Window? _mainWindow;
    private static readonly object _lock = new();

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        lock (_lock)
        {
            if (_mainWindow == null)
            {
                var shell = new AppShell();
                _mainWindow = new Window(shell)
                {
                    Title = "Cadastro de Eventos - Dev Valdan Conceição França"
                };

                _mainWindow.Destroying += (s, e) =>
                {
                    lock (_lock)
                    {
                        _mainWindow = null;
                    }
                };
            }

            return _mainWindow;
        }
    }
}