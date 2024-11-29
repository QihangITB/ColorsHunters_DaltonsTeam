using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class FormManager : MonoBehaviour
{
    public GameObject LoginGroup;
    public GameObject RegisterGroup;

    private DBManager _dbManager;
    private GameManager _gameManager;
    private CambiadorEscenas _cambiadorEscenas;

    void Start()
    {
        _dbManager = gameObject.GetComponent<DBManager>();
        _cambiadorEscenas = gameObject.GetComponent<CambiadorEscenas>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LoginGroup.SetActive(true);
        RegisterGroup.SetActive(false);

        AddOptionsToDropdown(_dbManager.GetListOfDoctorsNameAndSurnames());
    }

    public void Login(TMP_InputField input)
    {
        if (_dbManager.IsClientExist(input.text))
        {
            SaveCustomerData();

            // Indice 2 es la escena del libro magico
            _cambiadorEscenas.GoToScene(2);
        }
        else
        {
            GoToRegister();
        }
    }

    private void GoToRegister()
    {
        LoginGroup.SetActive(false);
        RegisterGroup.SetActive(true);
    }

    public void Register()
    {
        SaveCustomerData();
        _dbManager.AddNewClient();

        // Indice 2 es la escena del libro magico
        _cambiadorEscenas.GoToScene(2);
    }

    private void SaveCustomerData()
    {
        _gameManager.SetPlayerData(_dbManager.CreateCustomer());
    }

    void AddOptionsToDropdown(List<string> options)
    {
        // Cogemos el dropdown del _dbmanager para facilitar evitar crear más variables
        _dbManager.doctorDropdown.ClearOptions(); // Limpiar las opciones actuales

        List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();

        foreach (string option in options)
        {
            dropdownOptions.Add(new TMP_Dropdown.OptionData(option)); // Crear una opción con el texto
        }

        _dbManager.doctorDropdown.AddOptions(dropdownOptions);
    }
}
