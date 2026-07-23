using CommunityToolkit.Mvvm.ComponentModel;
using fourCities.Extensions;
using fourCities.Handlers;
using fourCities.Model;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace fourCities.ViewModels
{
    public partial class CityIIIControlViewModel : ObservableObject
    {
        private readonly DispatcherTimer _timer;

        [ObservableProperty]
        private ObservableCollection<CityItemObservableProperty.CityItem> _cities = new();

        [ObservableProperty]
        private CityItemObservableProperty.CityItem? _selectedCity;

        [ObservableProperty]
        private string _currentTime = "00:00";

        [ObservableProperty]
        private int _comboboxTextSize = 1;

        [ObservableProperty]
        private int _clockSize = 1;

        public CityIIIControlViewModel()
        {
            ComboboxTextSize = TomlHandler.GetComboboxTextSizeSize();
            ClockSize = TomlHandler.GetClockLabelSize(); 
            AddCitesToList();

            SetComboboxToDefault();

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

        partial void OnSelectedCityChanged(CityItemObservableProperty.CityItem? value)
        {
            RefreshTime();
        }

        private void RefreshTime()
        {
            if (SelectedCity == null) return;

            CurrentTime = TimeZoneHandler.RefreshTimeZone(SelectedCity.EnumsValue.ToTimeZoneInfo());
        }

        private void AddCitesToList()
        {
            Cities.Clear();

            foreach (var item in TimeZoneHandler.OrderedEnumerableCityItems())
            {
                Cities.Add(item);
            }
        }

        private void SetComboboxToDefault()
        {
            if (Cities.Count > 0)
            {
                SelectedCity = Cities[0];
            }
        }
    }
}
