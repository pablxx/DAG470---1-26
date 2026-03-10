using System.Collections.Generic;
using UnityEngine;

public class ControlBurbujas : MonoBehaviour
{
    [SerializeField] List<Transform> posBurbujas;
    [SerializeField] float frecuenciaBurbujas = 2f;
    [SerializeField] float retrasoInicial = 1f;
    [SerializeField] GameObject prefabBurbuja;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IniciarBurbujas();
    }

    void IniciarBurbujas()
    {
        InvokeRepeating("GenerarBurbujas", retrasoInicial, frecuenciaBurbujas);
    }

    void GenerarBurbujas()
    {
        Instantiate(prefabBurbuja, posBurbujas[Random.Range(0, posBurbujas.Count)].position, Quaternion.identity);
    }

}
