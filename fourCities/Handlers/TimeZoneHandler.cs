using fourCities.Enums;
using fourCities.Extensions;
using fourCities.Model;
using static fourCities.Model.CityItemObservableProperty;

namespace fourCities.Handlers
{
    internal class TimeZoneHandler
    {
        public static string GetLocalTime()
        {
            return CityItemObservableProperty.HomeTimeZone();
        }

        public static IEnumerable<CityItem> OrderedEnumerableCityItems()
        {
            IOrderedEnumerable<CityItem>? items = Enum.GetValues<WindowsTimeZone>()
                    .Select(zone => new CityItem
                    {
                        EnumsValue = zone,
                        DisplayName = zone.ToCityName()
                    })
                    .OrderBy(item => item.DisplayName);
            return items;
        }

        public static string RefreshTimeZone(TimeZoneInfo targetZone)
        {
            try
            {
                DateTimeOffset targetTime = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, targetZone);

                return targetTime.ToString("HH:mm");
            }
            catch (Exception)
            {
                return "Time Unavailable";
            }
        }
    }
}
