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
        Debug.Log("IMAGEN " + GameManager.gameManager.GetImagen());
        changeImage(GameManager.gameManager.GetImagen()); // llama nada mas despertar la funcion para asociar imagen
    }


    public void changeImage(int numeroArray)
    {
        GameManager.gameManager.SetCuadricula(1); // se setea en 0% de contraste cada vez que el usuario abre imagen
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
        int numeroArray=GameManager.gameManager.GetImagen();
        switch (numeroArray)
        {
            case 0:
                ControladorRespuesta(quadricula, numeroArray, 5);
                break;
            case 1:
                ControladorRespuesta(quadricula, numeroArray, 5);
                break;
            case 2:
                ControladorRespuesta(quadricula, numeroArray, 3);
                break;
            case 3:
                ControladorRespuesta(quadricula, numeroArray, 8);
                break;
            case 4:
                ControladorRespuesta(quadricula, numeroArray, 4);
                break;
            case 5:
                ControladorRespuesta(quadricula, numeroArray, 5);
                break;
            case 6:
                ControladorRespuesta(quadricula, numeroArray, 4);
                break;
            case 7:
                ControladorRespuesta(quadricula, numeroArray, 5);
                break;
        }
        settear_punto(numeroArray);
    }

    private void ControladorRespuesta(int quadricula, int imageIndex, int respuestaCorrecta)
    {
        if (quadricula == respuestaCorrecta) // este es el if que se tiene que ajustar a cada imagen para saber donde esta el objeto de la pista
        {
            // Assigna dinamicamente el valor de la respuesta a true, ejemplo no dinamico: GameManager.gameManager.respuesta1 = true;
            typeof(GameManager).GetProperty($"respuesta{imageIndex + 1}").SetValue(GameManager.gameManager, true);
        }
        else
        {
            int currentQuadricula = GameManager.gameManager.GetImagenCuadricula();

            if (currentQuadricula == 5) // para que no siga aumentado y vaya buscando puntos de fuga que no existen
            {
                Debug.Log("MAXIMO CONTRASTE ALCANZADO");
            }
            else
            {
                GameManager.gameManager.SetCuadricula(currentQuadricula + 1); // sistema automatizado para ir ajustandole el contraste

                // Contador para sacar conclusiones del jugador, lo hace dinamicamente, ejemplo no dinamico: GameManager.gameManager.cont1++;
                typeof(GameManager).GetProperty($"cont{imageIndex + 1}").SetValue(GameManager.gameManager,
                    (int)typeof(GameManager).GetProperty($"cont{imageIndex + 1}").GetValue(GameManager.gameManager) + 1);
            }
        }
    }

    void settear_punto(int numeroArray)
    {
        Image punto = punto_focal.GetComponent<Image>(); // agarra componente de imagen del punto de fuga
        switch (numeroArray)
        {
            case 0: // en base a la imagen que tiene puesta y el nivel de contraste pues pone la imagen pertienente
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
                switch (GameManager.gameManager.GetImagenCuadricula())
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
