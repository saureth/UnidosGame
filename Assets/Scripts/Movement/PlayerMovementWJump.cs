using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementWJump : MonoBehaviour
{
    [Tooltip("Punto de referencia para los ejes X y Z")]
    public Transform referencePoint;
    public float speed = 10f;
    public float rotSpeed = 10f;
   // [Range(0, 1)]
    public float rotPressTolerance = 0.15f;
    public LayerMask hitLayer;
    public float rayDistance = 1f;
    public float jumpForce = 10f;
    public AnimatorJaimeControl animControl;

    Vector3 forward;
    Vector3 right;
    Vector3 forwardMovement;
    Vector3 rightMovement;
    Vector3 movement;
    Vector3 lookRotation;
    Vector3 axisMovement;
    Rigidbody rb;
    float tiempoSalto;
    RaycastHit hit;

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
        // Salto
        if (Input.GetButtonDown("Jump") && Time.time > tiempoSalto && Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance, hitLayer))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animControl.Saltar();
            tiempoSalto = Time.time + 1;
        }
    }

    void FixedUpdate()
    {
        // Movimiento
        forwardMovement = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime * forward;
        rightMovement = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime * right;
        axisMovement = forwardMovement + rightMovement;
        

        // Rotación
        if (axisMovement.sqrMagnitude > rotPressTolerance) 
        {
            lookRotation = axisMovement;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookRotation), rotSpeed * Time.fixedDeltaTime);

        // Asigna movimiento
        rb.velocity = new Vector3(axisMovement.x, rb.velocity.y, axisMovement.z);

 
    }

}
