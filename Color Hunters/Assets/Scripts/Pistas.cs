using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pistas : MonoBehaviour
{
    // las pistas que se ponen en cada apartado, ponendalas aqui y se rellenara solo
    string pista1_1 = "pista1";
    string pista1_2 = "pista2";
    string pista1_3 = "pista3";
    string pista1_4 = "pista4";
    string pista1_5 = "pista5";
    string pista1_6 = "pista6";
    string pista1_7 = "pista7";
    string pista1_8 = "pista8";
    string[] pistas;
    public GameObject pistaGO;

    private void Awake()
    {
        pistas = new string[8] { pista1_1, pista1_2, pista1_3, pista1_4, pista1_5, pista1_6, pista1_7, pista1_8 };
    }


    public void Escribir_Pista(int numero)
    {
        // Verificar que el índice esté dentro del rango del arreglo
        if (numero < 0 || numero >= pistas.Length)
        {
            Debug.LogError("Número fuera de rango");
            return;
        }

        // Obtener la pista correspondiente
        string pista = pistas[numero];
        Debug.Log("LA pista es " + pista);

        // Buscar el Text hijo del botón que llamó esta función
        pistaGO.SetActive(true);

        if (pistaGO != null)
        {
            TMP_Text texto = pistaGO.GetComponentInChildren<TMP_Text>();
            if (texto != null)
            {
                texto.text = pista; // Asignar el texto de la pista
            }
            else
            {
                Debug.LogError("El objeto 'Pista' no tiene un componente Text.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el GameObject llamado 'Pista'.");
        }
    }
}
