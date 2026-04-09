using UnityEngine;

public class MovimientoNiñoPelado : MonoBehaviour
{
    [SerializeField] float velocidadMov;
    //[SerializeField] bool caminando;
    [SerializeField] Animator animador;

    [SerializeField] bool caminarDespacio = false;

    Vector2 ultimaDireccion = Vector2.down;

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        caminarDespacio = Input.GetKey(KeyCode.LeftShift) ? true : false;

        if (movX != 0 || movY != 0)
        {
            animador.SetBool("caminando", true);
            Vector2 movimientoObjetivo = new Vector2(movX, movY);
            Vector2 direccion = movimientoObjetivo.normalized;
            //Debug.Log("Movimiento objetivo: " + movimientoObjetivo.normalized.magnitude);

            if (!caminarDespacio)
            {
                transform.Translate(direccion * velocidadMov * Time.deltaTime);
            }
            else
            {
                transform.Translate(direccion * velocidadMov * 0.5f * Time.deltaTime);
            }
        }
        else
        {
            animador.SetBool("caminando", false);
        }

        animador.SetFloat("dirX", ultimaDireccion.x);
        animador.SetFloat("dirY", ultimaDireccion.y);
    }
}
