using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public TMP_InputField idInput;
    public TMP_InputField nameInput;
    public TMP_InputField surnamesInput;
    public TMP_InputField ageInput;
    public TMP_InputField phoneInput;
    public TMP_InputField emailInput;
    public TMP_InputField addressInput;
    public TMP_Dropdown doctorDropdown;

    public DBConnection database;

    void Start()
    {
        database = new DBConnection();
        //database.ConnectionTest();
    }

    /// <summary>
    /// Verifica si un cliente ya existe en la base de datos basado en el documento de identidad.
    /// </summary>
    /// <param name="documentId">El documento de identidad del cliente.</param>
    /// <returns>Devuelve `true` si el cliente existe, `false` si no.</returns>
    public bool IsClientExist(string documentId)
    {
        int notFound = 0;
        return (database.GetClientIdByDocumentId(documentId) != notFound);
    }

    /// <summary>
    /// Agrega un nuevo cliente a la base de datos usando la informacion proporcionada en los campos de entrada.
    /// </summary>
    public void AddNewClient()
    {
        database.InsertClient(
                idInput.text,
                nameInput.text,
                surnamesInput.text,
                ageInput.text,
                phoneInput.text,
                emailInput.text,
                addressInput.text,
                GetDoctorDatabaseId(doctorDropdown.options[doctorDropdown.value].text)
               );
    }

    /// <summary>
    /// Crea un nuevo objeto `Customer` usando los datos proporcionados en los campos de entrada, asignando valores predeterminados a los campos vacios.
    /// </summary>
    /// <returns>Un nuevo objeto `Customer` con la informaci�n proporcionada.</returns>
    public Customer CreateCustomer()
    {
        // El documento de identidad nunca sera nulo o vac�o
        string id = idInput.text;

        // Manejar valores nulos o vac�s y asignar valores predeterminados
        string name = string.IsNullOrWhiteSpace(nameInput.text) ? "" : nameInput.text;
        string surnames = string.IsNullOrWhiteSpace(surnamesInput.text) ? "" : surnamesInput.text;
        string age = string.IsNullOrWhiteSpace(ageInput.text) ? "" : ageInput.text;
        string phone = string.IsNullOrWhiteSpace(phoneInput.text) ? "" : phoneInput.text;
        string email = string.IsNullOrWhiteSpace(emailInput.text) ? "" : emailInput.text;
        string address = string.IsNullOrWhiteSpace(addressInput.text) ? "" : addressInput.text;
        int doctorId = GetDoctorDatabaseId(doctorDropdown.options[doctorDropdown.value].text);

        return new Customer(id, name, surnames, age, phone, email, address, doctorId);
    }

    /// <summary>
    /// Obtiene una lista de nombres y apellidos de todos los oftalmologos desde la base de datos.
    /// </summary>
    /// <returns>Una lista de cadenas con los nombres completos de los oftalmologos.</returns>
    public List<string> GetListOfDoctorsNameAndSurnames()
    {
        List<string> resultList = new List<string>();
        List<Doctor> doctors = database.GetAllDoctors();

        foreach (Doctor doc in doctors)
        {
            resultList.Add(doc.Name + " " + doc.Surnames);
        }
        return resultList;
    }

    /// <summary>
    /// Obtiene el ID de oftalmologo a traves del nombre completo del oftalmologo.
    /// </summary>
    /// <param name="nameAndSurname">El nombre completo del oftalmologo.</param>
    /// <returns>El ID del oftalmologo o 0 si no se encuentra.</returns>
    public int GetDoctorDatabaseId(string nameAndSurname)
    {
        List<Doctor> doctors = database.GetAllDoctors();

        foreach (Doctor doc in doctors)
        {
            if (doc.Name + " " + doc.Surnames == nameAndSurname)
            {
                // doc.Id es el documento de identidad, con la funcion obtenemos el id de la db
                return database.GetDoctorIdByDocumentId(doc.Id); 
            }
        }
        return 0;
    }
}
