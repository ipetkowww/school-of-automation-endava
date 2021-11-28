using SimpleBookStore.utils;
using System;
using System.Collections.Generic;

namespace SimpleBookStore
{
    internal class Application
    {
        private List<string> _filledUserData;
        private BookStore _bookStore;
        private User _user;
        private CustomConsole _console;
        private bool _isBookStoreFlowClosed;

        public void Start()
        {
            _console = new CustomConsole();
            _console.PrintWelcomeMessage();
            _console.ShowApplicationMainMenu();
            int optionFromMainMenu = int.Parse(Console.ReadLine());
            string tryLogAgain = string.Empty;

            while (true)
            {
                switch (optionFromMainMenu)
                {
                    case 1:
                        _console.ShowSelectedOption(Constants.REGISTER);
                        PromptUserToFillDataFor(Constants.REGISTER);
                        List<string> regUser = GetFilledUserData();
                        _user = new User(regUser[0], regUser[1], int.Parse(regUser[2]), regUser[3], regUser[4]);
                        Register(_user);
                        _console.PromptUserToPressEnterToContinue();
                        _console.ShowApplicationMainMenu();
                        break;
                    case 2:
                        if (tryLogAgain.Equals(string.Empty))
                        {
                            _console.ShowSelectedOption(Constants.LOGIN);
                        }
                        PromptUserToFillDataFor(Constants.LOGIN);
                        List<string> loginData = GetFilledUserData();
                        string loggedUser = loginData[0];
                        bool isSuccessfulLogin = User.Login(loggedUser, loginData[1]);

                        if (isSuccessfulLogin)
                        {
                            _bookStore = BookStore.CreateBookStoreWithDefaultBooks("CONSOLE");
                            tryLogAgain = "no";
                            _console.ShowSuccessfulMessage("Successful login!");
                            Console.WriteLine($"Hello, {loggedUser}!");
                            Console.WriteLine($"Welcome in >>> {_bookStore.Name} <<< Book Store");
                            _console.ShowBookStoreMainMenu();
                            int bookStoreMenuOption = int.Parse(Console.ReadLine());

                            BookStoreFlowOperations(bookStoreMenuOption);
                            if (_isBookStoreFlowClosed)
                            {
                                return;
                            }
                        }
                        else
                        {
                            _console.ShowErrorMessage("Entered username and password do not match!");
                            Console.WriteLine("Do you want to try to login again?");
                            Console.Write("Please enter yes or no: ");
                            tryLogAgain = Console.ReadLine();
                            if (tryLogAgain.Equals("no"))
                            {
                                _console.ShowApplicationMainMenu();
                            }
                        }
                        break;
                    case 3:
                        _console.ShowSelectedOption(Constants.EXIT);
                        _console.PrintExitMessage();
                        return;
                }
                if (tryLogAgain.Equals("yes"))
                {
                    optionFromMainMenu = 2;
                }
                else
                {
                    optionFromMainMenu = int.Parse(Console.ReadLine());
                }
            }

        }
        private void BookStoreFlowOperations(int bookStoreMenuOption)
        {
            while (true)
            {
                switch (bookStoreMenuOption)
                {
                    case 1:
                        _console.ShowSelectedOption(Constants.VIEW_ALL_BOOKS);
                        _console.ShowAllBooksInBookStore(_bookStore);
                        break;
                    case 2:
                        _console.ShowSelectedOption(Constants.ADD_BOOK);
                        PromptUserToFillDataFor(Constants.ADD_BOOK);
                        List<string> bookForAdd = GetFilledUserData();
                        string title = bookForAdd[0];
                        Book book = new Book(title, bookForAdd[1], int.Parse(bookForAdd[2]), bookForAdd[3]);
                        bool isBookAddedSuccessfuly = _bookStore.AddBook(book);
                        _console.PrintMessageWhetherBookIsAdded(book, isBookAddedSuccessfuly);
                        _console.PromptUserToPressEnterToContinue();
                        break;
                    case 3:
                        _console.ShowSelectedOption(Constants.SEARCH_BOOK);
                        PromptUserToFillDataFor(Constants.SEARCH_BOOK);
                        string titleForSearch = GetFilledUserData()[0];
                        SortedDictionary<int, Book> foundBooks = _bookStore.SearchBook(titleForSearch);
                        _console.PrintMessageWhetherBookWasFoundInBookStore(_bookStore, foundBooks, titleForSearch);
                        _console.PromptUserToPressEnterToContinue();
                        break;
                    case 4:
                        _console.ShowSelectedOption(Constants.DELETE_BOOK);
                        PromptUserToFillDataFor(Constants.DELETE_BOOK);
                        int id = int.Parse(GetFilledUserData()[0]);
                        string bookName = _bookStore.GetBookNameById(id);
                        bool isDeleted = _bookStore.DeleteBook(id);
                        _console.PrintMessageWhetherBookIsDeleted(id, bookName, isDeleted);
                        _console.PromptUserToPressEnterToContinue();
                        break;
                    case 5:
                        _console.ShowSelectedOption(Constants.EXIT);
                        _console.PrintExitMessage();
                        _isBookStoreFlowClosed = true;
                        return;
                }
                _console.ShowBookStoreMainMenu();
                bookStoreMenuOption = int.Parse(Console.ReadLine());
            }
        }
        private List<string> GetFilledUserData()
        {
            return _filledUserData;
        }
        private void PromptUserToFillDataFor(string operation)
        {
            string username;
            string password;
            switch (operation)
            {
                case Constants.REGISTER:
                    _console.PrintMessagePleaseFillFollowingInformation();
                    Console.Write("Please enter your name: ");
                    string name = Console.ReadLine().Trim();
                    Console.Write("Please enter your username: ");
                    username = Console.ReadLine().Trim();
                    Console.Write("Please enter your password: ");
                    password = Console.ReadLine();
                    Console.Write("Please enter your email: ");
                    string email = Console.ReadLine().Trim();
                    Console.Write("Please enter your age: ");
                    int age = int.Parse(Console.ReadLine());
                    _filledUserData = new List<string>()
                    {
                        name, email, age.ToString(), username, password
                    };
                    break;
                case Constants.LOGIN:
                    _console.PrintMessagePleaseFillFollowingInformation();
                    Console.Write("Please enter your username: ");
                    username = Console.ReadLine();
                    Console.Write("Please enter your password: ");
                    password = Console.ReadLine();
                    _filledUserData = new List<string>()
                    {
                        username, password
                    };
                    break;
                case Constants.ADD_BOOK:
                    _console.PrintMessagePleaseFillFollowingInformation();
                    Console.Write("Please enter book title: ");
                    string bookTitle = Console.ReadLine().Trim();
                    Console.Write("Please enter language of the book: ");
                    string bookLanguage = Console.ReadLine().Trim();
                    Console.Write("Please enter pages count (a number): ");
                    int bookPages = int.Parse(Console.ReadLine());
                    Console.Write("Please enter author name: ");
                    string bookAuthorName = Console.ReadLine().Trim();
                    _filledUserData = new List<string>
                    {
                        bookTitle, bookLanguage, bookPages.ToString(), bookAuthorName
                    };
                    break;
                case Constants.SEARCH_BOOK:
                    _console.PrintMessagePleaseFillFollowingInformation();
                    Console.Write("Please enter a book title: ");
                    string searchTitle = Console.ReadLine().Trim();
                    _filledUserData = new List<string>()
                    {
                        searchTitle
                    };
                    break;
                case Constants.DELETE_BOOK:
                    Console.WriteLine("Following books are in the book store");
                    _bookStore.ShowAllBooks();
                    Console.Write("Please enter the id of the book which you want to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    _filledUserData = new List<string>()
                    {
                        id.ToString()
                    };
                    break;
            }
        }

        private void Register(User user)
        {
            List<string> registrationData = GetFilledUserData();
            _user = new User(registrationData[0], registrationData[1], int.Parse(registrationData[2]), registrationData[3], registrationData[4]);
            bool isRegistrationSuccessful = user.Register(user);
            _console.PrintMessageWhetherRegistrationIsSuccessfulFor(user, isRegistrationSuccessful);
        }
    }
}