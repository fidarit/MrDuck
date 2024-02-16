using MrDuck.Services;

namespace MrDuck.ViewModels
{
    internal class MainPageVM
    {
        public Command QuackLocalCommand { get; }
        public Command QuackRemoteCommand { get; }

        public MainPageVM()
        {
            QuackLocalCommand = new(async _ => await SoundPlayer.Instance.Play());
            QuackRemoteCommand = new(_ => { /* TODO */});
        }
    }
}
