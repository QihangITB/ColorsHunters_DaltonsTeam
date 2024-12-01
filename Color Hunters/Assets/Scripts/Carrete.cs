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
    // en el awake carga el nombre de las imagenes, cambiar al gusto.
    private void Awake()
    {
        imagene_1 = new string[9] { "flores", "Castillo", "sumama", "alicante", "picante", "imagen_1_6", "imagen_1_7", "imagen_1_8", "imagen_1_9" };
       // Debug.Log("Estado del carrete en el GameManager antes de llamar a rellenar(): " + string.Join(", ", GameManager.gameManager.carrete));
        rellenar(); // se llama a la funcion de rellenar

    }

    public void rellenar()
    {
        int nuevaImagen = GameManager.gameManager.GetImagen(); // carga el id de la imagen que estamos enviando mediante el game manager

        // Verificar si la imagen ya está en las posiciones
        bool imagenExistente = GameManager.gameManager.posiciones.Contains(nuevaImagen);

        if (imagenExistente)
        {
            Debug.Log("La imagen ya está en las posiciones, no se agregará al carrete.");
        }
        else
        {
            // Solo agregamos nuevas entradas si la imagen no está en las posiciones
            Debug.Log("Int nuevaImagen: " + nuevaImagen);//imprimimos para las pruebas
            GameManager.gameManager.carrete.Add(seleccion(nuevaImagen));// de nuestra array seleccionamos el nombre que le corresponde mediante la funcion selection que etsa mas abajo
            GameManager.gameManager.posiciones.Add(nuevaImagen);// añadimos al carrete

            // Asegurar el tamaño máximo del carrete
            if (GameManager.gameManager.carrete.Count >= 8)
            {
                GameManager.gameManager.carrete.RemoveAt(0); // Eliminar el primero
                GameManager.gameManager.posiciones.RemoveAt(0);  // Eliminar el primero
            }
        }

        // Actualizar la UI (siempre se actualiza)
        Debug.Log("El número de carga del carrete es: " + GameManager.gameManager.carrete.Count);
        foreach (var car in GameManager.gameManager.carrete)
        {
            Debug.Log("EN EL CARRETE HAY " + car);
        }

        for (int i = 0; i < 8; i++)
        {
            if (i >= transform.childCount) break;


            // como este script esta en el abuelo del componente textmeshpro pues hacemos todo esto para pillar el componente
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
                tmpComponent.text = "Empty";// rellenar campos vacios con empty que queda mejor
            }
            else
            {
                tmpComponent.text = GameManager.gameManager.carrete[i].ToString(); // Asegúrate de que sea un valor adecuado para mostrar
            }
        }
    }

    public string seleccion(int numeroArray)
    {
        // seleccionamos el string correspondiente y lo devolvemos
        string anyadir = "";
        anyadir = imagene_1[numeroArray];
        return anyadir;

    }


}



