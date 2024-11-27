using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Carrete : MonoBehaviour
{
    public List<string> carrete = GameManager.gameManager.carrete;
    public List<int> imagen = new List<int>();
    public List<int> posicion = new List<int>();
    string[] imagene_1;
    string[] imagene_2;
    string[] imagene_3;
    string[] imagene_4;
    string[] imagene_5;
    string[] imagene_6;
    string[] imagene_7;
    string[] imagene_8;
   
    private void Awake()
    {
        imagene_1 = new string[9] { "bosque esquina superior", "imagen_1_2", "imagen_1_3", "imagen_1_4", "imagen_1_5", "imagen_1_6", "imagen_1_7", "imagen_1_8", "imagen_1_9" };
        imagene_2 = new string[9] { "imagen_2_1", "imagen_2_2", "imagen_2_3", "imagen_2_4", "imagen_2_5", "imagen_2_6", "imagen_2_7", "imagen_2_8", "imagen_2_9" };
        imagene_3 = new string[9] { "imagen_3_1", "imagen_3_2", "imagen_3_3", "imagen_3_4", "imagen_2_5", "imagen_2_6", "imagen_2_7", "imagen_2_8", "imagen_2_9" };
        imagene_4 = new string[9] { "imagen_3_1", "imagen_3_2", "imagen_3_3", "imagen_3_4", "imagen_4_5", "imagen_4_6", "imagen_2_7", "imagen_2_8", "imagen_2_9" };
        imagene_5 = new string[9] { "imagen_5_1", "imagen_5_2", "imagen_3_3", "imagen_3_4", "imagen_2_5", "imagen_2_6", "imagen_2_7", "imagen_2_8", "imagen_2_9" };
        imagene_6 = new string[9] { "imagen_6_1", "imagen_5_2", "imagen_3_3", "imagen_3_4", "imagen_4_5", "imagen_4_6", "imagen_2_7", "imagen_2_8", "imagen_2_9" };
        imagene_7 = new string[9] { "imagen_7_1", "imagen_7_2", "imagen_3_3", "imagen_3_4", "imagen_7_5", "imagen_7_6", "imagen_7_7", "imagen_7_8", "imagen_7_9" };
        imagene_8 = new string[9] { "imagen_8_1", "imagen_8_2", "imagen_3_3", "imagen_3_4", "imagen_4_5", "imagen_8_6", "imagen_2_7", "imagen_2_8", "imagen_2_9" };
        rellenar();
    }

    public void rellenar()
    {
        if (carrete.Count >= 5)
        {
            carrete.RemoveAt(0);
            posicion.RemoveAt(0);
            imagen.RemoveAt(0);
            carrete.Add(seleccion(GameManager.gameManager.getImagen(), GameManager.gameManager.getImagen_imagen_guadricula()));
            imagen.Add(GameManager.gameManager.getImagen());
            posicion.Add(GameManager.gameManager.getImagen_imagen_guadricula());
        }
        else
        {
            carrete.Add(seleccion(GameManager.gameManager.getImagen(), GameManager.gameManager.getImagen_imagen_guadricula()));
        }

        for (int i = 0; i < 5; i++)
        {
            // Verificar si el hijo existe
            if (i >= transform.childCount)
            {
                Debug.LogWarning($"El objeto transform no tiene suficiente hijos. Se esperaba al menos 5, pero tiene {transform.childCount}.");
                break;
            }

            Transform currentChild = transform.GetChild(i);
            Transform grandchild = currentChild.GetChild(0);
            TextMeshProUGUI tmpComponent = grandchild.GetComponent<TextMeshProUGUI>();

            // Verificar si el componente existe
            if (tmpComponent == null)
            {
                Debug.LogWarning($"El hijo {i} no tiene un componente TextMeshProUGUI.");
                continue;
            }

            // Verificar si carrete tiene suficiente elementos
            if (i >= carrete.Count)
            {
                tmpComponent.text = "Empty";
                Debug.Log($"No hay suficiente elementos en carrete para llenar el hijo {i}. Se asigna 'Empty'.");
            }
            else
            {
                tmpComponent.text = carrete[i];
            }
        }
    }

    public string seleccion(int numeroArray, int numeroPosicion)
    {
        string anyadir = "";
                switch (numeroArray)
                {
                    case 0:
                        Debug.Log("se ha impreso la foto");
                         anyadir= imagene_1[numeroPosicion];
                        break;
                    case 1:
                        Debug.Log("se ha impreso la foto");
                              anyadir = imagene_2[numeroPosicion];
                        break;
                    case 2:
                        Debug.Log("se ha impreso la foto");
                              anyadir = imagene_3[numeroPosicion];
                        break;
                    case 3:
                        Debug.Log("se ha impreso la foto");
                             anyadir = imagene_4[numeroPosicion];
                        break;
                    case 4:
                        Debug.Log("se ha impreso la foto");
                             anyadir = imagene_5[numeroPosicion];
                        break;
                    case 5:
                        Debug.Log("se ha impreso la foto");
                             anyadir = imagene_6[numeroPosicion];
                        break;
                    case 6:
                        Debug.Log("se ha impreso la foto");
                             anyadir = imagene_7[numeroPosicion];
                        break;
                    case 7:
                        Debug.Log("se ha impreso la foto");
                            anyadir = imagene_8[numeroPosicion];
                        break;
                }
        return anyadir;
            
    }


}
