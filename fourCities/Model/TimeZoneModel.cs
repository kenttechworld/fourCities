using fourCities.Enums;

namespace fourCities.Model
{
    public class CityItemObservableProperty
    {
        public static string HomeTimeZone()
        {
            DateTimeOffset localTime = DateTimeOffset.Now;

            return localTime.LocalDateTime.ToShortTimeString();
        }

        public class CityItem
        {
            public WindowsTimeZone EnumsValue { get; set; }
            public string DisplayName { get; set; } = string.Empty;
        }
    }
}
