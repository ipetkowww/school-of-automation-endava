using System;

namespace AreaOfTriangle
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter number for side A = ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter number for side B = ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter number for side C = ");
            double sideC = double.Parse(Console.ReadLine());

            double areaOfTriangle = CalculatePerimeterOfTriangle(sideA, sideB, sideC);

            if (areaOfTriangle > 0)
            {
                Console.WriteLine($"Perimeter of triangle with side A = {sideA}, side B = {sideB}, side C = {sideC} is {areaOfTriangle}");
            } 
            else
            {
                Console.WriteLine($"Triangle with side A = {sideA}, side B = {sideB}, side C = {sideC} does not exist");
            }
        }

        static double CalculatePerimeterOfTriangle(double a, double b, double c) 
        {
            double areaOfTriangle = 0;
            if (b + c > a && a + c > b && a + b > c)
            {
                areaOfTriangle = (a + b + c) / 2;
            }
            return areaOfTriangle;
        }
    }
}
