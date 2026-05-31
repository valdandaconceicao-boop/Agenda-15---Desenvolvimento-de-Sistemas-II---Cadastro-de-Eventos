using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Agenda_15___Desenvolvimento_de_Sistemas_II___Cadastro_de_Eventos;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
