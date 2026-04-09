using UnityEngine;

public class ControlMinero : MonoBehaviour
{
    [SerializeField] float velocidadMov = 5f;
    [SerializeField] Animator anim;

    [SerializeField] public bool atacando;

    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");

        if (entradaX != 0 && !atacando)
        {
            transform.Translate(Vector3.right * entradaX * Time.deltaTime * velocidadMov);
            anim.SetBool("caminando", true);
            Rotar(entradaX); 
        }
        else
        {
            anim.SetBool("caminando", false);
            Rotar(entradaX);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("atacar");
            atacando = true;
        }
    }

    void Rotar(float entradaX) 
    {
        if ((entradaX < 0 && transform.localScale.x > 0) || (entradaX > 0 && transform.localScale.x < 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 
                                                transform.localScale.y,
                                                transform.localScale.z);
        }
    }
}
