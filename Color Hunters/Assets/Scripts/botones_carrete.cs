using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class botones_carrete : MonoBehaviour
{
    public Imagenes_guardadas guardadas;
    // funcion que sirve para cambiar las imagenes cuando les das a un boton del carretee
    public void cambiarimagenBotones(int posicion)
    {
        Debug.Log(GameManager.gameManager.posiciones[posicion]);//imprimimos para saber si esta imprimimiendo bien la posicion
        guardadas.changeImage(GameManager.gameManager.posiciones[posicion]);// usamos la funcion de cambiar la imagen de imagenes_guardadas para cambiar la posiciion mediante la posicion guardada en la lista de posiciones
        GameManager.gameManager.setImagen(GameManager.gameManager.posiciones[posicion]); // seteamos este valor para que las otras funciones que agarran directamente desde el gameManager tambien sepan cual agarrar.
    }


}
