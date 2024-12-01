using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rendir : MonoBehaviour
{
    public void ResultadoNoEncontrado()
    {
        int idImagen = GameManager.gameManager.GetImagen();

        switch (idImagen)
        {
            case 0:
                GameManager.gameManager.respuesta1 = true;
                GameManager.gameManager.cont1 += 5;
                break;
            case 1:
                GameManager.gameManager.respuesta2 = true;
                GameManager.gameManager.cont2 += 5;
                break;
            case 2:
                GameManager.gameManager.respuesta3 = true;
                GameManager.gameManager.cont3 += 5;
                break;
            case 3:
                GameManager.gameManager.respuesta4 = true;
                GameManager.gameManager.cont4 += 5;
                break;
            case 4:
                GameManager.gameManager.respuesta5 = true;
                GameManager.gameManager.cont5 += 5;
                break;
            case 5:
                GameManager.gameManager.respuesta6 = true;
                GameManager.gameManager.cont6 += 5;
                break;
            case 6:
                GameManager.gameManager.respuesta7 = true;
                GameManager.gameManager.cont7 += 5;
                break;
            case 7:
                GameManager.gameManager.respuesta8 = true;
                GameManager.gameManager.cont8 += 5;
                break;
        }
    }
}
