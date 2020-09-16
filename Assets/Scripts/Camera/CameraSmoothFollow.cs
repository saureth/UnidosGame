using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{

    public Transform toFollow;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    Vector3 refVel;
    Vector3 targetPosition;

    void Start()
    {
        
    }

    void Update()
    {
        targetPosition = new Vector3(toFollow.position.x, transform.position.y, toFollow.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition + offset, ref refVel, smoothTime);
    }
}
