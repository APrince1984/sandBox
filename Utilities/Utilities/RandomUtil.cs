using System;
using System.Text;

namespace Utilities
{
    public static class RandomUtil
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string AlphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static int GetRandomNumber(int length = 6)
        {
            if (length > 6)
                length = 6;

            var random = new Random();
            return random.Next(0, length.GetMaximumIntValue());
        }

        public static string GetRandomString(int length = 10)
        {
            return BuildRandomString(length, Chars);
        }
        

        public static string GetRandomAlphaNumericString(int length = 10)
        {
            return BuildRandomString(length, AlphaNumericChars);
        }

        private static string BuildRandomString(int length, string chars)
        {
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            return new String(stringChars);
        }
    }
}
