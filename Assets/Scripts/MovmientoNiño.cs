using UnityEngine;

public class MovmientoNiño : MonoBehaviour
{
    [SerializeField] float velocidadMov;
    //[SerializeField] bool caminando;
    [SerializeField] Animator animador;

    Vector2 ultimaDireccion = Vector2.down;

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        if (movX != 0 || movY != 0)
        {
            animador.SetBool("caminando", true);
            Vector2 movimientoObjetivo = new Vector2(movX, movY);
            Vector2 direccion = movimientoObjetivo.normalized;
            Debug.Log("Movimiento objetivo: " + movimientoObjetivo.normalized.magnitude);
            transform.Translate(direccion * velocidadMov * Time.deltaTime);

            ultimaDireccion = direccion;
        }
        else
        {
            animador.SetBool("caminando", false);
        }

        animador.SetFloat("dirX", ultimaDireccion.x);
        animador.SetFloat("dirY", ultimaDireccion.y);
    }
}
