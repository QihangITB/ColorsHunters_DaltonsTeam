using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocultar : MonoBehaviour
{
    // script para ocultar cosas
    public GameObject pista;



    public void ocultar()
    {
        pista.SetActive(false);
    }
}
