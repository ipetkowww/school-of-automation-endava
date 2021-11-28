using System;
using System.Collections.Generic;

namespace SimpleBookStore.utils
{
    public class CustomConsole
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("===================================");
            Console.WriteLine($"==== WELCOME IN THE BOOK STORE ====");
            Console.WriteLine("===================================");
            Console.WriteLine("We are the first ONLINE book store in the world, so please select one of the available options to proceed.\n");
        }
        public void ShowApplicationMainMenu()
        {
            Console.WriteLine("===================");
            Console.WriteLine($"==== MAIN MENU ====");
            Console.WriteLine("===================");
            Console.WriteLine("1 = REGISTER (if you do not have an account)");
            Console.WriteLine("2 = LOGIN (if you already have an account)");
            Console.WriteLine("3 = EXIT (close the program)");
            Console.Write("Please enter your option [1 or 2 or 3]: ");
        }
        public void ShowSelectedOption(string selectedOption)
        {
            Console.WriteLine();
            Console.WriteLine($"You selected -{selectedOption}-");
        }
        public void PrintMessagePleaseFillFollowingInformation()
        {
            Console.WriteLine("Please fill the following information");
        }
        public void ShowBookStoreMainMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine($"==== BOOK STORE MENU ====");
            Console.WriteLine("=========================");
            Console.WriteLine("You have access to the Book Store");
            Console.WriteLine("Please select one of the available actions:");
            Console.WriteLine("1 = VIEW ALL BOOKS");
            Console.WriteLine("2 = ADD BOOK");
            Console.WriteLine("3 = SEARCH FOR BOOK");
            Console.WriteLine("4 = DELETE BOOK BY ID");
            Console.WriteLine("5 = EXIT (close the program)");
            Console.Write("Please enter your option [1 or 2 or 3 or 4 or 5]: ");
        }
        public void PromptUserToPressEnterToContinue()
        {
            Console.WriteLine("To continue, please press ENTER");
            Console.ReadLine();
        }
        public void ShowErrorMessage(string message)
        {
            Console.Write(new string((char)22, 7));
            Console.Write($" ERROR: {message} ");
            Console.WriteLine(new string((char)22, 7));
            Console.WriteLine();
        }
        public void ShowSuccessfulMessage(string message)
        {
            Console.Write(new string((char)16, 7));
            Console.Write($" {message} ");
            Console.WriteLine(new string((char)17, 7));
            Console.WriteLine();
        }

        public void ShowAllBooksInBookStore(BookStore bookStore)
        {
            Console.WriteLine("All books in the book store");
            bookStore.ShowAllBooks();
            PromptUserToPressEnterToContinue();
        }

        public void PrintMessageWhetherRegistrationIsSuccessfulFor(User user, bool isRegistrationSuccessful)
        {
            if (isRegistrationSuccessful)
            {
                ShowSuccessfulMessage("Successful registration!");
                ShowSuccessfulMessage($"You can login with your username: {user.UserName}");
            }
            else
            {
                ShowErrorMessage($"Cannot register because, username: {user.UserName} or email: {user.Email} already taken!");
            }
        }

        public void PrintMessageWhetherBookIsAdded(Book book, bool isBookAdded)
        {
            if (isBookAdded)
            {
                ShowSuccessfulMessage($"Book with title: {book.Title} successfully added into book store!");
            }
            else
            {
                ShowErrorMessage($"Book with title: {book.Title} already exist in book store so it cannot be added!");
            }
        }

        public void PrintMessageWhetherBookWasFoundInBookStore(BookStore bookStore, SortedDictionary<int, Book> foundBooks, string searchTitle)
        {
            if (foundBooks.Count > 0)
            {
                ShowSuccessfulMessage($"Please find below ALL FOUND books by title: {searchTitle}");
                bookStore.ShowFoundBooks(foundBooks);
            }
            else
            {
                ShowErrorMessage($"NO FOUND books by title: {searchTitle}");
            }
        }

        public void PrintMessageWhetherBookIsDeleted(int bookId, string bookName, bool isBookSuccessfulyDeleted)
        {
            if (isBookSuccessfulyDeleted)
            {
                ShowSuccessfulMessage($"Book with id: {bookId} and name: {bookName} successfully deleted!");
            }
            else
            {
                ShowErrorMessage($"Book with id: {bookId} does not exist in book store!");
            }
        }

        public void PrintExitMessage()
        {
            Console.WriteLine("Goodbye!");
        }
    }
}
