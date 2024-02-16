namespace MrDuck
{
    internal static class Services
    {
        public static T? GetService<T>() where T : class
        {
            return Application
                .Current!
                .Handler
                .MauiContext?
                .Services?
                .GetService<T>();
        }
    }
}
