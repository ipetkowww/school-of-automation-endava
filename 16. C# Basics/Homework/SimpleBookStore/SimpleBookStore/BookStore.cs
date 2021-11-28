using ConsoleTable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBookStore
{
    public class BookStore
    {
        private readonly string _name;
        private readonly SortedDictionary<int, Book> _books;

        private BookStore(string name, SortedDictionary<int, Book> books)
        {
            _name = name;
            _books = books;
        }

        public string Name { get { return _name; } }

        public void ShowAllBooks()
        {
            PrintBooks(_books);
        }

        public bool AddBook(Book book)
        {
            foreach (KeyValuePair<int, Book> currentBook in _books)
            {
                if (currentBook.Value.Title.ToLower().Equals(book.Title.ToLower()))
                {
                    return false;
                }
            }
            _books.Add(_books.Keys.Last() + 1, book);
            return true;
        }

        public SortedDictionary<int, Book> SearchBook(string title)
        {
            SortedDictionary<int, Book> foundBooks = new SortedDictionary<int, Book>();
            foreach (KeyValuePair<int, Book> book in _books)
            {
                if (book.Value.Title.ToLower().Contains(title.ToLower()))
                {
                    foundBooks.Add(book.Key, book.Value);
                }
            }
            return foundBooks;
        }

        public bool DeleteBook(int id)
        {
            if (GetAllBookIds().Contains(id))
            {
                return _books.Remove(id);
            }
            return false;
        }

        public void ShowFoundBooks(SortedDictionary<int, Book> foundBooks)
        {
            PrintBooks(foundBooks);
        }

        public string GetBookNameById(int id)
        {
            if (GetAllBookIds().Contains(id))
            {
                return _books[id].Title;
            }
            return String.Empty;
        }

        public static BookStore CreateBookStoreWithDefaultBooks(string bookStoreName)
        {
            SortedDictionary<int, Book> books = new SortedDictionary<int, Book>
            {
                {1, new Book("Programming Basics with Java", "English", 200, "Java Hacker") },
                {2, new Book("Programming Basics with C#", "English", 200, "C# Hacker") },
                {3, new Book("My Robot Gets Me", "English", 304, "Carla Diana") },
                {4, new Book("Go Tell the Bees That I Am Gone", "English", 960, "Diana Gabaldon") },
                {5, new Book("Automation Testing with Java", "English", 160, "Java Fan")},
                {6, new Book("Automation Testing with C#", "English", 160, "C# Fan") }
            };
            return new BookStore(bookStoreName, books);
        }

        private void PrintBooks(SortedDictionary<int, Book> books)
        {
            var table = new Table();
            table.SetHeaders("ID", "Title", "Language", "Pages", "Author Name");
            foreach (KeyValuePair<int, Book> book in books)
            {
                table.AddRow(book.Key.ToString(), book.Value.Title, book.Value.Language, book.Value.Pages.ToString(), book.Value.AuthorName);
            }
            Console.WriteLine(table.ToString());
        }

        private List<int> GetAllBookIds()
        {
            return new List<int>(_books.Keys);
        }

        internal void ShowFoundBooks(Dictionary<int, Book> foundBooks)
        {
            throw new NotImplementedException();
        }
    }
}
