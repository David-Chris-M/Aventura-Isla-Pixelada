using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [Header("Configuración de Seguimiento")]
    [SerializeField] private Transform jugador;

    [Tooltip("Suavizado al correr (X) y al saltar (Y)")]
    [SerializeField] private float suavizadoHorizontal = 5f;
    [SerializeField] private float suavizadoVertical = 3f;

    [Tooltip("Distancia que la cámara se adelanta hacia donde miras")]
    [SerializeField] private float adelantoMira = 2f;

    [SerializeField] private Vector3 offset = new Vector3(0, 2f, -10f);

    [Header("Límites del Mapa (Confiner)")]
    [SerializeField] private bool usarLimites = true;
    [SerializeField] private Vector2 limiteMinimo;
    [SerializeField] private Vector2 limiteMaximo;

    private void LateUpdate()
    {
        if (jugador != null)
        {
            // 1. Detectamos hacia dónde mira el jugador usando su escala (1 o -1)
            float direccionX = Mathf.Sign(jugador.localScale.x);

            // 2. Calculamos la posición base + el offset + el adelanto de la mira
            Vector3 posicionObjetivo = jugador.position + offset;
            posicionObjetivo.x += direccionX * adelantoMira;

            // 3. Confinamos la cámara si está activado
            if (usarLimites)
            {
                posicionObjetivo.x = Mathf.Clamp(posicionObjetivo.x, limiteMinimo.x, limiteMaximo.x);
                posicionObjetivo.y = Mathf.Clamp(posicionObjetivo.y, limiteMinimo.y, limiteMaximo.y);
            }

            // 4. Suavizado independiente: Horizontal (avanzar/retroceder) y Vertical (saltos)
            float posX = Mathf.Lerp(transform.position.x, posicionObjetivo.x, suavizadoHorizontal * Time.deltaTime);
            float posY = Mathf.Lerp(transform.position.y, posicionObjetivo.y, suavizadoVertical * Time.deltaTime);

            // 5. Aplicamos el movimiento final manteniendo la Z en -10
            transform.position = new Vector3(posX, posY, offset.z);
        }
    }

    private void OnDrawGizmos()
    {
        if (usarLimites)
        {
            Gizmos.color = Color.red;
            Vector2 centro = (limiteMinimo + limiteMaximo) / 2f;
            Vector2 tamano = limiteMaximo - limiteMinimo;
            Gizmos.DrawWireCube(centro, tamano);
        }
    }
}