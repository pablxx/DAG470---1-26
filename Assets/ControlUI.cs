using UnityEngine;

public class ControlUI : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    private void Start()
    {
        ControlJuego.Instancia.OnGamePaused += MostrarMenuPausa;
    }
    private void OnDisable()
    {
        ControlJuego.Instancia.OnGamePaused -= MostrarMenuPausa;
    }


    void MostrarMenuPausa()
    {
        if (menuPausa.activeInHierarchy)
        {
            menuPausa.SetActive(false);
        }
        else
        {
            menuPausa.SetActive(true);
        }
    }
}
