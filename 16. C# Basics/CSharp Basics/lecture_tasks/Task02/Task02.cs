using System;


internal class Task02
{
    // Description task
    // Write a program that reads from the console three numbers of type int and print their sum
    static void Main()
    {
        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Please enter number: ");
            int number = int.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine($"Sum of the numbers is: {sum}");
    }
}