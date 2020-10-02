using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idiomas : MonoBehaviour
{

    public void SeleccionarIdioma(int cual)
    {
        PlayerPrefs.SetInt("idioma", cual);
    }
}
