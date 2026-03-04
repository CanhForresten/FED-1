using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Bilvaerksted.Data;
using Bilvaerksted.ViewModels;

namespace Bilvaerksted;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<Database>();

		builder.Services.AddSingleton<CreateInvoiceViewModel>();
		builder.Services.AddSingleton<ShowInvoiceViewModel>();

		builder.Services.AddTransient<Views.BookView>();
		builder.Services.AddTransient<Views.KalenderView>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
