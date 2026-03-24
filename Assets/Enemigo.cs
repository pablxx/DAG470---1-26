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

    private void Start()
    {
        velocidadActual = infoEnemigo.velocidad;
        imagenEnemigo.color = infoEnemigo.color;
        StartCoroutine(InflarGlobo());
    }

    IEnumerator InflarGlobo()
    {
        yield return new WaitForSeconds(tiempoInflado);
        estadoEnemigo = EstadoEnemigo.Buscando;
    }

    void Update()
    {
        switch (estadoEnemigo)
        {
            case EstadoEnemigo.Buscando:
                transform.Translate(Vector3.left * velocidadActual * Time.deltaTime);
                break;
            case EstadoEnemigo.Inflando:
                //StartCoroutine(InflarGlobo());
                //estadoEnemigo = EstadoEnemigo.Cayendo;
                break;
            case EstadoEnemigo.Cayendo:
                //transform.Translate(Vector3.down * velocidadActual * Time.deltaTime);
                break;
        }
    }
}
