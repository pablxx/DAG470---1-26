using UnityEditor.Tilemaps;
using UnityEngine;

public class ControlCholita : MonoBehaviour
{
    public float fuerzaSalto = 5f;
    public float velMovimiento = 5f;
    public LayerMask capaPiso;
    public Transform posPies;

    public Rigidbody2D rb;
    public Animator anim;

    public float distanciaPiso = 0.25f;

    bool caminando = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");

        if (entradaX != 0) {
            caminando = true;
            Debug.Log(entradaX);
            rb.linearVelocityX = entradaX * velMovimiento;
        }
        else
        {
            caminando = false;
        }


        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        anim.SetBool("caminando", caminando);
        anim.SetFloat("velY", rb.linearVelocityY);

        if (entradaX > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (entradaX < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

    }

   
    private void FixedUpdate()
    {
        DetectarPiso();
    }

    private void DetectarPiso()
    {
        RaycastHit2D hit = Physics2D.Raycast(posPies.position, Vector2.down, distanciaPiso, capaPiso);
        if (hit.collider != null)
        {
            anim.SetBool("pisando", true);
            Debug.Log("Cholita está en el piso");
        }else
        {
            anim.SetBool("pisando", false);
            Debug.Log("Cholita está en el aire");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(posPies.position, posPies.position + Vector3.down * distanciaPiso);
        
    }
}
