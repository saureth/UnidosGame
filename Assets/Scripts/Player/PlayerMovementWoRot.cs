using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementWoRot : MonoBehaviour
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


    void Start()
    {
        forwardMovement = new Vector3();
        rightMovement = new Vector3();
        
        forward = referencePoint.forward;
        right = referencePoint.right;
    }

    void Update()
    {
        // Movimiento
        forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime * forward;
        rightMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime * right;
        movement = transform.position;
        movement += forwardMovement + rightMovement;
        // Rotación
        lookRotation = movement - transform.position;
        if (Mathf.Abs(Input.GetAxis("Vertical")) > rotPressTolerance || Mathf.Abs(Input.GetAxis("Horizontal")) > rotPressTolerance)
        { 
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookRotation), rotSpeed * Time.deltaTime);
        }
        // Asigna movimiento
        transform.position = movement;
        
    }
}
