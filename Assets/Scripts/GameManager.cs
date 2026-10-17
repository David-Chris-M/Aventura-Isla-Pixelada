using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    [Header("Estadísticas de Vida")]
    public float vidaMaxima = 100f;
    public float vidaActual;

    [Header("Estadísticas de Monedas")]
    public int monedasTotales = 0;

    [Header("Interfaz UI")]
    [SerializeField] private TextMeshProUGUI textoContador;
    [SerializeField] private Image barraDeVida;
    [SerializeField] private GameObject panelGameOver;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            vidaActual = vidaMaxima;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;

    }

    public void ConectarInterfaz(TextMeshProUGUI nuevoTexto, Image nuevaBarra, GameObject nuevoPanel)
    {
        textoContador = nuevoTexto;
        barraDeVida = nuevaBarra;
        panelGameOver = nuevoPanel;

        if (textoContador != null) textoContador.text = monedasTotales.ToString();
        ActualizarBarraVisual();
        if (panelGameOver != null) panelGameOver.SetActive(false);
    }

    public void SumarMoneda(int cantidad)
    {
        monedasTotales += cantidad;
        if (textoContador != null)
        {
            textoContador.text = monedasTotales.ToString();
        }
    }

    public void TomarDano(float cantidadDano)
    {
        vidaActual -= cantidadDano;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        ActualizarBarraVisual();

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void ActualizarBarraVisual()
    {
        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = vidaActual / vidaMaxima;
        }
    }

    private void Morir()
    {
        Debug.Log("¡Game Over! El jugador ha muerto.");
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    public void ReiniciarEstadisticas()
    {
        vidaActual = vidaMaxima;
        monedasTotales = 0;
    }
}