using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public static ControlJuego Instancia;
    [SerializeField] bool juegoPausado = false;

    [SerializeField] public Action OnGamePaused;

    [SerializeField] int cantidadEnemigos;

    [SerializeField] ControlUI controlUI;

    [SerializeField] List<Transform> puntosSpawn;

    [SerializeField] List<GameObject> prefabGlobos;

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
        InstanciarEnemigos();
    }

    void InstanciarEnemigos() {
        foreach (var puntoSpawn in puntosSpawn)
        {
            GameObject nuevoGlobo = prefabGlobos[UnityEngine.Random.Range(0, prefabGlobos.Count)];
            Instantiate(nuevoGlobo, puntoSpawn.transform.position, puntoSpawn.transform.rotation);
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

    public void RestarEnemigo()
    {

        cantidadEnemigos--;
        Debug.LogWarning("enemigos restantes : " + cantidadEnemigos);
        if(cantidadEnemigos == 0)
        {
            //En esta parte no necesariamente es GameOver, deberiamos pasar al nivel 2
            //Pero por ahora, para probar el GameOver, lo dejamos asi
            // Deberia ir, controlUI.MostrarNivelCompletado();
            //Transicionar a la escena del siguiente nivel
            GameOver();
        }
    }

    void GameOver()
    {
        controlUI.MostrarGameOver();
        Time.timeScale = 0f;
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
