using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleBookStore
{
    internal class User : Person
    {
        private string _username;
        private string _password;

        public User(string name, string email, int age, string username, string password) : base(name, email, age)
        {
            _username = name;
            _email = email;
            _age = age;
            _username = username;
            _password = password;
        }

        public string UserName { get { return _username; } }
        public int Age { get { return _age; } }

        public string Password { get { return _password; } }

        public bool Register(User user)
        {
            DataBase db = new DataBase();
            bool isDataBaseExist = db.IsDataBaseExist();

            if (!isDataBaseExist)
            {
                db.CreateDatabaseWithUserData(user);
            }
            else
            {
                string[] allRecords = db.ReadDatabaseInformation();
                foreach (string userFromDb in allRecords)
                {
                    string[] userRecord = userFromDb.Split(",");
                    string usernameFromDB = userRecord[1];
                    string emailFromDB = userRecord[3];
                } 
            }




            //List<User> users = db.Users;

            //foreach (User currentUser in users)
            //{
            //    if (currentUser.UserName.Equals(user.UserName) || currentUser.Email.Equals(user.Email))
            //    {
            //        return false;
            //    }
            //}
            //db.Users.Add(user);

            //bool isDbExist = db.IsDataBaseExist("BookStoreDBUsers.txt");

            

            return true;
        }
    }
}
