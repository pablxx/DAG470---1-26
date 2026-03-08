using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D cuerpoPersonaje;
    [SerializeField] float fuerzaEmpuje = 3f;
    [SerializeField] float velocidadMovimiento = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            cuerpoPersonaje.AddForce(Vector2.up * fuerzaEmpuje, ForceMode2D.Impulse);
        }

        if (movimientoHorizontal != 0)
        {
            cuerpoPersonaje.position += new Vector2(movimientoHorizontal * velocidadMovimiento * Time.deltaTime,
                                                    0f);
        }
    }
}
