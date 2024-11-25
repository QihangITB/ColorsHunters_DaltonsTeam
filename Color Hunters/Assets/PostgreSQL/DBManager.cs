using UnityEngine;
using System;
using MySql.Data.MySqlClient;

public class DBManager : MonoBehaviour
{

}

public class MySQLDB
{
    string server = "your-mysql-server";
    string database = "ColorHunterDB";
    string uid = "ColorHunterDB_owner";
    string password = "your-password";
    string connectionString = "";

    // Constructor
    public MySQLDB()
    {
        connectionString = $"Server={server};Port=3306;Database={database};Uid={uid};Pwd={password};";
    }

    public void InsertClient(string id, string name, string surnames, string phone, string email, string address, int doctor)
    {
        // Consulta SQL para insertar datos
        string insertQuery = "INSERT INTO clientes (id, name, surnames, phone, email, address, doctor) VALUES (@id, @name, @surnames, @phone, @email, @address, @doctor)";

        try
        {
            // Conexión a la base de datos
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexión abierta a MySQL.");

                // Crear el comando SQL
                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    // Asignar valores a los parámetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surnames", surnames);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@doctor", doctor);

                    // Ejecutar el comando
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Filas insertadas: {rowsAffected}");
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al insertar datos: {ex.Message}");
        }
    }
}
