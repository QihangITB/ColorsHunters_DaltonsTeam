using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffect : MonoBehaviour
{
    // Variable pública que contiene la referencia a un sistema de partículas
    // que será activado cuando se cumplan ciertas condiciones.
    public GameObject _particleSystem;

    // Método CheckValidOption: Comprueba si una condición asociada a la imagen actual es verdadera.
    // Si la condición se cumple, activa el sistema de partículas.
    public void CheckValidOption()
    {
        // Obtiene el índice de la imagen actual desde el GameManager.
        int currentImage = GameManager.gameManager.GetImagen();

        // Usa una estructura switch para verificar cada posible valor de currentImage.
        switch (currentImage)
        {
            case 0:
                // Si la primera respuesta (respuesta1) es verdadera, activa el sistema de partículas.
                if (GameManager.gameManager.respuesta1 == true)
                    _particleSystem.SetActive(true);
                break;
            case 1:
                // Similar para respuesta2 y así sucesivamente.
                if (GameManager.gameManager.respuesta2 == true)
                    _particleSystem.SetActive(true);
                break;
            case 2:
                if (GameManager.gameManager.respuesta3 == true)
                    _particleSystem.SetActive(true);
                break;
            case 3:
                if (GameManager.gameManager.respuesta4 == true)
                    _particleSystem.SetActive(true);
                break;
            case 4:
                if (GameManager.gameManager.respuesta5 == true)
                    _particleSystem.SetActive(true);
                break;
            case 5:
                if (GameManager.gameManager.respuesta6 == true)
                    _particleSystem.SetActive(true);
                break;
            case 6:
                if (GameManager.gameManager.respuesta7 == true)
                    _particleSystem.SetActive(true);
                break;
            case 7:
                if (GameManager.gameManager.respuesta8 == true)
                    _particleSystem.SetActive(true);
                break;
        }
    }
}
