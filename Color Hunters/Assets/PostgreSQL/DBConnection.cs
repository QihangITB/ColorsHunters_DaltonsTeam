using UnityEngine;
using System;
using MySqlConnector;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class DBConnection
{
    /// <summary>
    /// Ruta al archivo de configuración JSON que contiene las credenciales de la base de datos.
    /// </summary>
    const string CredentialPath = @"..\dbconfig.json";

    /// <summary>
    /// Cadena de conexión que se utiliza para conectarse a la base de datos.
    /// </summary>
    string connectionString;

    /// <summary>
    /// Constructor de la clase DBConnection. Llama al método SetConnectionData para cargar las credenciales.
    /// </summary>
    public DBConnection()
    {
        SetConnectionData();
    }

    /// <summary>
    /// Lee el archivo JSON de configuración y establece la cadena de conexión a la base de datos.
    /// </summary>
    private void SetConnectionData()
    {
        string configPath = Path.Combine(Application.dataPath, CredentialPath);

        // Verificar si el archivo existe
        if (File.Exists(configPath))
        {
            // Leer todo el contenido del archivo JSON
            string json = File.ReadAllText(configPath);

            // Deserializar el JSON en un Dictionary
            var dbConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            // Usar los datos para construir el connection string
            connectionString = $"Server={dbConfig["server"]};Port={dbConfig["port"]};Database={dbConfig["database"]};Uid={dbConfig["user"]};Pwd={dbConfig["password"]};SslMode={dbConfig["ssl"]};";

            Debug.Log("Credenciales encontradas");
        }
        else
        {
            Debug.LogError("No se encontró el archivo dbconfig.json " + configPath);
        }
    }

    /// <summary>
    /// Inserta un nuevo cliente en la base de datos.
    /// </summary>
    /// <param name="id">Documento de identidad del cliente.</param>
    /// <param name="name">Nombre del cliente.</param>
    /// <param name="surnames">Apellidos del cliente.</param>
    /// <param name="age">Edad del cliente.</param>
    /// <param name="phone">Teléfono del cliente.</param>
    /// <param name="email">Correo electrónico del cliente.</param>
    /// <param name="address">Dirección del cliente.</param>
    /// <param name="doctor">ID del oftalmólogo asociado.</param>
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

    /// <summary>
    /// Obtiene el ID de un cliente a partir de su documento de identidad.
    /// </summary>
    /// <param name="documentId">Documento de identidad del cliente.</param>
    /// <returns>El ID del cliente. Devuelve 0 si no se encuentra el cliente.</returns>
    public int GetClientIdByDocumentId(string documentId)
    {
        int result = 0;
        try
        {
            // Crear una conexión a la base de datos
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();  // Abrir la conexión

                string query = "SELECT id_cliente FROM clientes WHERE documento_identidad = @documentId";

                // Crear un comando SQL
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Usar parámetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@documentId", documentId);

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier error que ocurra durante la conexión o la consulta
            Debug.LogError("Error al conectar a la base de datos: " + ex.Message);
        }

        return result; // Devuelve 0 si no se encuentra el cliente.
    }

    /// <summary>
    /// Realiza una prueba de conexión a la base de datos.
    /// </summary>
    public void ConnectionTest()
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