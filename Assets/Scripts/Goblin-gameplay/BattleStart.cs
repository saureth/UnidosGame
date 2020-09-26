using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleStart : MonoBehaviour
{
    public UnityEvent battleStart;
    public Transform pivot;
    public static BattleStart batallaActiva;

    public GameObject musicController;

    void IniciarCombate()
    {
        batallaActiva = this;
        battleStart.Invoke();
        TokenCreator.singleton.Spawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entra");
            IniciarCombate();
        }
    }
}
