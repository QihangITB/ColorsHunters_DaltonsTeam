using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resultado : MonoBehaviour
{
    private TextMeshProUGUI textoResultado;
    void Start()
    {
        textoResultado = GetComponent<TextMeshProUGUI>();
        textoResultado.text = GameManager.gameManager.MostrarResultado();
    }
}
