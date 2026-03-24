using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    public static ControlMenu Instancia;

    [SerializeField] private string escenaActual;

    [SerializeField] float duracionTransicion;
    [SerializeField] private Image imagenTransicion;
    [SerializeField] private GameObject panelTransicion;

    private void Awake() {
        if (Instancia != null) {
            Destroy(gameObject);
            
        } else {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public IEnumerator TransicionEscena(string escenaSiguiente) {

        panelTransicion.SetActive(true);
        // //yield significa esperar
        while (imagenTransicion.color.a <= 1)
        {
            imagenTransicion.color = new Color(0,0,0, imagenTransicion.color.a + Time.deltaTime *.0001f);    
        }

        yield return new WaitForSeconds(duracionTransicion);

        escenaActual = escenaSiguiente;
        SceneManager.LoadScene(escenaActual);
    }

    public void CambiarEscena(string escenaSiguiente){   
        StartCoroutine(TransicionEscena(escenaSiguiente));
    }
}
