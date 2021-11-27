using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBookStore
{
    internal class Author : Person
    {
        protected Author(string name, string email, int age) : base(name, email, age)
        {
        }
    }
}
