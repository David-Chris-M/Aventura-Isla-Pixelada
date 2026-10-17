using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] private int valorMoneda = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            GameManager.Instancia.SumarMoneda(valorMoneda);

            Destroy(gameObject);
        }
    }
}