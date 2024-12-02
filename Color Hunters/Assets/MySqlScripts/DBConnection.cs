using UnityEngine;
using System;
using MySqlConnector;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class DBConnection
{
    const string CredentialPath = @"..\dbconfig.json";
    string connectionString;

    public DBConnection()
    {
        SetConnectionData();
    }

    /// <summary>
    /// Lee el archivo JSON de configuracion y establece la cadena de conexi�n a la base de datos.
    /// </summary>
    private void SetConnectionData()
    {
        string configPath = Path.Combine(Application.dataPath, CredentialPath);

        if (File.Exists(configPath))
        {
            string json = File.ReadAllText(configPath);

            var dbConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            connectionString = $"Server={dbConfig["server"]};Port={dbConfig["port"]};Database={dbConfig["database"]};Uid={dbConfig["user"]};Pwd={dbConfig["password"]};SslMode={dbConfig["ssl"]};";

            Debug.Log("Credenciales encontradas");
        }
        else
        {
            Debug.LogError("No se encontr� el archivo dbconfig.json " + configPath);
        }
    }

    /// <summary>
    /// Realiza una prueba de conexion a la base de datos.
    /// </summary>
    public void ConnectionTest()
    {
        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Debug.Log("Conexi�n exitosa a la base de datos.");
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError($"Error de autenticaci�n: {ex.Message}");
            if (ex.InnerException != null)
            {
                Debug.LogError($"Detalles internos: {ex.InnerException.Message}");
            }
        }
    }

    /// <summary>
    /// Inserta un nuevo cliente en la base de datos.
    /// </summary>
    /// <param name="id">Documento de identidad del cliente.</param>
    /// <param name="name">Nombre del cliente.</param>
    /// <param name="surnames">Apellidos del cliente.</param>
    /// <param name="age">Edad del cliente.</param>
    /// <param name="phone">Tel�fono del cliente.</param>
    /// <param name="email">Correo electr�nico del cliente.</param>
    /// <param name="address">Direcci�n del cliente.</param>
    /// <param name="doctor">ID del oftalm�logo asociado.</param>
    public void InsertCustomer(string id, string name, string surnames, string age, string phone, string email, string address, int doctor)
    {
        string query = "INSERT INTO clientes (documento_identidad, nombre, apellidos, edad, telefono, correo, direccion, id_oftalmologo) " +
            "VALUES (@id, @name, @surnames, @age, @phone, @email, @address, @doctor)";

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surnames", surnames);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@doctor", doctor);

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
    /// Obtiene el ID de un cliente de la base de datos a partir de su documento de identidad.
    /// </summary>
    /// <param name="documentId">Documento de identidad del cliente.</param>
    /// <returns>El ID del cliente. Devuelve 0 si no se encuentra el cliente.</returns>
    public int GetCustomerIdByDocumentId(string documentId)
    {
        int result = 0;
        string query = "SELECT id_cliente FROM clientes WHERE documento_identidad = @documentId";

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@documentId", documentId);
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al conectar a la base de datos: " + ex.Message);
        }

        return result;
    }

    /// <summary>
    /// Obtiene el ID del oftalmologo de la base de datos a partir de su documento de identidad.
    /// </summary>
    /// <param name="documentId">Documento de identidad del oftalmologo.</param>
    /// <returns>El ID del oftalmologo. Devuelve 0 si no se encuentra el oftalmologo.</returns>
    public int GetDoctorIdByDocumentId(string documentId)
    {
        int result = 0;
        string query = "SELECT id_oftalmologo FROM oftalmologos WHERE documento_identidad = @documentId";

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@documentId", documentId);
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al conectar a la base de datos: " + ex.Message);
        }

        return result;
    }

    /// <summary>
    /// Obtiene una lista de oftalmologos desde la base de datos.
    /// </summary>
    /// <returns>
    /// Una lista de objetos <see cref="Doctor"/> representando los oftalmologos obtenidos de la base de datos.
    /// </returns>
    public List<Doctor> GetAllDoctors()
    {
        List<Doctor> ophthalmologistList = new List<Doctor>();
        string query = "SELECT documento_identidad, nombre, apellidos, telefono, correo FROM oftalmologos";

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Doctor ophthalmologist = new Doctor
                            {
                                Id = reader.GetString("documento_identidad"),
                                Name = reader.GetString("nombre"),
                                Surnames = reader.GetString("apellidos"),
                                Phone = reader.GetString("telefono"),
                                Email = reader.GetString("correo")
                            };
                            ophthalmologistList.Add(ophthalmologist);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error inesperado: " + ex.Message);
        }
        return ophthalmologistList;
    }

    /// <summary>
    /// Inserta un nuevo resultado del cliente a la base de datos.
    /// </summary>
    /// <param name="customerId">Id de la base de datos del cliente.</param>
    /// <param name="resultMessage">El resultado que se le muestra al cliente</param>
    public void InsertResult(int customerId, string resultMessage)
    {
        string query = "INSERT INTO resultados (id_cliente, resultado_prueba, fecha) VALUES (@idCliente, @resultadoPrueba, @fecha);";

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idCliente", customerId);
                    command.Parameters.AddWithValue("@resultadoPrueba", resultMessage);
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();
                    Debug.Log($"Filas insertadas: {rowsAffected}");
                }
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error al insertar datos: {ex.Message}");
        }
    }
}
