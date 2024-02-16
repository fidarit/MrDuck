using Microsoft.Extensions.Logging;

namespace MrDuck
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
builder.Services.AddLogging(
    configure =>
    {
        configure.AddDebug();

#if ANDROID
        configure.AddConsole();
#endif

    }
);
#endif     

            return builder.Build();
        }
    }
}
