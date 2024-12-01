using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; // declaracion statica
    private int imagenCuadricula; // tipo de contraste
    private int imagen; // id de imagen que se esta utilizando
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
    public int cont4 { get; set; } = 1; // contadores para sacar conclusiones, segun como esta estructurado puede subir mas alla de 5 pero nunca rebjarse, asi que si supera mas de 5 es que el tio le ha costado mucho
    public int cont5 { get; set; } = 1;
    public int cont6 { get; set; } = 1;
    public int cont7 { get; set; } = 1;
    public int cont8 { get; set; } = 1;

    public List<string> carrete = new List<string>(); // para no pderder el carrete con los cambios de escena

    public List<int> posiciones = new List<int>(); // same pero con las posiciones

    public Customer player; // variable donde se guardara los datos del jugador

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
        }
    }

    // cambias las escenas
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Desuscribirse del evento cuando este objeto sea destruido o desactivado
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
       
    }

    // Esta función se llama cuando la escena ha terminado de cargarse
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

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

    public void SetImagen(int index)
    {
        imagen = index;
    }
    
    

    public void SetCuadricula(int cuadricula)
    {
        imagenCuadricula = cuadricula;
    }

    public int GetImagen() { return imagen; } // para poder agarrar la imagen, se que no es necesario pero vengo de java y tengo la mania y lo he usado en mucho codigo asi que usemos esto xd
    public int GetImagenCuadricula() { return imagenCuadricula; }

    // Assignar datos del jugador
    public void SetPlayerData(Customer inputsData)
    {
        this.player = inputsData;
    }

}
