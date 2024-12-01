using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class comprobante_de_respuesta : MonoBehaviour
{
    
    public int respuesta;
    // se encarga de comprobar si las resoluciones estan hechas y muestra imagen
    void Awake()
    {
        Image resu_imagen = gameObject.GetComponent<Image>(); // componente imagen 
        TextMeshProUGUI texto = transform.GetChild(0).GetComponent<TextMeshProUGUI>(); // componente del texto
        Debug.Log(GameManager.gameManager.respuesta1); // comprobacion si estaba funcionando bien
        switch (respuesta)
        {

            // cada caso de respuesta y a que contador tiene que ir el cambio de imagen
            case 1:
                Debug.Log("analizando respuesta1");
                if (GameManager.gameManager.respuesta1 == true)
                {
                    resu_imagen.enabled=true; // por si no lo sabiais como me ha pasado a mi, la mayoria de componentes se les quita su funcion asi en vez de con el setActive
                    texto.enabled=false;
                }
                break;
            case 2:
                Debug.Log("analizando respuesta2");
                if (GameManager.gameManager.respuesta2 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
            case 3:
                Debug.Log("analizando respuesta3");
                if (GameManager.gameManager.respuesta3 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
            case 4:
                Debug.Log("analizando respuesta4");
                if (GameManager.gameManager.respuesta4 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
            case 5:
                Debug.Log("analizando respuesta5");
                if (GameManager.gameManager.respuesta5 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
            case 6:
                Debug.Log("analizando respuesta6");
                if (GameManager.gameManager.respuesta6 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
            case 7:
                Debug.Log("analizando respuesta7");
                if (GameManager.gameManager.respuesta7 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
            case 8:
                Debug.Log("analizando respuesta8");
                if (GameManager.gameManager.respuesta8 == true)
                {
                    resu_imagen.enabled = true;
                    texto.enabled = false;
                }
                break;
        }
    }

   
}
