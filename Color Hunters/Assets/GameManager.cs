using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private int imagenCuadricula;
    private int imagen;
    public bool respuesta1 { get; set; } = false;
    public bool respuesta2 { get; set; } = false;
    public bool respuesta3 { get; set; } = false;
    public bool respuesta4 { get; set; } = false;
    public bool respuesta5 { get; set; } = false;
    public bool respuesta6 { get; set; } = false;
    public bool respuesta7 { get; set; } = false;
    public bool respuesta8 { get; set; } = false;

    public int cont1 { get; set; } = 1;
    public int cont2 { get; set; } = 1;
    public int cont3 { get; set; } = 1;
    public int cont4 { get; set; } = 1;
    public int cont5 { get; set; } = 1;
    public int cont6 { get; set; } = 1;
    public int cont7 { get; set; } = 1;
    public int cont8 { get; set; } = 1;

    public List<string> carrete = new List<string>();

    public List<int> posiciones = new List<int>();

    public Customer player;


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

    public void SetImagen(int index)
    {
        imagen = index;
    }

    public void SetCuadricula(int cuadricula)
    {
        imagenCuadricula = cuadricula;
    }

    public int GetImagen() { return imagen; }

    public int GetImagenCuadricula() { return imagenCuadricula; }

    public void SetPlayerData(Customer inputsData)
    {
        this.player = inputsData;
    }

}
