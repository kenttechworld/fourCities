using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fourCities.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace fourCities.ViewModels
{
    public partial class SettingsWindowViewModel : ObservableObject
    {
        private static string currentClockSize = TomlHandler.GetClockLabelSize().ToString();
        [ObservableProperty]
        private string _clockSize = currentClockSize;

        [RelayCommand]
        private void SetNewClockSize() 
        {
            if (int.TryParse(ClockSize, out int newSize)) {
                TomlHandler.UpdateTomlField("ClockLabel", newSize);
            }
        }
    }
}
