using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fourCities.Handlers;
using fourCities.Windows;
using System.Windows;
using System.Windows.Threading;

namespace fourCities.ViewModels
{
    public partial class HomeTimeControlViewModel : ObservableObject
    {
        private readonly DispatcherTimer _timer;

        [ObservableProperty]
        private string _currentTime = "00:00";

        [ObservableProperty]
        private int _labelSize = 1;

        [ObservableProperty]
        private int _clockSize = 1;

        public HomeTimeControlViewModel()
        {
            LabelSize = TomlHandler.GetLabelSize();
            ClockSize = TomlHandler.GetClockLabelSize();
            // Set up a timer to tick every 1 second
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += Timer_Tick;
            _timer.Start();

            RefreshTime();
        }

        [RelayCommand]
        private void OpenSettingsWindow() 
        {
            SettingWindow settingsWindow = new SettingWindow 
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            settingsWindow.ShowDialog();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            RefreshTime();
        }

        private void RefreshTime()
        {
            CurrentTime = TimeZoneHandler.GetLocalTime();
        }

    }
}
