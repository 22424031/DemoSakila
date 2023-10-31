namespace DemoSakila.API.Realtime
{
    public class ActivityManager
    {
        public static List<string> LastActivities = new();

        public static void AddActivity(string activity)
        {
            LastActivities.Add(activity);
        }

        public static List<string> GetListActivities()
        {
            return LastActivities;
        }
        public static void Clear()
        {
            LastActivities = new();
        }
    }
}
