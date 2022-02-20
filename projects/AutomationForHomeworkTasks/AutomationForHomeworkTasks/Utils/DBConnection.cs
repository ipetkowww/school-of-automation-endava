using System;
using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;

namespace AutomationForHomeworkTasks.Utils
{
    public class DBConnection
    {
        private readonly MySqlConnection _connection;
        private static DBConnection _dbConnection;
        private const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=db;Uid=root;Pwd=pass;";

        private DBConnection()
        {
            _connection = new MySqlConnection(CONNECTION_STRING);
            try
            {
                Console.WriteLine("Connecting to DB...");
                _connection.Open();
                Console.WriteLine("Successfully connected to DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem with connection to DB");
                Console.WriteLine(e.Message);
            }
        }
           
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DBConnection Init()
        {
            if (_dbConnection is null)
            {
                _dbConnection = new DBConnection();
            }
            return _dbConnection;
        }

        public static void InsertRecord(string sqlQuery)
        {
            MySqlCommand command = new(sqlQuery, _dbConnection._connection);
            MySqlDataAdapter adapter = new();
            adapter.InsertCommand = command;

            Console.WriteLine($"Inserting into DB with SQL: {sqlQuery}");
            if (adapter.InsertCommand.ExecuteNonQuery() < 1)
            {
                Console.WriteLine("Nothing has been inserted...");
            }
            command.Dispose();
        }

        public static void Close()
        {
            _dbConnection._connection.Dispose();
            _dbConnection = null;
        }
    }
}