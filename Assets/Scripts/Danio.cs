using UnityEngine;

public class Danio : MonoBehaviour
{
    [SerializeField] private float cantidadDeDano = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instancia.TomarDano(cantidadDeDano);
        }
    }
}