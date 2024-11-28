using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocultar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pista;



    public void ocultar()
    {
        pista.SetActive(false);
    }
}
