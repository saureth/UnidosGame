using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensajes : MonoBehaviour
{
    public static Mensajes singleton;
    public Animator animator;
    public Text txtMensaje;
    public MSJ[] mensajes;

    public AnimatorMovementJaime jaime;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        jaime = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimatorMovementJaime>();
    }

    public static Mensajes GetSingleton()
    {
        if (singleton != null)
        {
            return singleton;
        }
        Mensajes m;
        m = GameObject.Find("cnvMensajes").GetComponent<Mensajes>();
        return m;
    }
    
    public void MostrarMensaje(int cual)
    {
        txtMensaje.text = mensajes[cual].GetTexto();
        animator.SetBool("mensaje", true);
        Cursor.lockState = CursorLockMode.None;
        jaime.Bloquear();
    }
    public void OcultarMensaje()
    {
        animator.SetBool("mensaje", false);
        Cursor.lockState = CursorLockMode.Locked;
        jaime.Desbloquear();
    }
}

[System.Serializable]
public class MSJ
{
    public string español;
    public string ingles;

    public string GetTexto()
    {
        int i = PlayerPrefs.GetInt("idioma",0);
        if (i==0)
        {
            return español;
        }
        return ingles;
    }
}