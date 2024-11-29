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

    /// <summary>
    /// Método para manejar el inicio de sesión del usuario. 
    /// Verifica si el cliente existe en la base de datos. Si existe, guarda los datos del cliente al game manager y navega a la siguiente escena.
    /// Si no existe, redirige al usuario a la pantalla de registro.
    /// </summary>
    /// <param name="input">Campo de entrada donde el usuario introduce su documento de identidad.</param>
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

    /// <summary>
    /// Método para redirigir al usuario a la pantalla de registro.
    /// Desactiva la pantalla de inicio de sesión y activa el de registro.
    /// </summary>
    private void GoToRegister()
    {
        LoginGroup.SetActive(false);
        RegisterGroup.SetActive(true);
    }

    /// <summary>
    /// Método para registrar un nuevo cliente. 
    /// Guarda los datos del cliente al game manager y lo agrega a la base de datos.
    /// Después navega a la escena siguiente.
    /// </summary>
    public void Register()
    {
        SaveCustomerData();
        _dbManager.AddNewClient();

        // Indice 2 es la escena del libro magico
        _cambiadorEscenas.GoToScene(2);
    }

    /// <summary>
    /// Método para guardar los datos del cliente en el GameManager durante en el juego.
    /// </summary>
    private void SaveCustomerData()
    {
        _gameManager.SetPlayerData(_dbManager.CreateCustomer());
    }

    /// <summary>
    /// Añade la lista de nombres y apellidos de oftalmólogos de la base de datos al Dropdown del formulario de registro.
    /// </summary>
    /// <param name="options">Lista de nombres y apellidos de los oftalmólogos.</param>
    private void AddOptionsToDropdown(List<string> options)
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
