using System;

namespace ConvertMinutesIntoSeconds
{
    internal class ConvertMinutesIntoSeconds
    {
        // Task ==> https://edabit.com/challenge/bizjGL4wyd8PwR4Ke
        static void Main()
        {
            Console.Write("Enter number for minutes: ");
            int minutes = int.Parse(Console.ReadLine());

            int seconds = CovertIntoSecods(minutes);
            Console.WriteLine($"{minutes} minutes = {seconds} seconds");
        }

        static int CovertIntoSecods(int minutes)
        {
            return minutes * 60;
        }
    }
}
