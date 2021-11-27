using System;
using System.Collections.Generic;

namespace SimpleBookStore
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine($"=== Hello, {Environment.UserName} ===");
            Console.WriteLine("Before proceeding, please enter following information: ");
            Console.WriteLine("============================================================================");
            Console.Write("Enter name of the book store: ");
            string bookStoreName = Console.ReadLine();

            Console.WriteLine($"==== WELCOME IN {bookStoreName} Book Store ====");
            Console.WriteLine("We are the first ONLINE book store in the world, so please select one of the available options to proceed: ");
            Console.WriteLine("1 = Register (if you do not have an account)");
            Console.WriteLine("2 = Login (if you already have an account)");
            Console.Write("Please enter your option [1 or 2]: ");
            int option = int.Parse(Console.ReadLine());


            if (option == 1)
            {
                Console.WriteLine("You selected -REGISTER- so please fill the following information");
                Console.Write("Please enter your name: ");
                string name = Console.ReadLine().Trim();
                Console.Write("Please enter your username: ");
                string username = Console.ReadLine().Trim();
                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();
                Console.Write("Please enter your email: ");
                string email = Console.ReadLine().Trim();
                Console.Write("Please enter your age: ");
                int age = int.Parse(Console.ReadLine());

                User user = new User(name, email, age, username, password);
                user.Register(user);
            }






            //Console.WriteLine("Please select a number for the following operations:");
            //Console.WriteLine("1 = View all available books in the BookStore");
            //Console.WriteLine("2 = Add a book in the BookStore");
            //Console.WriteLine("3 = Delete a book by book title");
            //Console.WriteLine("4 = Search a book by book title");

           






        }
    }
}
