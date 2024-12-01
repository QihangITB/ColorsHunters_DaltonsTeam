using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocultar : MonoBehaviour
{
    public GameObject pista;

    public void ocultar()
    {
        pista.SetActive(false);
    }
}
