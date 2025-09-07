using GalleryApp.Services;
using GalleryApp.ViewModels;
using GalleryApp.Views;
using Microsoft.Extensions.Logging;

namespace GalleryApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IPhotoImporter>(serviceProvider => new PhotoImporter());
        builder.Services.AddTransient<ILocalStorage>(ServiceProvider => new MauiLocalStorage());

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<GalleryViewModel>();

        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<GalleryView>();

        return builder.Build();
    }
}