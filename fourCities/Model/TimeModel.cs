using NodaTime;
using System.Collections.ObjectModel;
using System.IO;

namespace fourCities.Model
{
    class TimeModel
    {
        private static ReadOnlyCollection<string> timeZoneIds = DateTimeZoneProviders.Tzdb.Ids;
        private static HashSet<string> filter = new HashSet<string>(File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "ignoreList.txt")));

        public static void PopulateTimeZoneLocationToList(List<string> timeZoneCityList)
        {
            foreach (string id in timeZoneIds)
            {
                timeZoneCityList.Add(id);
                timeZoneCityList.Sort();
            }
            timeZoneCityList.RemoveAll(item => filter.Contains(item));
        }

        public static string GetTimeInLocation(string timeZone)
        {
            Instant now1 = SystemClock.Instance.GetCurrentInstant();

            DateTimeZone zone1 = DateTimeZoneProviders.Tzdb[timeZone];

            LocalTime timeOnly = now1.InZone(zone1).TimeOfDay;
            string shortTime = timeOnly.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            return shortTime;
        }

        public static string HomeTimeZone()
        {
            DateTimeOffset localTime = DateTimeOffset.Now;

            return localTime.LocalDateTime.ToShortTimeString();
        }
    }
}
