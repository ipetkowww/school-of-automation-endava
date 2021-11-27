namespace SimpleBookStore
{
    internal class Person
    {
        protected string _name;
        protected string _email;
        protected int _age;

        protected Person(string name, string email, int age)
        {
            _name = name;
            _email = email;
            _age = age;
        }

        public string Name { get { return _name; } }
        public string Email { get { return _email;} }
    }
}
