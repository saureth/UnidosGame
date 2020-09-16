using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{

    public float radio;
    public KeyCode activationKey;
    Collider[] upDownKeys;

    public LayerMask gameplayObjects;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    void Update()
    {
        if (Input.GetKeyDown(this.activationKey))
        {
            upDownKeys = Physics.OverlapSphere(transform.position, radio, gameplayObjects);
            if (upDownKeys.Length > 0)
            {
                this.keyDownCorrect();
            }
            else
            {
                this.keyDownWrong();
            }
        }
    }


    void keyDownCorrect()
    {
        for (int i = 0; i < upDownKeys.Length; i++)
        {
            Destroy(upDownKeys[i].gameObject);
        }
        print("¡Correcto!");
    }

    void keyDownWrong()
    {
        print("¡Mal!");
    }

}
