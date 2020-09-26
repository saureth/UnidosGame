using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleStart : MonoBehaviour
{
    public UnityEvent battleStart;
    public Transform pivot;
    public static BattleStart batallaActiva;

    public CameraMovement camControl = null;

    void IniciarCombate()
    {
        batallaActiva = this;
        battleStart.Invoke();
        TokenCreator.singleton.Spawn(batallaActiva);
    }

    private void Awake()
    {
        this.camControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entra");
            IniciarCombate();
        }
    }

    public void TerminarCombate()
    {
        batallaActiva = null;
        // Provisional, configurar con la escena de Cristian
        this.camControl.CambiarModo(true);
        Destroy(this.gameObject);
    }
}
