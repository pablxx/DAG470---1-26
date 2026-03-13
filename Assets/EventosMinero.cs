using UnityEngine;

public class EventosMinero : MonoBehaviour
{
    [SerializeField] ControlMinero minero;
    [SerializeField] GameObject pico;

    public void Atacar()
    {
        pico.SetActive(true);
        //anim.SetTrigger("atacar");
    }

    public void TerminarAtaque()
    {
        minero.atacando = false;
        pico.SetActive(false);
        // Aquí puedes agregar lógica para finalizar el ataque, como restablecer variables o cambiar estados.
    }
}
