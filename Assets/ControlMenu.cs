using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;

public class ControlMenu : MonoBehaviour
{
    public static ControlMenu Instancia;

    [SerializeField] private string escenaActual;

    [SerializeField] float duracionTransicion;
    [SerializeField] private Image imagenTransicion;
    [SerializeField] private GameObject panelTransicion;
    [SerializeField] private GameObject panelMenu;

    private void Awake() {
        if (Instancia != null) {
            Destroy(gameObject);
            
        } else {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Tambien llamados corutinas, son funciones que pueden pausar su ejecucion y reanudarse en el siguiente frame o despues de un tiempo determinado
    public IEnumerator TransicionEscena(string escenaSiguiente) {

        panelTransicion.SetActive(true);
        // //yield significa esperar
        while (imagenTransicion.color.a <= 1)
        {
            imagenTransicion.color = new Color(0,0,0, imagenTransicion.color.a + Time.deltaTime / duracionTransicion);
            yield return null;
        }

        //cuando la pantalla se termina de tapar se sale del while 
        yield return new WaitForSeconds(duracionTransicion);

        escenaActual = escenaSiguiente;
        SceneManager.LoadScene(escenaActual);

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(TransicionSalida());
    }

    public IEnumerator TransicionSalida() {
        while (imagenTransicion.color.a >= 0)
        {
            imagenTransicion.color = new Color(0,0,0, imagenTransicion.color.a - Time.deltaTime / duracionTransicion);
            yield return null;
        }
        panelTransicion.SetActive(false);
        panelMenu.SetActive(false);
    }

    public void CambiarEscena(string escenaSiguiente){   
        StartCoroutine(TransicionEscena(escenaSiguiente));
    }
}
