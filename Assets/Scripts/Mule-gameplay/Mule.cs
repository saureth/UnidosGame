using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mule : MonoBehaviour
{
    public UnityEvent foundMule;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foundMule.Invoke();
        }
    }
}
