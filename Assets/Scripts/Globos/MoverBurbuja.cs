using UnityEngine;
using TMPro;

public class MoverBurbuja : MonoBehaviour
{
    [SerializeField] float velocidadMovimiento = 1f;
    [SerializeField] float frecuenciaMovimiento = 2f;
    [SerializeField] float amplitudMovimiento = 2f;

    [SerializeField] GameObject textoBurbuja;

    [SerializeField] SpriteRenderer spriteBurbuja;
    [SerializeField] Collider2D colliderBurbuja;

    [SerializeField] int puntajeBurbuja = 500;
    [SerializeField] TMP_Text textoPuntaje;

    [SerializeField] bool puedeMoverse = true;

    private void Update()
    {
        //Debug.Log("Tiempo delta " + Time.deltaTime);
        //Todas estas formas son equivalentes para mover el objeto hacia arriba a una velocidad constante
        //transform.position = new Vector3(transform.position.x, transform.position.y + velocidadMovimiento * Time.deltaTime, transform.position.z);
        //transform.position += Vector3.up * velocidadMovimiento * Time.deltaTime;
        //transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
       // Debug.Log(Mathf.Sin(3f * Time.time) * 4f);
       if (!puedeMoverse) return;


        float xBurbuja = Mathf.Sin(frecuenciaMovimiento * Time.time) * amplitudMovimiento;

        transform.Translate(new Vector2(xBurbuja, velocidadMovimiento)  * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colision con el jugador");
            //desactivamos el movimiento de la burbuja
            puedeMoverse = false;
            //activamos el texto de puntaje
            textoBurbuja.SetActive(true);

            //desactivamos el sprite y el collider de la burbuja
            spriteBurbuja.enabled = false;
            colliderBurbuja.enabled = false;

            //actualizamos el texto del puntaje
            textoPuntaje.text = puntajeBurbuja.ToString();

            Destroy(gameObject, 2f);
        }
        //Debug.Log("Colision con " + collision.gameObject.name);
    }
}
    