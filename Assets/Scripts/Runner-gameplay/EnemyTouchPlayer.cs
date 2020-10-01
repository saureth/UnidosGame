using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchPlayer : MonoBehaviour
{
    public PlayerRunnerBehaviour pl;
    public LayerMask playerLayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & playerLayer) != 0)
        {
            pl.TakeDamage();
            // animar madremonte para hacer daño
        }
    }


}
