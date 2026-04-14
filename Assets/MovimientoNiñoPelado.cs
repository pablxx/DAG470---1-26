using UnityEngine;

public class MovimientoNiñoPelado : MonoBehaviour
{
    [SerializeField] float velocidadMov;
    [SerializeField] Animator animador;

    Vector2 ultimaDireccion = Vector2.down;

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        bool caminarDespacio = Input.GetKey(KeyCode.LeftShift);

        if (movX != 0 || movY != 0)
        {
            Vector2 movimientoObjetivo = new Vector2(movX, movY);
            Vector2 direccion = movimientoObjetivo.normalized;

            // Guardar la última dirección presionada
            ultimaDireccion = direccion;

            // Mover el personaje
            if (!caminarDespacio)
            {
                transform.Translate(direccion * velocidadMov * Time.deltaTime);
            }
            else
            {
                transform.Translate(direccion * velocidadMov * 0.5f * Time.deltaTime);
            }

            animador.SetBool("caminando", true);
        }
        else
        {
            animador.SetBool("caminando", false);
        }

        // Actualizar la dirección en el animator
        animador.SetFloat("dirX", ultimaDireccion.x);
        animador.SetFloat("dirY", ultimaDireccion.y);
    }
}
