using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementSimple : MonoBehaviour
{
    [Tooltip("Punto de referencia para los ejes X y Z")]
    public Transform referencePoint;
    public float speed = 10f;
    public float rotSpeed = 10f;
    [Range(0,1)]
    public float rotPressTolerance = 0.15f;

    Vector3 forward;
    Vector3 right;
    Vector3 forwardMovement;
    Vector3 rightMovement;
    Vector3 movement;
    Vector3 lookRotation;
    Vector3 axisMovement;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardMovement = new Vector3();
        rightMovement = new Vector3();
        
        forward = referencePoint.forward;
        right = referencePoint.right;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Movimiento
        forwardMovement = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime * forward;
        rightMovement = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime * right;
        axisMovement = forwardMovement + rightMovement;

        movement = transform.position;
        movement += forwardMovement + rightMovement;
        // Rotación
        lookRotation = movement - transform.position;
        if (Mathf.Abs(Input.GetAxis("Vertical")) > rotPressTolerance || Mathf.Abs(Input.GetAxis("Horizontal")) > rotPressTolerance)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookRotation), rotSpeed * Time.fixedDeltaTime);
        }
        // Asigna movimiento
        //transform.position = movement;
        rb.velocity = new Vector3(axisMovement.x, rb.velocity.y, axisMovement.z);
    }
}
