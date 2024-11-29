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

    public bool IsClientExist(string documentId)
    {
        int notFound = 0;
        return (database.GetClientIdByDocumentId(documentId) != notFound);
    }

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
                AssignDoctorId(doctorDropdown.options[doctorDropdown.value].text)
               );
    }

    public Customer CreateCustomer()
    {
        // El documento de identidad nunca sera nulo o vacío
        string id = idInput.text;

        // Manejar valores nulos o vacís y asignar valores predeterminados
        string name = string.IsNullOrWhiteSpace(nameInput.text) ? "" : nameInput.text;
        string surnames = string.IsNullOrWhiteSpace(surnamesInput.text) ? "" : surnamesInput.text;
        string age = string.IsNullOrWhiteSpace(ageInput.text) ? "" : ageInput.text;
        string phone = string.IsNullOrWhiteSpace(phoneInput.text) ? "" : phoneInput.text;
        string email = string.IsNullOrWhiteSpace(emailInput.text) ? "" : emailInput.text;
        string address = string.IsNullOrWhiteSpace(addressInput.text) ? "" : addressInput.text;
        int doctorId = AssignDoctorId(doctorDropdown.options[doctorDropdown.value].text);

        return new Customer(id, name, surnames, age, phone, email, address, doctorId);
    }

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

    public int AssignDoctorId(string nameAndSurname)
    {
        List<Doctor> doctors = database.GetAllDoctors();

        foreach (Doctor doc in doctors)
        {
            if (doc.Name + " " + doc.Surnames == nameAndSurname)
            {
                return database.GetDoctorIdByDocumentId(doc.Id);
            }
        }

        return 0;
    }
}
