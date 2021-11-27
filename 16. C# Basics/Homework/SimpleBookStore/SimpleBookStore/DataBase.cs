using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleBookStore
{
    internal class DataBase
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

        public string[] ReadDatabaseInformation()
        {
            return File.ReadAllLines(PATH);
        }

        //public bool IsUserExist(User user)
        //{
        //else
        //{
        //    File.AppendAllText(PATH + $@"\{file}", $"{userData.Name},{userData.UserName},{userData.Email},{userData.Age}" + Environment.NewLine);
        //}
        //}
    }
}
