using System.Collections;
using UnityEngine;

public enum EstadoEnemigo
{
    Buscando,
    Inflando,
    Cayendo,
    Muerto
}

public enum TipoEnemigo
{
    Facil,
    Normal,
    Dificil
}

[System.Serializable]
public class InformacionEnemigo
{
    public TipoEnemigo tipo;
    public float velocidad;
    public Color color;
    
}

public class Enemigo : MonoBehaviour
{
    [SerializeField] float velocidadActual;
    [SerializeField] float tiempoInflado;
    [SerializeField] int cantidadHits;

    [SerializeField] InformacionEnemigo infoEnemigo;
    //el estado actual de este enemigo
    [SerializeField] EstadoEnemigo estadoEnemigo;

    [SerializeField] SpriteRenderer imagenEnemigo;

    [SerializeField] Transform posPlayer;
    [SerializeField] Rigidbody2D rbEnemigo;

    [SerializeField] SaludEnemigo saludEnemigo;

    private void Start()
    {
        velocidadActual = infoEnemigo.velocidad;
        imagenEnemigo.color = infoEnemigo.color;
        StartCoroutine(InflarGlobo());

        rbEnemigo = GetComponent<Rigidbody2D>();

        saludEnemigo = GetComponent<SaludEnemigo>();
        saludEnemigo.CargarSalud(cantidadHits);
    }

    public void ActualizarEstadoEnemigo(EstadoEnemigo nuevoEstado)
    {
        estadoEnemigo = nuevoEstado;
    }

    public EstadoEnemigo GetEstadoEnemigo()
    {
        return estadoEnemigo;
    }

    IEnumerator InflarGlobo()
    {
        yield return new WaitForSeconds(tiempoInflado);
        estadoEnemigo = EstadoEnemigo.Buscando;
        saludEnemigo.CargarSalud(cantidadHits + 1);
    }

    void Update()
    {
        switch (estadoEnemigo)
        {
            case EstadoEnemigo.Buscando:
                //
                MoverHaciaPlayer();
                break;
            //case EstadoEnemigo.Inflando:
            //    StartCoroutine(InflarGlobo());
                //estadoEnemigo = EstadoEnemigo.Cayendo;
                //break;
            case EstadoEnemigo.Cayendo:
                rbEnemigo.gravityScale = 2f; // Enable gravity to make the enemy fall naturally.
                //transform.Translate(Vector3.down * velocidadActual * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (estadoEnemigo == EstadoEnemigo.Buscando)
            ElevarEnemigo();
    }

    void ElevarEnemigo()
    {
        // Apply an upward-only impulse so the enemy behaves like it's hanging from a balloon.
        // Only apply when the player is above the enemy (positive deltaY).
        float deltaY = posPlayer.position.y - rbEnemigo.position.y;

        if (deltaY <= 0f) return; // only push upward

        // desired vertical velocity proportional to vertical distance and velocidadActual
        float desiredVelY = deltaY * velocidadActual * 0.5f;

        // convert needed velocity change into impulse (impulse = mass * deltaV)
        float impulseY = (desiredVelY - rbEnemigo.linearVelocityY) * rbEnemigo.mass;

        // ensure we only apply upward impulses
        if (impulseY > 0f)
        {
            rbEnemigo.AddForce(new Vector2(0f, impulseY), ForceMode2D.Impulse);
        }
    }

    void MoverHaciaPlayer()
    {
        Vector2 distancia = posPlayer.position - transform.position;
        //Debug.Log("Distancia es " + Mathf.Abs(distancia.x));

        if (Mathf.Abs(distancia.x) > 0.5f)
        {
            Vector2 direccion = distancia.normalized;
            transform.Translate(new Vector2(velocidadActual * Time.deltaTime * direccion.x, 0));
        }

        //float distancia = Vector2.Distance(posPlayer.position, transform.position);
    }
}
