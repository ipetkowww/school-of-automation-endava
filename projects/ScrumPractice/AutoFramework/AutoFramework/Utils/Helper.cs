using System;
using System.Text;

namespace AutoFramework.Utils
{
    public static class Helper
    {
        private static string GetAlphaNumericString()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            var length = 5;
            var sb = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[random.Next(0, src.Length)];
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static string GetRandomEmail()
        {
            return $"auto{GetAlphaNumericString()}@automation.com";
        }
    }
}