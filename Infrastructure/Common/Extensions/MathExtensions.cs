using System;
using System.Globalization;

namespace SlackNotifier.Domain.Extensions
{
    public static class MathExtensions
    {
        public static string RoundByDigit(this double value, int digit = 1)
        {
            return Math.Round(value, digit).ToString(CultureInfo.InvariantCulture);
        }
    }
}