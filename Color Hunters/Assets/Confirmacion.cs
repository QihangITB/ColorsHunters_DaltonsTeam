using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmacion : MonoBehaviour
{
   public void sala_de_datos()
    {
        // comprueba que todo este bien y entonces te envia a la sala de los datos, el numero es temporal, cambiar a gusto
        if (GameManager.gameManager.alltrue())
        {
            GameManager.gameManager.ChangeScene(5);
        }
    }
}
