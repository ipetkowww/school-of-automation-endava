using System;


internal class Task01
{
    // Task Description
    // Declare two variables of type int. Assign to them values 5 and 10 respectively. Exchange (swap) their values and print them.
    static void Main(string[] args)
    {
        int firstVariable = 5;
        int secondVariable = 10;

        Console.WriteLine("=== Before SWAP ===");
        Console.WriteLine($"first variable = {firstVariable}");
        Console.WriteLine($"second variable = {secondVariable}");
        int temp = firstVariable;
        firstVariable = secondVariable;
        secondVariable = temp;
        Console.WriteLine("=== After SWAP ===");
        Console.WriteLine($"first variable = {firstVariable}");
        Console.WriteLine($"second variable = {secondVariable}");
    }
}

