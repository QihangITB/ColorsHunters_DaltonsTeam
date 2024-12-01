using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comprobante_de_respuesta : MonoBehaviour
{
    public Sprite imagen;
    public int respuesta;
    // Start is called before the first frame update
    void Awake()
    {
        Sprite resu_imagen= gameObject.GetComponent<Image>().sprite;
        Debug.Log(GameManager.gameManager.respuesta1);
        switch (respuesta)
        {
            case 1:
                Debug.Log("analizando respuesta1");
                if (GameManager.gameManager.respuesta1 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 2:
                Debug.Log("analizando respuesta2");
                if (GameManager.gameManager.respuesta2 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 3:
                Debug.Log("analizando respuesta3");
                if (GameManager.gameManager.respuesta3 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 4:
                Debug.Log("analizando respuesta4");
                if (GameManager.gameManager.respuesta4 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 5:
                Debug.Log("analizando respuesta5");
                if (GameManager.gameManager.respuesta5 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 6:
                Debug.Log("analizando respuesta6");
                if (GameManager.gameManager.respuesta6 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 7:
                Debug.Log("analizando respuesta7");
                if (GameManager.gameManager.respuesta7 == true)
                {
                    resu_imagen = imagen;
                }
                break;
            case 8:
                Debug.Log("analizando respuesta8");
                if (GameManager.gameManager.respuesta8 == true)
                {
                    resu_imagen = imagen;
                }
                break;
        }
    }

   
}
