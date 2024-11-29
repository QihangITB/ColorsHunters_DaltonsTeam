using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Carrete : MonoBehaviour
{
    
    string[] imagene_1;

    private void Awake()
    {
        imagene_1 = new string[9] { "flores", "Castillo", "sumama", "alicante", "picante", "imagen_1_6", "imagen_1_7", "imagen_1_8", "imagen_1_9" };
       // Debug.Log("Estado del carrete en el GameManager antes de llamar a rellenar(): " + string.Join(", ", GameManager.gameManager.carrete));
        rellenar();

    }

    public void rellenar()
    {
        int nuevaImagen = GameManager.gameManager.getImagen();
        Debug.Log("el numero de carga del acrrete es: " + GameManager.gameManager.carrete.Count);
        foreach (var car in GameManager.gameManager.carrete)
        {
            Debug.Log("EN EL CARRETE HAY " + car);
        }
        // Asegurar el tamaño máximo del carrete
        if (GameManager.gameManager.carrete.Count >= 8)
        {
            GameManager.gameManager.carrete.RemoveAt(0); // Eliminar el primero
            GameManager.gameManager.posiciones.RemoveAt(0);  // Eliminar el primero
        }

        // Agregar nuevas entradas

        Debug.Log(" int nuevaimagen " + nuevaImagen);
        GameManager.gameManager.carrete.Add(seleccion(nuevaImagen));
        //Debug.Log("Después de modificar: " + string.Join(", ", GameManager.gameManager.carrete));
        GameManager.gameManager.posiciones.Add(nuevaImagen);

        // Actualizar la UI
        for (int i = 0; i < 8; i++)
        {
            if (i >= transform.childCount) break;

            Transform currentChild = transform.GetChild(i);
            Transform grandchild = currentChild.GetChild(0);
            TextMeshProUGUI tmpComponent = grandchild.GetComponent<TextMeshProUGUI>();

            if (tmpComponent == null)
            {
                Debug.LogWarning($"El hijo {i} no tiene un componente TextMeshProUGUI.");
                continue;
            }

            if (i >= GameManager.gameManager.carrete.Count)
            {
               // Debug.Log("se ha puesto empty");
                tmpComponent.text = "Empty";
            }
            else
            {
                tmpComponent.text = GameManager.gameManager.carrete[i];
            }
        }
    }

    public string seleccion(int numeroArray)
    {
        string anyadir = "";
        anyadir = imagene_1[numeroArray];
        return anyadir;

    }


}



