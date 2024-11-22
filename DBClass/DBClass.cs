using System;
using Npgsql;

namespace DBClass
{
    public class DBManagement
    {
        string server = "ep-delicate-boat-a59vtmb4.us-east-2.aws.neon.tech";
        string database = "ColorHunterDB";
        string uid = "ColorHunterDB_owner";
        string password = "G9FboyJmKSP1";
        string connectionString = "";

        // Constructor
        public DBManagement()
        {
            connectionString = $"Server={server};Port=5432;Database={database};User Id={uid};Password={password};";
        }

        public void InsertClient(string id, string name, string surnames, string phone, string email, string address, int doctor)
        {
            // Consulta SQL para insertar datos
            string insertQuery = "INSERT INTO clientes VALUES (@id, @name, @surnames, @phone, @email, @address, @doctor)";

            try
            {
                // Conexión a la base de datos
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta a PostgreSQL.");

                    // Crear el comando SQL
                    using (var command = new NpgsqlCommand(insertQuery, connection))
                    {
                        // Asignar valores a los parámetros
                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue("name", name);
                        command.Parameters.AddWithValue("surnames", surnames);
                        command.Parameters.AddWithValue("phone", phone);
                        command.Parameters.AddWithValue("email", email);
                        command.Parameters.AddWithValue("address", address);
                        command.Parameters.AddWithValue("doctor", doctor);

                        // Ejecutar el comando
                        int filasAfectadas = command.ExecuteNonQuery();
                        Console.WriteLine($"Filas insertadas: {filasAfectadas}");
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
}
