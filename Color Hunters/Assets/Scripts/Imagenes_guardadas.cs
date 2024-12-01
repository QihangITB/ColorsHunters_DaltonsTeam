using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Imagenes_guardadas : MonoBehaviour
{
    // Nuestra base de datos tocha en el programa con las imagenes
    public Sprite imagen_1;
    public Sprite imagen_2;
    public Sprite imagen_3;
    public Sprite imagen_4;
    public Sprite imagen_5;
    public Sprite imagen_6;
    public Sprite imagen_7;
    public Sprite imagen_8;
    public Sprite imagen_9;

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

    public GameObject Captura; // donde se mostrará la imagen
    public GameObject punto_focal; // donde se ira cambiando el punto que tiene que encontrar el jugador con sus diferentes versiones
        
    private void Awake()
    {
        changeImage(GameManager.gameManager.getImagen()); // llama nada mas despertar la funcion para asociar imagen
    }


    public void changeImage(int numeroArray)
    {
        GameManager.gameManager.setCuadricula(1); // se setea en 0% de contraste cada vez que el usuario abre imagen
        Image image = Captura.GetComponent<Image>();
       
        Debug.Log(numeroArray);
        
        if (Captura != null)
        {
            if (image != null) // comprueba que la imagen no sea null y en caso de cada numero pues mete en la imagen correspodiente
            {
                switch (numeroArray)
                {
                    case 0:
                        image.sprite = imagen_1;
                       break;
                    case 1:
                        image.sprite = imagen_2;
                        break;
                    case 2:
                        image.sprite = imagen_3;
                        break;
                    case 3:
                        image.sprite = imagen_4;
                        break;
                    case 4:
                        image.sprite = imagen_5;
                        break;
                    case 5:
                        image.sprite = imagen_6;
                        break;
                    case 6:
                        image.sprite = imagen_7;
                        break;
                    case 7:
                        image.sprite = imagen_8;
                        break;
                    case 8:
                        image.sprite = imagen_9;
                        break;
                }
                settear_punto(numeroArray); // una vez seteada la imagen setea su punto de fuga
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

    // funcion que usaran los botones de la camara para asociar si al pulsar estas dando la respuesta correcta, ajustar al gusto en el if pertinente
    public void enviar_respuesta(int quadricula)
    {
        int numeroArray=GameManager.gameManager.getImagen();
        switch (numeroArray)
        {
            case 0:
                if (quadricula == 5)  // este es el if que se tiene que ajustar a cada imagen para saber donde esta el objeto de la pista
                {
                    GameManager.gameManager.respuesta1 = true; // setea el boolean pertinente en true
                    Debug.Log(GameManager.gameManager.respuesta1);
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5) // para que no siga aumentado y vaya buscando puntos de fuga que no existen
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1); // sistema automatizado para ir ajustandole el contraste
                        GameManager.gameManager.cont1++; // contador para sacar conclusiones del jugador
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 1:
                if (quadricula == 5)
                {
                    GameManager.gameManager.respuesta2 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont2++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 2:
                if (quadricula == 9)
                {
                    GameManager.gameManager.respuesta3 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont3++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 3:
                if (quadricula == 2)
                {
                    GameManager.gameManager.respuesta4 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont4++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 4:
                if (quadricula == 4)
                {
                    GameManager.gameManager.respuesta5 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont5++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 5:
                if (quadricula == 5)
                {
                    GameManager.gameManager.respuesta6 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont6++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 6:
                if (quadricula == 5)
                {
                    GameManager.gameManager.respuesta7 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont7++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
            case 7:
                if (quadricula == 4)
                {
                    GameManager.gameManager.respuesta8 = true;
                }
                else
                {
                    if (GameManager.gameManager.getImagen_imagen_quadricula() == 5)
                    {
                        Debug.Log("MAXIMO CONTRASTE ALCANZADO");
                    }
                    else
                    {
                        GameManager.gameManager.setCuadricula(GameManager.gameManager.getImagen_imagen_quadricula() + 1);
                        GameManager.gameManager.cont8++;
                        Debug.Log(GameManager.gameManager.getImagen_imagen_quadricula());
                    }
                }
                break;
        }
        settear_punto(numeroArray);
    }

    private void ControladorRespuesta(int quadricula, int imageIndex)
    {
        if (quadricula == 5) // If the selected grid matches the expected answer
        {
            // Dynamically set the appropriate response boolean using reflection
            typeof(GameManager).GetProperty($"respuesta{imageIndex + 1}").SetValue(GameManager.gameManager, true);

            Debug.Log($"Response for image {imageIndex + 1}: " +
                      typeof(GameManager).GetProperty($"respuesta{imageIndex + 1}").GetValue(GameManager.gameManager));
        }
        else
        {
            int currentQuadricula = GameManager.gameManager.getImagen_imagen_quadricula();

            if (currentQuadricula == 5)
            {
                Debug.Log("MAXIMO CONTRASTE ALCANZADO");
            }
            else
            {
                GameManager.gameManager.setCuadricula(currentQuadricula + 1);
                typeof(GameManager).GetProperty($"cont{imageIndex + 1}").SetValue(GameManager.gameManager,
                    (int)typeof(GameManager).GetProperty($"cont{imageIndex + 1}").GetValue(GameManager.gameManager) + 1);

                Debug.Log($"Cuadricula for image {imageIndex + 1} incremented to {GameManager.gameManager.getImagen_imagen_quadricula()}");
            }
        }
    }

    void settear_punto(int numeroArray)
    {
        Image punto = punto_focal.GetComponent<Image>(); // agarra componente de imagen del punto de fuga
        switch (numeroArray)
        {
            case 0: // en base a la imagen que tiene puesta y el nivel de contraste pues pone la imagen pertienente
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_1_1;
                        break;
                    case 2:
                        punto.sprite = imagen_1_2;
                        break;
                    case 3:
                        punto.sprite = imagen_1_3;
                        break;
                    case 4:
                        punto.sprite = imagen_1_4;
                        break;
                    case 5:
                        punto.sprite = imagen_1_5;
                        break;
                }
                break;
            case 1:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_2_1;
                        break;
                    case 2:
                        punto.sprite = imagen_2_2;
                        break;
                    case 3:
                        punto.sprite = imagen_2_3;
                        break;
                    case 4:
                        punto.sprite = imagen_2_4;
                        break;
                    case 5:
                        punto.sprite = imagen_2_5;
                        break;
                }
                break;
            case 2:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_3_1;
                        break;
                    case 2:
                        punto.sprite = imagen_3_2;
                        break;
                    case 3:
                        punto.sprite = imagen_3_3;
                        break;
                    case 4:
                        punto.sprite = imagen_3_4;
                        break;
                    case 5:
                        punto.sprite = imagen_3_5;
                        break;
                }
                break;
            case 3:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_4_1;
                        break;
                    case 2:
                        punto.sprite = imagen_4_2;
                        break;
                    case 3:
                        punto.sprite = imagen_4_3;
                        break;
                    case 4:
                        punto.sprite = imagen_4_4;
                        break;
                    case 5:
                        punto.sprite = imagen_4_5;
                        break;
                }
                break;
            case 4:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_5_1;
                        break;
                    case 2:
                        punto.sprite = imagen_5_2;
                        break;
                    case 3:
                        punto.sprite = imagen_5_3;
                        break;
                    case 4:
                        punto.sprite = imagen_5_4;
                        break;
                    case 5:
                        punto.sprite = imagen_5_5;
                        break;
                }
                break;
            case 5:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_6_1;
                        break;
                    case 2:
                        punto.sprite = imagen_6_2;
                        break;
                    case 3:
                        punto.sprite = imagen_6_3;
                        break;
                    case 4:
                        punto.sprite = imagen_6_4;
                        break;
                    case 5:
                        punto.sprite = imagen_6_5;
                        break;
                }
                break;
            case 6:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_7_1;
                        break;
                    case 2:
                        punto.sprite = imagen_7_2;
                        break;
                    case 3:
                        punto.sprite = imagen_7_3;
                        break;
                    case 4:
                        punto.sprite = imagen_7_4;
                        break;
                    case 5:
                        punto.sprite = imagen_7_5;
                        break;
                }
                break;
            case 7:
                switch (GameManager.gameManager.getImagen_imagen_quadricula())
                {
                    case 1:
                        punto.sprite = imagen_8_1;
                        break;
                    case 2:
                        punto.sprite = imagen_8_2;
                        break;
                    case 3:
                        punto.sprite = imagen_8_3;
                        break;
                    case 4:
                        punto.sprite = imagen_8_4;
                        break;
                    case 5:
                        punto.sprite = imagen_8_5;
                        break;
                }
                break;
        }
    }
    // Update is called once per frame
}
