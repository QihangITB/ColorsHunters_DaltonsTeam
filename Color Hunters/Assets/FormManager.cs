using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FormManager : MonoBehaviour
{
    public GameObject LoginGroup;
    public GameObject RegisterGroup;

    private DBManager _dbManager;
    private CambiadorEscenas _cambiadorEscenas;

    void Start()
    {
        _dbManager = gameObject.GetComponent<DBManager>();
        _cambiadorEscenas = gameObject.GetComponent<CambiadorEscenas>();
        LoginGroup.SetActive(true);
        RegisterGroup.SetActive(false);
    }

    public void Login(TMP_InputField input)
    {
        if (_dbManager.IsClientExist(input.text))
        {
            // Indice 2 es la escena del libro magico
            Debug.Log(_cambiadorEscenas);
            _cambiadorEscenas.GoToScene(2);
        }
        else
        {
            GoToRegister();
        }
    }

    public void GoToRegister()
    {
        LoginGroup.SetActive(false);
        RegisterGroup.SetActive(true);
    }

    public void Register()
    {
        _dbManager.AddNewClient();

        // Indice 2 es la escena del libro magico
        _cambiadorEscenas.GoToScene(2);
    }
}
