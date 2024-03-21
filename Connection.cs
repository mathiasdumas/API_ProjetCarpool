using System;
using MySqlConnector;

namespace ConnectionString
{
	public class Connection
	{
		private static MySqlConnection _connection;

		public static MySqlConnection GetInstance()
		{
			if (_connection == null)
			{
				_connection = Connect();
			}

			return _connection;
		}

		public static MySqlConnection Connect()
		{

			try
			{
				var connectionString = "server=localhost;port=3306;user=root;password=root;";
				var connection = new MySqlConnection(connectionString);
				connection.Open();
				Console.WriteLine("Connexion réussie");

				return connection;
			}
			catch (MySqlException sqlEx)
			{
				Console.WriteLine($"Erreur : {sqlEx.Message}");
				throw;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur : {ex.Message}");
				throw;
			}
 
		}
	}
}


