using System;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public static ControlJuego Instancia;
    [SerializeField] bool juegoPausado = false;

    [SerializeField] public Action OnGamePaused;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausarJuego();
        }
    }

    public void PausarJuego()
    {
        OnGamePaused?.Invoke();

        if (!juegoPausado)
        {
            Time.timeScale = 0f;
            juegoPausado = true;
        }
        else
        {
            Time.timeScale = 1f;
            juegoPausado = false;
        }

    }
}
