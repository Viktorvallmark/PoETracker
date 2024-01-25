using System.Diagnostics;
using MySqlConnector;
using Parser;

namespace Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            PoETracker tracker;
            Console.WriteLine(
                "🚀🚀🚀 Welcome to PoETracker! 🚀🚀🚀\n This little program tracks your deaths, level ups, passive tree allocation and more!\n");
            Console.WriteLine(
                "Please select an option:\n1. Read from Client.txt\n2. Print from database\n3. Quit");

            // For testing purposes

            tracker = new PoETracker("localhost", "root", "123", 3306);

            // End of testing

            bool quit = false;
            while (!quit)
            {
                string? temp = Console.ReadLine();
                Debug.Assert(temp != null);
                switch (temp)
                {
                    case "1":
                        tracker.parseAndStore();
                        break;
                    case "2":
                        tracker.printAndShow();
                        break;
                    case "3":
                        quit = true;
                        break;
                }
            }
        }
    }

    public class PoETracker
    {
        TxtParser? parse { get; set; }
        MySqlConnection? connection;

        public PoETracker(string server, string userID, string password, int port)
        {
            try
            {
                connection = new MySqlConnection(
                    $"Server={server};Port={port};User ID={userID};Password={password};Database=poetracker");
            }
            catch (MySqlException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public async void parseAndStore()
        {
            await connection!.OpenAsync();

            using var createDbCommand = new MySqlCommand(
                "CREATE DATABASE IF NOT EXISTS poetracker;", connection);
            createDbCommand.ExecuteNonQuery();

            using var createTableCommand = new MySqlCommand(
                "CREATE TABLE IF NOT EXISTS data (id INT, level_ups INT, deaths INT);",
                connection);
            createTableCommand.ExecuteNonQuery();

            string today = DateTime.Now.ToString("yyyy/MM/dd");
            // Line below returns NullPointerException, its because path to file isn't
            // implemented correctly.
            string[] result = parse!.readDoc();

            if (result[0].Equals(today))
            {
                foreach (var item in result)
                {
                }
            }
        }

        public async void printAndShow()
        {
            await connection!.OpenAsync();

            using MySqlCommand grabAll = new MySqlCommand("SELECT * FROM data;");
            await grabAll.ExecuteReaderAsync();
            string grabAllString = grabAll.ToString();

            Console.WriteLine(grabAllString);
        }
    }
}
