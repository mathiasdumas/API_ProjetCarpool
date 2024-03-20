using System;
using MySqlConnector;

namespace ConnectionString.Data
{
	public class Pays
	{
		public string Nom { get; set; }

        public Pays(string nom)
        {
            Nom = nom;
        }

        public void Insert()
        {
            string query = "INSERT Pays (Nom) VALUES (@nom);";
            using (MySqlCommand command = new MySqlCommand(query, Connection.GetInstance()))
            {
                command.Parameters.AddWithValue("@nom", Nom);
                command.ExecuteNonQuery();
            } 
        }
    }
}

