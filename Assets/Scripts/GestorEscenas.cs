using UnityEngine;
using UnityEngine.SceneManagement; 

public class GestorEscenas : MonoBehaviour
{
    public void CambiarAEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}