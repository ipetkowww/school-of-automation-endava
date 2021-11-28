using System;
using System.IO;

namespace SimpleBookStore
{
    public class DataBase
    {
        private static readonly string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"\BookStoreDBUsers.csv";

        public bool IsDataBaseExist()
        {

            return File.Exists(PATH);
        }

        public void CreateDatabaseWithUserData(User user)
        {

            File.Create(PATH).Dispose();
            using TextWriter tw = new StreamWriter(PATH);
            tw.WriteLine($"{user.Name},{user.UserName},{user.Password},{user.Email},{user.Age}");
        }

        public void AddNewUser(User user)
        {
            File.AppendAllText(PATH, $"{user.Name},{user.UserName},{user.Password},{user.Email},{user.Age}" + Environment.NewLine);
        }

        public string[] ReadDatabaseInformation()
        {
            return File.ReadAllLines(PATH);
        }
    }
}
