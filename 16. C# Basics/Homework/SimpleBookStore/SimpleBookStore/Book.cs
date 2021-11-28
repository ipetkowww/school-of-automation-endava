namespace SimpleBookStore
{
    public class Book
    {
        private readonly string _title;
        private readonly string _language;
        private readonly int _pages;
        private readonly string _authorName;

        public string Title { get { return _title; } }
        public string Language { get { return _language; } }

        public int Pages { get { return _pages; } }
        public string AuthorName { get { return _authorName; } }

        public Book(string title, string language, int pages, string authorName)
        {
            _title = title;
            _language = language;
            _pages = pages;
            _authorName = authorName;
        }
    }
}
