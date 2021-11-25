using System;

namespace TheFarmProblem
{
    internal class TheFarmProblem
    {
        static void Main()
        {
            Console.Write("Enter number for count of chickens: ");
            int chickens = int.Parse(Console.ReadLine());

            Console.Write("Enter number for count of cows: ");
            int cows = int.Parse(Console.ReadLine());

            Console.Write("Enter number for count of pigs: ");
            int pigs = int.Parse(Console.ReadLine());

            int legsCount = CalculateAnimalLegs(chickens, cows, pigs);
            Console.WriteLine($"Animal legs = {legsCount}");
        }

        static int CalculateAnimalLegs(int chickensCount, int cowsCount, int pigsCount)
        {
            int chickenLegs = 2;
            int cowsAndPigsLegs = 4;

            return (chickensCount * chickenLegs) + ((cowsCount + pigsCount) * cowsAndPigsLegs);
        }
    }
}