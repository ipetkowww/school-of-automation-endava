using System;


internal class Task03
{
    // Task description
    // Write program that calculates the area of a triangle by given side and height
    static void Main()
    {
        Console.Write("Enter side of triangle: ");
        double side = double.Parse(Console.ReadLine());

        Console.Write("Enter height of triangle: ");
        double height = double.Parse(Console.ReadLine());

        double areaOfTriangle = (side * height) / 2;
        Console.WriteLine($"Area of triangle is: {areaOfTriangle}");
    }
}