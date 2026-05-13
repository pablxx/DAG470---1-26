using UnityEngine;

public class EventosCholito : MonoBehaviour
{
    public Transform posMano;
    public Vector2 offsetPiedra;

    public ControlCholito cholito;
   
    public void LevantarPiedra()
    {
        cholito.piedraDetectada.transform.SetParent(posMano);
        cholito.piedraDetectada.transform.position = posMano.position + (Vector3)offsetPiedra;
        cholito.LevantarManos();
        Debug.Log("Piedra levantada");
    }

    public void ArrojarPiedra()
    {
        cholito.piedraDetectada.transform.SetParent(null);
        //Rigidbody2D rbPiedra = cholito.piedraDetectada.GetComponent<Rigidbody2D>();
        //rbPiedra.AddForce(new Vector2(transform.localScale.x * 5f, 2f), ForceMode2D.Impulse);
        Debug.Log("Piedra arrojada");
    }
}
