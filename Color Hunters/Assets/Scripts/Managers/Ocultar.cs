using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocultar : MonoBehaviour
{
    // script para ocultar cosas
    public GameObject objeto;



    public void ocultar()
    {
        objeto.SetActive(false);
    }
}
