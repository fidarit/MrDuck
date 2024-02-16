using Plugin.Maui.Audio;

namespace MrDuck.Services
{
    internal class SoundPlayer
    {
        public static SoundPlayer Instance => Bootstrap.GetService<SoundPlayer>();

        private const string SoundName = "quack.mp3";

        public async Task Play()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync(SoundName);
                using var player = AudioManager.Current.CreateAsyncPlayer(stream);

                player.Volume = 0.5f;

                await player.PlayAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }
}
