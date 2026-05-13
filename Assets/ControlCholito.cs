using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ControlCholito : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    [SerializeField] float velocidad = 5f;
    [SerializeField] bool piedraCerca = false;

    [SerializeField] Transform detectorPiedras;
    [SerializeField] LayerMask capaPiedra;

    public GameObject piedraDetectada;
    public bool conPiedra;


    private void FixedUpdate()
    {
        if (conPiedra) return;
        
        RaycastHit2D hit = Physics2D.CircleCast(detectorPiedras.position, 0.05f, Vector2.zero, capaPiedra);
        if (hit) { 
            piedraCerca = true;
            piedraDetectada = hit.collider.gameObject;
        }
        else
        {
            piedraCerca = false;
            piedraDetectada = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");
         if (entradaX != 0) {
             anim.SetBool("caminando", true);
            rb.linearVelocityX = entradaX * velocidad;

        }
         else
         {
             anim.SetBool("caminando", false);
         }

        if (Input.GetKeyDown(KeyCode.E) && piedraCerca && !conPiedra)
        {
            anim.SetTrigger("levantar");
        }
        else if (Input.GetKeyDown(KeyCode.E) && conPiedra)
        {
            conPiedra = false;
            StartCoroutine(BajarManosSuavemente());
            piedraDetectada.GetComponent<PiedraParabolica>().enabled = true;
            piedraDetectada.transform.SetParent(null);
        }
    }

    public void LevantarManos()
    {
        conPiedra = true;
        StartCoroutine(RutinaLevantarManos());
    }

    IEnumerator RutinaLevantarManos()
    {
        yield return LevantarManosSuavemente();
        //ponerle el peso de 1, a la capa 1, para que se active la animacion de levantar las manos
        anim.SetLayerWeight(1, 1);
    }

    IEnumerator LevantarManosSuavemente()
    {
        while (anim.GetLayerWeight(1) < 1)
        {
            anim.SetLayerWeight(1, anim.GetLayerWeight(1) + Time.deltaTime * 3f);
            yield return null;
        }
    }


    IEnumerator BajarManosSuavemente()
    {
        while (anim.GetLayerWeight(1) > 0)
        {
            anim.SetLayerWeight(1, anim.GetLayerWeight(1) - Time.deltaTime * 3f);
            yield return null;
        }
    }
}
