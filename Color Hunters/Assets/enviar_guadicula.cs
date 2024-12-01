using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviar_guadricula : MonoBehaviour
{
    
     // envia la posicion a la camara
     public void enviar_posicion(int posicion)
    {

        GameManager.gameManager.SetCuadricula(posicion);
        Debug.Log("se esta enviando la posicion");
    }
}
