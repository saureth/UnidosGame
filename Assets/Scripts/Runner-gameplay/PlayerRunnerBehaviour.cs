using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerBehaviour : MonoBehaviour
{

    public float health = 100f;
    public Health h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float damage)
    {
        Debug.Log("Take damage");
        health -= damage;
        h.DropHealth(damage);
        if (health < 0)
        {
            health = 0;
            // game over
            
        }
    }
}
