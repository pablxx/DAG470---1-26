using UnityEngine;

public class AnimacionBasica : MonoBehaviour
{
    [SerializeField] private Animator animador;

    [SerializeField] private enum Estado { Caminando, Daño, Muerto };

    [SerializeField] private Estado estadoActual;

    void Update()
    {
        if (estadoActual == Estado.Muerto)
        {
            //se corta el update para que no se puedan hacer más acciones
            return;
        }

        float movX = Input.GetAxis("Horizontal");

        if (movX != 0)
        {
            transform.position = new Vector2(transform.position.x + movX * Time.deltaTime * 2f, transform.position.y);
            animador.SetBool("caminando", true);
        }
        else
        {
            animador.SetBool("caminando", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animador.SetTrigger("daño");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animador.SetTrigger("muerto");
            estadoActual = Estado.Muerto;
        }
    }
}
