using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [Tooltip("Arrastra aquí el Panel de Pausa desde la jerarquía")]
    [SerializeField] private GameObject panelPausa;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelPausa.activeSelf)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Menu");

        if (GameManager.Instancia != null)
        {
            GameManager.Instancia.ReiniciarEstadisticas();
        }
    }

}