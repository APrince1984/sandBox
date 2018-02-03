using System;
using System.Text;

namespace Utilities
{
    public static class RandomUtil
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string AlphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random _random = new Random();

        public static int GetRandomNumber(int length = 6)
        {
            if (length > 6)
                length = 6;

            return _random.Next(length.GetMinimumIntValue(), length.GetMaximumIntValue());
        }

        public static string GetRandomString(int length = 10)
        {
            return BuildRandomString(length, Chars);
        }
        

        public static string GetRandomAlphaNumericString(int length = 10)
        {
            return BuildRandomString(length, AlphaNumericChars);
        }

        public static DateTime GetRandomDateInThePast(int? period = null)
        {
            var randomNumber = -(GetRandomNumber(3) - 1);
            return GetNewDate(period, randomNumber).Date;
        }

        private static DateTime GetNewDate(int? period, int randomNumber)
        {
            switch (period)
            {
                case 1:
                    return DateTime.Now.AddMonths(randomNumber);
                default:
                    return DateTime.Now.AddDays(randomNumber);
            }
        }

        public static DateTime GetRandomDateInTheFuture(int? period = null)
        {
            var randomNumber = GetRandomNumber(3) - 1;
            return GetNewDate(period, randomNumber).Date;
        }

        private static string BuildRandomString(int length, string chars)
        {
            var stringChars = new char[length];
            for (int i = 0; i < length; i++)
                stringChars[i] = chars[_random.Next(chars.Length)];

            return new String(stringChars);
        }


    }
}
