using UnityEngine;

public class CicloDeVida : MonoBehaviour
{
   
    private void Awake()
    {
        Debug.Log("Estoy en Awake");
    }

    private void OnEnable()
    {
        Debug.Log("Estoy en OnEnable");
    }


    //si no dice nada, antes de void, es privado
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void es un metodo que no devuelve resultados
    void Start()
    {
        Debug.Log("Estoy en Start");
    }
    private void FixedUpdate()
    {
        Debug.Log("Estoy en FixedUpdate");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Estoy en Update");
    }

    private void LateUpdate()
    {
        Debug.Log("Estoy en LateUpdate");
    }

    private void OnDisable()
    {
        Debug.Log("Estoy en OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("Estoy en OnDestroy");
    }
}
