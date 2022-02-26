using System;
using System.Text;

namespace FinalExam.Utils
{
    public static class Helper
    {
        public static string GetAlphaNumericString()
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
            return $"ivan.p.mail{GetAlphaNumericString()}@automation.com";
        }
    }
}