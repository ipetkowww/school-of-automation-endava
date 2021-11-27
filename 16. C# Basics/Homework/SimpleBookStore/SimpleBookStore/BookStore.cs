using System.Collections.Generic;

namespace SimpleBookStore
{
    internal class BookStore
    {
        private string _name;
        private string _address;
        private List<Book> _books;

        public BookStore(string name, string address, List<Book> books)
        {
            _name = name;
            _address = address;
            _books = books;
        }

        public bool deleteBook(string bookTitle)
        {
            foreach (Book book in _books)
            {
                if (book.Title.Equals(bookTitle))
                {
                    _books.Remove(book);
                    return true;
                }
            }
            return false;
        }

    }
}
