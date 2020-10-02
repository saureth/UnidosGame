using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensajero : MonoBehaviour
{
    public bool trigger = true;
    public bool collision;
    public bool autoIniciar;
    public bool autodestruir;


    public int mensaje;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        if (autoIniciar)
        {
            MostrarMensaje();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trigger && other.CompareTag("Player"))
        {
            MostrarMensaje();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.collision && collision.transform.CompareTag("Player"))
        {
            MostrarMensaje();
        }
    }

    public void MostrarMensaje()
    {
        Mensajes.singleton.MostrarMensaje(mensaje);
        if (autodestruir)
        {
            Destroy(gameObject);
        }
    }
}
