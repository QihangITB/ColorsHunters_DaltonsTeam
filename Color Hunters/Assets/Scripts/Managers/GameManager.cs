using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; // declaracion statica
    private int imagen_contraste; // tipo de contraste
    private int imagen_completa; // id de imagen que se esta utilizando
    public bool respuesta1 { get; set; } = false; 
    public bool respuesta2 { get; set; } = false;
    public bool respuesta3 { get; set; } = false;
    public bool respuesta4 { get; set; } = false;
    public bool respuesta5 { get; set; } = false; // booleans de las respuestas para saber si ha acertado el jugador
    public bool respuesta6 { get; set; } = false;
    public bool respuesta7 { get; set; } = false;
    public bool respuesta8 { get; set; } = false;

    public int cont1 { get; set; } = 1;
    public int cont2 { get; set; } = 1;
    public int cont3 { get; set; } = 1;
    public int cont4 { get; set; } = 1; // contadores para saber hasta que grado de contraste a subido
    public int cont5 { get; set; } = 1;
    public int cont6 { get; set; } = 1;
    public int cont7 { get; set; } = 1;
    public int cont8 { get; set; } = 1;

    public List<string> carrete = new List<string>(); // para no pderder el carrete con los cambios de escena

    public List<int> posiciones = new List<int>(); // same pero con las posiciones

    public Customer player; // ni puta idea que es esto, creo que lo ha hecho Qihang

    private void Awake()
    {
        // Si ya hay una instancia y no es la actual, destruir este objeto
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameManager = this; // Establece la instancia del GameManager
            DontDestroyOnLoad(this.gameObject);
            // No destruir este objeto al cargar una nueva escena
            // Inicializa el stack
        }
    }   
    // cambias las escenas
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    // si el jugador a completado el juego
    public bool alltrue()
    {
        if (respuesta1 && respuesta2 && respuesta3 && respuesta4 && respuesta5 && respuesta6 && respuesta7 && respuesta8)
        {
            return true;
        }
        else { return false; }  
    }

    public void setImagen(int index)
    {
        imagen_completa = index;
    }

    public void setCuadricula(int cuadricula)
    {
        imagen_contraste = cuadricula;
    }

    public int getImagen() { return imagen_completa; } // para poder agarrar la imagen, se que no es necesario pero vengo de java y tengo la mania y lo he usado en mucho codigo asi que usemos esto xd
    public int getImagen_imagen_quadricula() { return imagen_contraste; }

    // tiene pinta de ser de la base de datos
    public void SetPlayerData(Customer inputsData)
    {
        this.player = inputsData;
    }
}
