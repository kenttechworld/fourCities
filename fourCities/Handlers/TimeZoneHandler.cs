using fourCities.Model;

namespace fourCities.Handlers
{
    internal class TimeZoneHandler
    {
        public static List<string> timeZoneCityList = new List<string>();

        public static string GetLocalTime()
        {
            return TimeModel.HomeTimeZone();
        }

        public static string GetStoredTimeZone(string tomlField) 
        {
            string storedTimeZone = TomlModel.ReadTOMLfields<string>(tomlField);
            return storedTimeZone;
        }

        public static void AddlocationsToList() 
        {
            TimeModel.PopulateTimeZoneLocationToList(timeZoneCityList);
        }

        public static string GetTimeZoneTime(string timeZone) 
        {
            return TimeModel.GetTimeInLocation(timeZone);
        }
    }
}
