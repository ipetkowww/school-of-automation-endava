using System;
using System.Text;

namespace AutomationForHomeworkTasks.Helpers
{
    public class Helper
    {
        public static string GetAlphaNumericString()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 16;
            StringBuilder sb = new();
            Random random = new();
            for (var i = 0; i < length; i++)
            {
                var c = src[random.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}