using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiadorEscenas : MonoBehaviour
{
    

    public void GoToScene(int sceneName)
    {
        Debug.Log($"Est� clicando el bot�n para cargar la escena: {sceneName}");

        // Validar si se ha proporcionado un nombre de escena
        if (sceneName != 0)
        {
            // Cambiar de escena usando el GameManager o directamente SceneManager
            GameManager.gameManager.ChangeScene(sceneName);
            Debug.Log("se ha cambiado de escena");
        }
        else
        {
            Debug.LogError("�No se ha proporcionado un nombre de escena v�lido!");
        }
    }

    // Funci�n para llamar a la funci�n Die() del Player
    public void SalirAplicacion()
    {
        // Mensaje de depuraci�n en la consola
        Debug.Log("Cerrando el juego...");

        // Si est� en el Editor, se detiene la ejecuci�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cerrar la aplicaci�n
#endif
    }
}
