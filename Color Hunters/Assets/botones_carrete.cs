using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class botones_carrete : MonoBehaviour
{
    public Imagenes_guardadas guardadas;
    // funcion que sirve para cambiar las imagenes cuando les das a un boton del carretee
    public void cambiarimagenBotones(int posicion)
    {
        Debug.Log(GameManager.gameManager.posiciones[posicion]);
        guardadas.changeImage(GameManager.gameManager.posiciones[posicion]);
        GameManager.gameManager.SetImagen(GameManager.gameManager.posiciones[posicion]);
    }
}
