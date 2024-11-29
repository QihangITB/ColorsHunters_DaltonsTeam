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

    void Start()
    {
        _dbManager = gameObject.GetComponent<DBManager>();
        LoginGroup.SetActive(true);
        RegisterGroup.SetActive(false);
    }

    public void Login(TMP_InputField input)
    {
        if (_dbManager.IsClientExist(input.text))
        {
            //Siguente scena

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
}
