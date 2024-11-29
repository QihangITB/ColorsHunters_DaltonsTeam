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
    public TMP_InputField doctorInput;

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
                int.Parse(doctorInput.text)
               );
    }
}
