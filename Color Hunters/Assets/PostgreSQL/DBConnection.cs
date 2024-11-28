using UnityEngine;
using System;
using MySqlConnector;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class DBConnection
{
    const string CredentialPath = @"..\dbconfig.json";
    string connectionString;

    public DBConnection()
    {
        SetConnectionData();
    }

    private void SetConnectionData()
    {
        string configPath = Path.Combine(Application.dataPath, CredentialPath);

        //Verificar si el archivo existe
        if (File.Exists(configPath))
        {
            //Leer todo el contenido del archivo JSON
            string json = File.ReadAllText(configPath);

            //Deserializar el JSON en un Dictionary
            var dbConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            //Usar los datos para construir el connection string
            connectionString = $"Server={dbConfig["server"]};Port={dbConfig["port"]};Database={dbConfig["database"]};Uid={dbConfig["user"]};Pwd={dbConfig["password"]};SslMode={dbConfig["ssl"]};";

            Debug.Log("Connection string: " + connectionString);
        }
        else
        {
            Debug.LogError("No se encontró el archivo dbconfig.json " + configPath);
        }
    }

    public void InsertClient(string id, string name, string surnames, string age, string phone, string email, string address, int doctor)
    {
        // Consulta SQL para insertar datos
        string insertQuery = "INSERT INTO clientes (documento_identidad, nombre, apellidos, edad, telefono, correo, direccion, id_oftalmologo) " +
            "VALUES (@id, @name, @surnames, @age, @phone, @email, @address, @doctor)";

        try
        {
            // Conexión a la base de datos
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Debug.Log("Conexión abierta a MySQL.");

                // Crear el comando SQL
                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    // Asignar valores a los parámetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surnames", surnames);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@doctor", doctor);

                    // Ejecutar el comando
                    int rowsAffected = command.ExecuteNonQuery();
                    Debug.Log($"Filas insertadas: {rowsAffected}");
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error al insertar datos: {ex.Message}");
        }
    }

    public void Test()
    {
        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Debug.Log("Conexión exitosa a la base de datos.");
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError($"Error de autenticación: {ex.Message}");
            if (ex.InnerException != null)
            {
                Debug.LogError($"Detalles internos: {ex.InnerException.Message}");
            }
        }
    }
}
