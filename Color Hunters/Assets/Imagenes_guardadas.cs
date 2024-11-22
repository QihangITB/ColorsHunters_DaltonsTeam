using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    public Sprite imagen_2_1;
    public Sprite imagen_2_2;
    public Sprite imagen_2_3;
    public Sprite imagen_2_4;
    public Sprite imagen_2_5;
    public Sprite imagen_2_6;
    public Sprite imagen_2_7;
    public Sprite imagen_2_8;
    public Sprite imagen_2_9;
    public Sprite imagen_3_1;
    public Sprite imagen_3_2;
    public Sprite imagen_3_3;
    public Sprite imagen_3_4;
    public Sprite imagen_3_5;
    public Sprite imagen_3_6;
    public Sprite imagen_3_7;
    public Sprite imagen_3_8;
    public Sprite imagen_3_9;
    public Sprite imagen_4_1;
    public Sprite imagen_4_2;
    public Sprite imagen_4_3;
    public Sprite imagen_4_4;
    public Sprite imagen_4_5;
    public Sprite imagen_4_6;
    public Sprite imagen_4_7;
    public Sprite imagen_4_8;
    public Sprite imagen_4_9;
    public Sprite imagen_5_1;
    public Sprite imagen_5_2;
    public Sprite imagen_5_3;
    public Sprite imagen_5_4;
    public Sprite imagen_5_5;
    public Sprite imagen_5_6;
    public Sprite imagen_5_7;
    public Sprite imagen_5_8;
    public Sprite imagen_5_9;
    public Sprite imagen_6_1;
    public Sprite imagen_6_2;
    public Sprite imagen_6_3;
    public Sprite imagen_6_4;
    public Sprite imagen_6_5;
    public Sprite imagen_6_6;
    public Sprite imagen_6_7;
    public Sprite imagen_6_8;
    public Sprite imagen_6_9;
    public Sprite imagen_7_1;
    public Sprite imagen_7_2;
    public Sprite imagen_7_3;
    public Sprite imagen_7_4;
    public Sprite imagen_7_5;
    public Sprite imagen_7_6;
    public Sprite imagen_7_7;
    public Sprite imagen_7_8;
    public Sprite imagen_7_9;
    public Sprite imagen_8_1;
    public Sprite imagen_8_2;
    public Sprite imagen_8_3;
    public Sprite imagen_8_4;
    public Sprite imagen_8_5;
    public Sprite imagen_8_6;
    public Sprite imagen_8_7;
    public Sprite imagen_8_8;
    public Sprite imagen_8_9;
    public GameObject Captura; 


    Sprite[] imagene_1;
    Sprite[] imagene_2;
    Sprite[] imagene_3;
    Sprite[] imagene_4;
    Sprite[] imagene_5;
    Sprite[] imagene_6;
    Sprite[] imagene_7;
    Sprite[] imagene_8;
    private void Awake()
    {
        imagene_1 = new Sprite[9] { imagen_1_1, imagen_1_2, imagen_1_3, imagen_1_4, imagen_1_5 , imagen_1_6 , imagen_1_7 , imagen_1_8 , imagen_1_9 };
        imagene_2 = new Sprite[9] { imagen_2_1, imagen_2_2, imagen_2_3, imagen_2_4, imagen_2_5, imagen_2_6, imagen_2_7, imagen_2_8, imagen_2_9 };
        imagene_3 = new Sprite[9] { imagen_3_1, imagen_3_2, imagen_3_3, imagen_3_4, imagen_3_5, imagen_3_6, imagen_3_7, imagen_3_8, imagen_3_9 };
        imagene_4 = new Sprite[9] { imagen_4_1, imagen_4_2, imagen_4_3, imagen_4_4, imagen_4_5, imagen_4_6, imagen_4_7, imagen_4_8, imagen_4_9 };
        imagene_5 = new Sprite[9] { imagen_5_1, imagen_5_2, imagen_5_3, imagen_5_4, imagen_5_5, imagen_5_6, imagen_5_7, imagen_5_8, imagen_5_9 };
        imagene_6 = new Sprite[9] { imagen_6_1, imagen_6_2, imagen_6_3, imagen_6_4, imagen_6_5, imagen_6_6, imagen_6_7, imagen_6_8, imagen_6_9 };
        imagene_7 = new Sprite[9] { imagen_7_1, imagen_7_2, imagen_7_3, imagen_7_4, imagen_7_5, imagen_7_6, imagen_7_7, imagen_7_8, imagen_7_9 };
        imagene_8 = new Sprite[9] { imagen_8_1, imagen_8_2, imagen_8_3, imagen_8_4, imagen_8_5, imagen_8_6, imagen_8_7, imagen_8_8, imagen_8_9 };
        changeImage(GameManager.gameManager.getImagen(), GameManager.gameManager.getImagen_imagen_guadricula());
       
    }


    public void changeImage(int numeroArray, int numeroPosicion)
    {

        Image image = Captura.GetComponent<Image>();
        Debug.Log(numeroArray);
        Debug.Log(numeroPosicion);
        if (Captura != null)
        {
            if (image != null)
            {
                switch (numeroArray)
                {
                    case 0:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_1[numeroPosicion];
                        break;
                    case 1:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_2[numeroPosicion];
                        break;
                    case 2:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_3[numeroPosicion];
                        break;
                    case 3:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_4[numeroPosicion];
                        break;
                    case 4:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_5[numeroPosicion];
                        break;
                    case 5:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_6[numeroPosicion];
                        break;
                    case 6:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_7[numeroPosicion];
                        break;
                    case 7:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagene_8[numeroPosicion];
                        break;
                }
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

    // Update is called once per frame
   


}
