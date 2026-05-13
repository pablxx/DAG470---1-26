using UnityEngine;

public class PiedraParabolica : MonoBehaviour
{
    [SerializeField] float fuerzaInicial = 10f;
    [SerializeField] float angulo = 45f;
    [SerializeField] float gravedad = 9.81f;

    Vector3 velocidad;
    bool enMovimiento = false;

    void Start()
    {
        // Calcular la velocidad inicial basada en el ángulo y la fuerza
        float anguloRadianes = angulo * Mathf.Deg2Rad;
        velocidad = new Vector3(
            Mathf.Cos(anguloRadianes) * fuerzaInicial,
            Mathf.Sin(anguloRadianes) * fuerzaInicial,
            0f
        );

        enMovimiento = true;
    }

    void Update()
    {
        if (enMovimiento)
        {
            // Aplicar gravedad a la velocidad vertical
            velocidad.y -= gravedad * Time.deltaTime;

            // Mover la piedra según la velocidad
            transform.position += velocidad * Time.deltaTime;

            // Opcional: Detener si toca el suelo (ajusta -2f según tu nivel)
            if (transform.position.y <= -2f)
            {
                enMovimiento = false;
                // Opcional: Destruir o desactivar la piedra
                // Destroy(gameObject);
            }
        }
    }

    // Método público para lanzar la piedra con parámetros personalizados
    public void Lanzar(Vector3 direccion, float fuerza)
    {
        velocidad = direccion.normalized * fuerza;
        enMovimiento = true;
    }

    // Método para lanzar con ángulo específico
    public void LanzarConAngulo(float anguloGrados, float fuerza)
    {
        float anguloRadianes = anguloGrados * Mathf.Deg2Rad;
        velocidad = new Vector3(
            Mathf.Cos(anguloRadianes) * fuerza,
            Mathf.Sin(anguloRadianes) * fuerza,
            0f
        );
        enMovimiento = true;
    }
}
