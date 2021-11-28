namespace SimpleBookStore
{
    public class User
    {
        private readonly string _name;
        private readonly string _email;
        private readonly int _age;
        private readonly string _username;
        private readonly string _password;
        private static DataBase _db;

        public string Name { get { return _name; } }
        public string Email { get { return _email; } }
        public string UserName { get { return _username; } }
        public int Age { get { return _age; } }

        public string Password { get { return _password; } }

        public User(string name, string email, int age, string username, string password)
        {
            _name = name;
            _email = email;
            _age = age;
            _username = username;
            _password = password;
        }

        public bool Register(User user)
        {
            _db = new DataBase();
            bool isDataBaseExist = _db.IsDataBaseExist();

            if (!isDataBaseExist)
            {
                _db.CreateDatabaseWithUserData(user);
                return true;
            }
            string[] allRecords = _db.ReadDatabaseInformation();
            foreach (string userFromDb in allRecords)
            {
                string[] userRecord = userFromDb.Split(",");
                string usernameFromDB = userRecord[1];
                string emailFromDB = userRecord[3];

                if (usernameFromDB.Equals(user.UserName) || emailFromDB.Equals(user.Email))
                {
                    return false;
                }
            }
            _db.AddNewUser(user);
            return true;
        }

        public static bool Login(string username, string password)
        {
            if (_db == null)
            {
                _db = new DataBase();
            }

            if (!_db.IsDataBaseExist())
            {
                return false;
            }
            string[] allRecords = _db.ReadDatabaseInformation();
            foreach (string userFromDb in allRecords)
            {
                string[] userRecord = userFromDb.Split(",");
                string usernameFromDB = userRecord[1];
                string passwordFromDB = userRecord[2];

                if (usernameFromDB.Equals(username) && passwordFromDB.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
