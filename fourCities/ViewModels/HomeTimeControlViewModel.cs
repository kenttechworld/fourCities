using CommunityToolkit.Mvvm.ComponentModel;
using fourCities.Handlers;
using System.Windows.Threading;

namespace fourCities.ViewModels
{
    public partial class HomeTimeControlViewModel : ObservableObject
    {
        private readonly DispatcherTimer _timer;

        [ObservableProperty]
        private string _currentTime = "00:00";

        public HomeTimeControlViewModel()
        {
            // Set up a timer to tick every 1 second
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += Timer_Tick;
            _timer.Start();

            RefreshTime();
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
