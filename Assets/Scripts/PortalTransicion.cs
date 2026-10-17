using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class PortalTransicion : MonoBehaviour
{
    [Header("Configuración del Nivel")]
    [Tooltip("Escribe EXACTAMENTE el nombre de la siguiente escena (ej: Selva)")]
    [SerializeField] private string nombreSiguienteEscena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el que tocó el portal tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡El jugador entró al portal! Cargando nivel: " + nombreSiguienteEscena);

            // Aquí cargamos la siguiente escena
            SceneManager.LoadScene(nombreSiguienteEscena);
        }
    }
} 