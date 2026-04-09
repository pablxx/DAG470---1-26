using System;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    [SerializeField] LayerMask capaPersonaje;
    [SerializeField] Transform posGlobo;
    [SerializeField] float radioGlobo = 0.5f;

    [SerializeField] int saludActual;
    [SerializeField] Enemigo enemigo;

    [SerializeField] GameObject globo;
    [SerializeField] GameObject paracaidas;


    private void Start()
    {
        enemigo = GetComponent<Enemigo>();
    }
    private void FixedUpdate()
    {
        if (enemigo.GetEstadoEnemigo() == EstadoEnemigo.Cayendo)
            return;

        DetectarColisionGlobo();
    }

    private void DetectarColisionGlobo()
    {
        Debug.Log("Detectando colisión con el jugador...");
        Collider2D colision = Physics2D.OverlapCircle(posGlobo.position, radioGlobo, capaPersonaje);
        if (colision != null && colision.CompareTag("Player"))
        {
            Debug.Log("Colisión detectada con el jugador. El enemigo ha sido derrotado.");
            AplicarDano();
        }
    }

    private void AplicarDano()
    {
        //Emitir sonido de daño
        saludActual -= 1;
        if (saludActual == 0)
        {
            Destroy(gameObject);
        }
        else if(saludActual == 1)
        {
            //El enemigo aun esta vivo, pero se le ha aplicado daño, por lo que se actualiza su estado a cayendo
            enemigo.ActualizarEstadoEnemigo(EstadoEnemigo.Cayendo);
            globo.SetActive(false);
            paracaidas.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {  
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(posGlobo.position, radioGlobo);
    }

    public void CargarSalud(int saludEnemigo)
    {
        saludActual = saludEnemigo;
    }
}
