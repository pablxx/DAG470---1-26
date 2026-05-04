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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        anim.SetFloat("velY", rb.linearVelocityY);
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
