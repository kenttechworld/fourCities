using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using fourCities.Handlers;
using fourCities.Messages;
using System.Collections.ObjectModel;

namespace fourCities.ViewModels
{
    public partial class SettingsWindowViewModel : ObservableObject
    {
        private static string currentClockSize = TomlHandler.GetClockLabelSize().ToString();

        [ObservableProperty]
        private string _clockSize = currentClockSize;

        [ObservableProperty]
        private ObservableCollection<string> _locations = new();

        [ObservableProperty]
        private string? _selectedCity;

        [ObservableProperty]
        private int _comboboxTextSize = 1;

        [ObservableProperty]
        private string _tz1 = string.Empty;

        [ObservableProperty]
        private string _tz2 = string.Empty;

        [ObservableProperty]
        private string _tz3 = string.Empty;

        public SettingsWindowViewModel()
        {
            ComboboxTextSize = TomlHandler.GetComboboxTextSizeSize();
            populateTimeZoneLabels();

            Locations = new ObservableCollection<string>(TimeZoneHandler.timeZoneCityList);
            SelectedCity = Locations.FirstOrDefault();
        }

        [RelayCommand]
        private void SetNewClockSize()
        {
            if (int.TryParse(ClockSize, out int newSize))
            {
                TomlHandler.UpdateTomlField("ClockLabel", newSize);
                // Broadcasts the new font size to all controls instantly
                WeakReferenceMessenger.Default.Send(new ChangeFontSizeMessage(newSize));
            }
        }

        [RelayCommand]
        private void SetTimeZone1()
        {
            Tz1 = SelectedCity;
            TomlHandler.UpdateTomlField("TZ1", SelectedCity);
        }

        [RelayCommand]
        private void SetTimeZone2()
        {
            Tz2 = SelectedCity;
            TomlHandler.UpdateTomlField("TZ2", SelectedCity);
        }

        [RelayCommand]
        private void SetTimeZone3()
        {
            Tz3 = SelectedCity;
            TomlHandler.UpdateTomlField("TZ3", SelectedCity);
        }

        private void populateTimeZoneLabels()
        {
            Tz1 = TimeZoneHandler.GetStoredTimeZone("TZ1") ?? string.Empty;
            Tz2 = TimeZoneHandler.GetStoredTimeZone("TZ2") ?? string.Empty;
            Tz3 = TimeZoneHandler.GetStoredTimeZone("TZ3") ?? string.Empty;
        }
    }
}
