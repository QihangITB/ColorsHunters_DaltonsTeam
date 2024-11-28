using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fotografias : MonoBehaviour
{


    public Sprite imagen1 ;
    public Sprite imagen2;
    public Sprite imagen3;
    public Sprite imagen4;
    public Sprite imagen5;
    public Sprite imagen6;
    public Sprite imagen7;
    public Sprite imagen8;

    Sprite[] imagenes;
    public GameObject pistaGO;

    private void Awake()
    {
        imagenes = new Sprite[8] { imagen1,imagen2,imagen3,imagen4,imagen5,imagen6,imagen7,imagen8 };
    }


    public void     poner_imagen(int numero)
    {
        // Verificar que el índice esté dentro del rango del arreglo
        if (numero < 0 || numero >= imagenes.Length)
        {
            Debug.LogError("Número fuera de rango");
            return;
        }


        // Obtener la pista correspondiente
        Sprite imagen = imagenes[numero];
        Debug.Log("se esta enviando el dato");
        GameManager.gameManager.setImagen(numero);
        GameManager.gameManager.setQuadricula(1);
        Debug.Log("se ha seteado");
        // Buscar el Text hijo del botón que llamó esta función
        pistaGO.SetActive(true);

        if (pistaGO != null)
        {
            Image image = pistaGO.transform.Find("fotografias").GetComponent<Image>();
            if (image != null)
            {
                image.sprite = imagen;
            }
            else
            {
                Debug.LogError("El objeto 'Pista' no tiene un componente SpriteRenderer.");
            }


        }
        else
        {
            Debug.LogError("No se encontró el GameObject llamado 'Pista'.");
        }
    }
}
    
