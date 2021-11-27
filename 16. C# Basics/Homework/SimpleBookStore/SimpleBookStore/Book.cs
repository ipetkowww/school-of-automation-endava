using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBookStore
{
    internal class Book
    {
        private string _title;
        private string _description;
        private Author _author;

        public string Title { get; set; }

        public Book(string title, string description, Author author)
        {
            _title = title;
            _description = description;
            _author = author;
        }
    }
}
