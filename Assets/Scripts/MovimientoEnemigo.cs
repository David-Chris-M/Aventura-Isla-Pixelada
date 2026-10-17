using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private bool moviendoDerecha = true;

    [Header("Detección de Borde")]
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia = 1f;
    [Tooltip("Asegúrate de marcar aquí la capa de tu piso")]
    [SerializeField] private LayerMask queEsSuelo;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia, queEsSuelo);

        rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

        if (informacionSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        if (controladorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
        }
    }
}