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

    public Animator animControl;

    void IniciarCombate()
    {
        batallaActiva = this;
        battleStart.Invoke();
        TokenCreator.singleton.Spawn();
    }

    private void Start()
    {
        GoblinCtrl.singleton.cuentaGoblins++;
        pivot.parent = null;
    }

    private void Awake()
    {
        this.camControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && batallaActiva == null)
        {
            Debug.Log("entra");
            IniciarCombate();
            Vector3 direccionPersonaje = (other.transform.position - this.transform.position).normalized;
            Vector3 derecha = Vector3.Cross(transform.up, direccionPersonaje);
            transform.forward = Vector3.Cross(derecha, transform.up);
        }

    }

    public void TerminarCombate()
    {
        batallaActiva = null;
        // Provisional, configurar con la escena de Cristian
        this.camControl.CambiarModo(true);
        Destroy(this);
    }
}
