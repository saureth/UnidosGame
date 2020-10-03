using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;
    Rigidbody rb;
    public bool isMoving = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = new Vector3(speed * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
        }
    }
}
