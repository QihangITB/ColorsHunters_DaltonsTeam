using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagenes_guardadas : MonoBehaviour
{
    public Sprite imagen_1_1;
    public Sprite imagen_1_2;
    public Sprite imagen_1_3;
    public Sprite imagen_1_4;
    public Sprite imagen_1_5;
    public Sprite imagen_1_6;
    public Sprite imagen_1_7;
    public Sprite imagen_1_8;
    public Sprite imagen_1_9;
    public GameObject Captura; 


    Sprite[] imagene_1;
    Sprite[] imagene_2;
    private void Awake()
    {
        imagene_1 = new Sprite[9] { imagen_1_1, imagen_1_2, imagen_1_3, imagen_1_4, imagen_1_5 , imagen_1_6 , imagen_1_7 , imagen_1_8 , imagen_1_9 };
        imagene_2 = new Sprite[9] { imagen_1_1, imagen_1_2, imagen_1_3, imagen_1_4, imagen_1_5, imagen_1_6, imagen_1_7, imagen_1_8, imagen_1_9 };

        Image image = Captura.GetComponentInChildren<Image>(true);

        //Sprite foografia = imagene_ + (GameManager.gameManager.getImagen)[GameManager.gameManager.getImagen_imagen_guadricula];

        if (Captura != null)
        {
            if (image != null)
            {
                //image.sprite = imagen;
            }
            else
            {
                Debug.LogError("El objeto 'Pista' no tiene un componente SpriteRenderer.");
            }


        }
        else
        {
            Debug.LogError("No se encontr� el GameObject llamado 'Pista'.");
        }
    }

    // Update is called once per frame
   


}
