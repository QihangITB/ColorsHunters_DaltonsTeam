using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; // declaracion statica
    private int imagen_contraste; // tipo de contraste
    private int? imagen_completa; // id de imagen que se esta utilizando
    public bool respuesta1 { get; set; } = false; 
    public bool respuesta2 { get; set; } = false;
    public bool respuesta3 { get; set; } = false;
    public bool respuesta4 { get; set; } = false;
    public bool respuesta5 { get; set; } = false; // booleans de las respuestas para saber si ha acertado el jugador
    public bool respuesta6 { get; set; } = false;
    public bool respuesta7 { get; set; } = false;
    public bool respuesta8 { get; set; } = false;

    public int cont1 { get; set; } = 0;
    public int cont2 { get; set; } = 0;
    public int cont3 { get; set; } = 0;
    public int cont4 { get; set; } = 0; // contadores para saber hasta que grado de contraste a subido
    public int cont5 { get; set; } = 0;
    public int cont6 { get; set; } = 0;
    public int cont7 { get; set; } = 0;
    public int cont8 { get; set; } = 0;

    public List<string> carrete = new List<string>(); // para no pderder el carrete con los cambios de escena

    public List<int> posiciones = new List<int>(); // same pero con las posiciones

    public Customer player; // variable donde guarda los datos del jugador

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
    public bool AllTrue()
    {
        if (respuesta1 && respuesta2 && respuesta3 && respuesta4 && respuesta5 && respuesta6 && respuesta7 && respuesta8)
        {
            return true;
        }
        else { return false; }  
    }

    public void SetImagen(int index)
    {
        imagen_completa = index;
    }

    public void SetCuadricula(int cuadricula)
    {
        imagen_contraste = cuadricula;
    }

    public int GetImagen() 
    {
        return imagen_completa == null ? -1 : (int)imagen_completa;
    } // para poder agarrar la imagen, se que no es necesario pero vengo de java y tengo la mania y lo he usado en mucho codigo asi que usemos esto xd
    public int GetImagenCuadricula() { return imagen_contraste; }


    // Assigna los datos del cliente a la instancia del GameManager
    public void SetPlayerData(Customer inputsData)
    {
        this.player = inputsData;
    }

    public void SendResultToDB()
    {
        DBConnection db = new DBConnection();

        string result = $"{CalcularResultados()}%";
        int customerDatabaseId = db.GetCustomerIdByDocumentId(player.Id); // Con el documento de identidad obtenemos el id de la base de datos

        db.InsertResult(customerDatabaseId, result);
    }

    private float CalcularResultados()
    {
        float resultado = 0;
        int[] listaContadores = { cont1, cont2, cont3, cont4, cont5, cont6, cont7, cont8 };

        for(int i = 0; i < listaContadores.Length; i++)
        {
            resultado = listaContadores[i] <= 5 ? resultado + listaContadores[i] * 2.5f : resultado + 12.5f;
        }

        return resultado;
    }

    public string MostrarResultado()
    {
        string resultado = "";

        if (CalcularResultados() <= 10f)
        {
            resultado = "Tiene una probabilidad nula de daltonismo";
        }
        else if (CalcularResultados() <= 40f)
        {
            resultado = "Tiene una probabilidad baja de daltonismo";
        }
        else if (CalcularResultados() <= 80f)
        {
            resultado = "Tiene una probabilidad intermedia de daltonismo";
        } else if (CalcularResultados() <= 100f)
        {
            resultado = "Tiene una probabilidad alta de daltonismo";
        }
        return resultado;
    }
}
