using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private int imagen_guadricula;
    private int imagen;
    public List<string> carrete = new List<string>();
    public List<int> imagenes = new List<int>();
    public List<int> posicion = new List<int>();



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

    public void setImagen(int index)
    {
        imagen = index;
    }

    public void setQuadricula(int guadricula)
    {
        imagen_guadricula = guadricula;
    }

    public int getImagen() { return imagen; }
    public int getImagen_imagen_guadricula() { return imagen_guadricula; }



}
