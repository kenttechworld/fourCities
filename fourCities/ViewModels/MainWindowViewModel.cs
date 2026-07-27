using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using fourCities.Messages;

namespace fourCities.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IRecipient<ChangeFontSizeMessage>
    {
        public HomeTimeControlViewModel HometownVM { get; } = new();
        public CityIControlViewModel CityIVM { get; } = new();
        public CityIIControlViewModel CityIIVM { get; } = new();
        public CityIIIControlViewModel CityIIIVM { get; } = new();

        public MainWindowViewModel()
        {
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public void Receive(ChangeFontSizeMessage message)
        {
            // Cascade refresh calls
            HometownVM.ClockSize = message.NewFontSize;
            CityIVM.ClockSize = message.NewFontSize;
            CityIIVM.ClockSize = message.NewFontSize;
            CityIIIVM.ClockSize = message.NewFontSize;
        }
    }
}