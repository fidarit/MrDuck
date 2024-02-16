using MrDuck.Services;
using MrDuck.ViewModels;

namespace MrDuck
{
    internal static class Bootstrap
    {
        public static T GetService<T>() where T : class
        {
            return Application
                .Current
                .Handler
                .MauiContext?
                .Services?
                .GetService<T>();
        }

        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder appBuilder)
        {
            var services = appBuilder.Services;

            services.AddSingleton<SoundPlayer>();
            services.AddSingleton<MainPageVM>();

            return appBuilder;
        }
    }
}
