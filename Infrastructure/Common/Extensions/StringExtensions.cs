
namespace SlackNotifier.Infrastructure.Utils
{
    public static class StringExtensions
    {
        public static long ToLong(this string value, long defaultValue = 0)
        {
            long result = 0;
            return long.TryParse(value, out result) ? result : defaultValue;
        }

        public static int ToInt(this string value, int defaultValue = 0)
        {
            int result = 0;
            return int.TryParse(value, out result) ? result : defaultValue;
        }
    }
}