using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviar_guadricula : MonoBehaviour
{
    
    
     public void enviar_posicion(int posicion)
    {
        GameManager.gameManager.setQuadricula(posicion);
    }
}
