using MySqlConnector;
using Parser;

namespace Tracker {
class Program {
  static void Main(string[] args) {
    Console.WriteLine(
        "🚀🚀🚀 Welcome to PoETracker! 🚀🚀🚀\n This little program tracks your deaths, level ups, passive tree allocation and more!");

    Console.WriteLine(
        "Following commands are accepted:\n poetracker store\n poetracker show");
  }
}

public class PoETracker {
  TxtParser? parse { get; set; }
  MySqlConnection? connection;

  public PoETracker(string server, string userID, string password, int port,
                    string schema) {
    try {
      connection = new MySqlConnection(
          $"Server={server};Port={port};User ID={userID};Password={password};Database={schema}");
    } catch (MySqlException e) {
      Console.Error.WriteLine(e.Message);
    }
  }

  public async void parseAndStore() {
    await connection!.OpenAsync();

    using var createDbCommand = new MySqlCommand(
        "CREATE DATABASE IF NOT EXISTS poetracker;", connection);
    createDbCommand.ExecuteNonQuery();

    using var createTableCommand = new MySqlCommand(
        "CREATE TABLE IF NOT EXISTS data (id INT, level_ups INT, deaths INT);",
        connection);
    createTableCommand.ExecuteNonQuery();

    string today = DateTime.Now.ToString("yyyy/MM/dd");
    string[] result = parse!.readDoc();

    if (result[0].Equals(today)) {
      foreach (var item in result) {
      }
    }
  }
}
}
