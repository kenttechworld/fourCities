using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using fourCities.Handlers;
using fourCities.Messages;
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
                // Broadcasts the new font size to all controls instantly
                WeakReferenceMessenger.Default.Send(new ChangeFontSizeMessage(newSize));
            }
        }
    }
}
