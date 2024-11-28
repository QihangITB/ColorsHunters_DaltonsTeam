using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Imagenes_guardadas : MonoBehaviour
{
    public Sprite imagen_1;
    public Sprite imagen_2;
    public Sprite imagen_3;
    public Sprite imagen_4;
    public Sprite imagen_5;
    public Sprite imagen_6;
    public Sprite imagen_7;
    public Sprite imagen_8;
    public Sprite imagen_1_1;
    public Sprite imagen_1_2;
    public Sprite imagen_1_3;
    public Sprite imagen_1_4;
    public Sprite imagen_1_5;
    public Sprite imagen_2_1;
    public Sprite imagen_2_2;
    public Sprite imagen_2_3;
    public Sprite imagen_2_4;
    public Sprite imagen_2_5;
    public Sprite imagen_3_1;
    public Sprite imagen_3_2;
    public Sprite imagen_3_3;
    public Sprite imagen_3_4;
    public Sprite imagen_3_5;
    public Sprite imagen_4_1;
    public Sprite imagen_4_2;
    public Sprite imagen_4_3;
    public Sprite imagen_4_4;
    public Sprite imagen_4_5;
    public Sprite imagen_5_1;
    public Sprite imagen_5_2;
    public Sprite imagen_5_3;
    public Sprite imagen_5_4;
    public Sprite imagen_5_5;
    public Sprite imagen_6_1;
    public Sprite imagen_6_2;
    public Sprite imagen_6_3;
    public Sprite imagen_6_4;
    public Sprite imagen_6_5;
    public Sprite imagen_7_1;
    public Sprite imagen_7_2;
    public Sprite imagen_7_3;
    public Sprite imagen_7_4;
    public Sprite imagen_7_5;
    public Sprite imagen_8_1;
    public Sprite imagen_8_2;
    public Sprite imagen_8_3;
    public Sprite imagen_8_4;
    public Sprite imagen_8_5;


    public GameObject Captura;
    public GameObject punto_focal;


    
    private void Awake()
    {
       
        changeImage(GameManager.gameManager.getImagen());
       
    }


    public void changeImage(int numeroArray)
    {

        Image image = Captura.GetComponent<Image>();
       
        Debug.Log(numeroArray);
        
        if (Captura != null)
        {
            if (image != null)
            {
                switch (numeroArray)
                {
                    case 0:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_1;
                       
                        break;
                    case 1:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_2;
                       
                        break;
                    case 2:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_3;
                       
                        break;
                    case 3:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_4;
                        
                        break;
                    case 4:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_5;
                       
                        break;
                    case 5:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_6;
                        
                        break;
                    case 6:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_7;
                        
                        break;
                    case 7:
                        Debug.Log("se ha impreso la foto");
                        image.sprite = imagen_8;
                        
                        break;
                }

                settear_punto(numeroArray);
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


    public void enviar_respuesta(int quadricula)
    {
        int numeroArray=GameManager.gameManager.getImagen();
       

        switch (numeroArray)
        {
            case 0:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 8)
                {
                    GameManager.gameManager.respuesta1 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    
                    GameManager.gameManager.cont1++;
                    Debug.Log(GameManager.gameManager.getImagen_imagen_guadricula());

                }
                break;
            case 1:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 8)
                {
                    GameManager.gameManager.respuesta2 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont2++;
                }
                break;
            case 2:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 6)
                {
                    GameManager.gameManager.respuesta3 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont3++;
                }
                break;
            case 3:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 6)
                {
                    GameManager.gameManager.respuesta4 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont4++;
                }
                break;
            case 4:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 6)
                {
                    GameManager.gameManager.respuesta5 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont5++;
                }
                break;
            case 5:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 6)
                {
                    GameManager.gameManager.respuesta6 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont6++;
                }
                break;
            case 6:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 6)
                {
                    GameManager.gameManager.respuesta7 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont7++;
                }
                break;
            case 7:
                Debug.Log("se ha impreso la foto");
                if (quadricula == 6)
                {
                    GameManager.gameManager.respuesta8 = true;
                }
                else
                {
                    GameManager.gameManager.setQuadricula(GameManager.gameManager.getImagen_imagen_guadricula() + 1);
                    GameManager.gameManager.cont8++;
                }
                break;
        }
        settear_punto(numeroArray);
    }

    void settear_punto(int numeroArray)
    {
       
        Image punto = punto_focal.GetComponent<Image>();

        switch (numeroArray)
        {
            case 0:
                
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_1_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_1_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_1_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_1_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_1_5;
                        break;
                }
                break;
            case 1:
                
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_2_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_2_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_2_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_2_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_2_5;
                        break;
                }
                break;
            case 2:
              
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_3_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_3_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_3_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_3_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_3_5;
                        break;
                }
                break;
            case 3:
               
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_4_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_4_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_4_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_4_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_4_5;
                        break;
                }
                break;
            case 4:
               
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_5_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_5_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_5_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_5_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_5_5;
                        break;
                }
                break;
            case 5:
                
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_6_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_6_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_6_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_6_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_6_5;
                        break;
                }
                break;
            case 6:
               
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_7_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_7_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_7_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_7_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_7_5;
                        break;
                }
                break;
            case 7:
                
                switch (GameManager.gameManager.getImagen_imagen_guadricula())
                {
                    case 1:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_1_1;
                        break;
                    case 2:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_8_2;
                        break;
                    case 3:
                        Debug.Log("se ha impreso el punto de focoo");
                        punto.sprite = imagen_8_3;
                        break;
                    case 4:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_8_4;
                        break;
                    case 5:
                        Debug.Log("se ha impreso el punto de foco");
                        punto.sprite = imagen_8_5;
                        break;
                }
                break;
        }
    }

    // Update is called once per frame
   


}
