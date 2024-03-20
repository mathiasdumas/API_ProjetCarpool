using System;
using MySqlConnector;

namespace ConnectionString.Data
{
	public class Employee
	{

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        public Employee(string nom, string prenom, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }

        public void Insert()
        {
            string query = "INSERT Employee (Nom, Prenom, DateNaissance) VALUES (@nom, @prenom, @dateNaissance);";
            using (MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                command.Parameters.AddWithValue("@nom", Nom);
                command.Parameters.AddWithValue("@prenom", Prenom);
                command.Parameters.AddWithValue("@dateNaissance", DateNaissance);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + "rows affected");
            }
        }

        public void Update(int Id, string newNom)
        {
            string query = "UPDATE Employee SET Nom = @nom WHERE Id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@nom", newNom);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows updated");
            }
        }

        public void DeleteById(int id)
        {
            string query = "DELETE FROM Employee WHERE Id = @id";
            using(MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows deleted");
            }
        }

        public void ReadAll()
        {
            string query = "SELECT * FROM Employee;";
            using (MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                }
            }
        }



		
	}
}

