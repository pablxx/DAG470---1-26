using UnityEngine;
using TMPro;

public class ControlPuntaje : MonoBehaviour
{
    public static ControlPuntaje Instancia;
    [SerializeField] int puntajeTotal = 0;
    [SerializeField] TMP_Text textoPuntajeTotal;

    [SerializeField] int puntajeMaximo;
    [SerializeField] TMP_Text textoPuntajeMaximo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instancia = this;
        }
    }

    private void Start()
    {
        puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo", 0);
        textoPuntajeMaximo.text = "Puntaje Maximo: " + puntajeMaximo.ToString();
    }

    public void SumarPuntos(int puntos)
    {
        puntajeTotal += puntos;
        textoPuntajeTotal.text = puntajeTotal.ToString();
    }

    private void OnDestroy()
    {
        Debug.Log("Puntaje total: " + puntajeTotal);
        Debug.Log($"Puntaje Maximo: { puntajeMaximo }");

        if (puntajeTotal > puntajeMaximo)
        {
            Debug.Log("Guardando nuevo record");
            PlayerPrefs.SetInt("PuntajeMaximo", puntajeTotal);
            //Terminamos salvando el ultimo valor
            PlayerPrefs.Save();
        }
    }
}
