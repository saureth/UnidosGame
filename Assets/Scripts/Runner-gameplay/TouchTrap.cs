using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TouchTrap : MonoBehaviour
{
    
    public LayerMask playerLayer;
    public PlayerRunnerBehaviour pl;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & playerLayer) != 0)
        {
            pl.TakeDamage(20f);
        }
    }
}
