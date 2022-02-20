using AutomationForHomeworkTasks.Utils;
using System;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps.Hooks
{
    [Binding]
    public class DBHook
    {
        [BeforeTestRun]
        public static void InitDBConnection()
        {
            Console.WriteLine("Initializing the DB connection...");
            DBConnection.Init();
            Console.WriteLine("Successfully initialized DB connection!");
        }

        [AfterTestRun]
        public static void CloseDBConnection()
        {
            Console.WriteLine("Closing the DB connection...");
            DBConnection.Close();
            Console.WriteLine("Successfully closed DB connection!");
        }
    }
}