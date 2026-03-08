using UnityEngine;

public class EventosBasicos : MonoBehaviour
{
    [SerializeField] private AudioSource parlantito;

    private void Start()
    {
        parlantito = GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        parlantito.Play();
    }
}
