using Android.App;
using Android.Runtime;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
