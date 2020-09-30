using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMovement : MonoBehaviour
{
    public Transform character;
    public Transform target;
    public bool seguir = true;
    Vector3 offset;
    void Start()
    {
        //offset = transform.position - character.position;
    }

    void Update()
    {
        if (seguir)
        {
            transform.position = Vector3.Lerp(transform.position, character.position, 0.3f);
            Quaternion q = transform.rotation;
            transform.LookAt(character.parent.position+Vector3.up*1.7f);
            transform.rotation = Quaternion.Lerp(q, transform.rotation, 0.3f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position, .1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, .3f);
        }
    }

    public void CambiarModo(bool nModo)
    {
        seguir = nModo;
        if (!nModo)
        {
            target = BattleStart.batallaActiva.pivot;
        }
    }
}
