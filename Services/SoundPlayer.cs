using Plugin.Maui.Audio;

namespace MrDuck.Services
{
    internal class SoundPlayer
    {
        public static SoundPlayer Instance => Bootstrap.GetService<SoundPlayer>();

        private const string SoundName = "quack.mp3";

        private byte[] soundBuffer;

        private async Task<byte[]> GetSoundBuffer()
        {
            if (soundBuffer?.Length > 0)
                return soundBuffer;

            else
            {
                using var sourceStream = await FileSystem.OpenAppPackageFileAsync(SoundName);
                var memoryStream = new MemoryStream();

                await sourceStream.CopyToAsync(memoryStream);

                soundBuffer = memoryStream.ToArray();

                return soundBuffer;
            }
        }

        public async Task Play()
        {
            try
            {
                using var stream = new MemoryStream(await GetSoundBuffer());
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
