using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiadorEscenas : MonoBehaviour
{
    
    //funcion para cambiar de escena
    public void GoToScene(int sceneName)
    {
        Debug.Log($"Está clicando el botón para cargar la escena: {sceneName}");

        // Validar si se ha proporcionado un nombre de escena
        if (sceneName != 0)
        {
            // Cambiar de escena usando el GameManager o directamente SceneManager
            GameManager.gameManager.ChangeScene(sceneName);
            Debug.Log("se ha cambiado de escena");
        }
        else
        {
            Debug.LogError("¡No se ha proporcionado un nombre de escena válido!");
        }
    }

    // Función para cerra el juego y lo pongo en el mismo script para ahorrar archivos
    public void SalirAplicacion()
    {
        // Mensaje de depuración en la consola
        Debug.Log("Cerrando el juego...");

        // Si está en el Editor, se detiene la ejecución
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cerrar la aplicación
#endif
    }
}
