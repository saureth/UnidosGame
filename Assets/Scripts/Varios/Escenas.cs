using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public bool cargarEscenaConDelay;
    public string nombreEscena;
    public float delay;

    private void Start()
    {
        if (cargarEscenaConDelay)
        {
            CargarConDelay(nombreEscena);
        }
    }

    public void ReiniciarEscena()
    {
        CargarEscena(SceneManager.GetActiveScene().name);
    }

    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void CargarConDelay(string nomre)
    {
        StartCoroutine(CargaLenta(nomre));
    }

    IEnumerator CargaLenta(string nombre)
    {
        yield return new WaitForSeconds(delay);
        CargarEscena(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
