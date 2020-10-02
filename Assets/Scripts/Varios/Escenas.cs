﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void ReiniciarEscena()
    {
        CargarEscena(SceneManager.GetActiveScene().name);
    }

    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
