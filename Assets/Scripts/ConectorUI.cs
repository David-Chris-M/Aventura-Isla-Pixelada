using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConectorUI : MonoBehaviour
{
    [Header("Elementos de la Interfaz a conectar")]
    public TextMeshProUGUI textoMonedasNivel;
    public Image barraVidaNivel;
    public GameObject panelGameOverNivel;

    private void Start()
    {
        if (GameManager.Instancia != null)
        {
            GameManager.Instancia.ConectarInterfaz(textoMonedasNivel, barraVidaNivel, panelGameOverNivel);
        }
    }
}