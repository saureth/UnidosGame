using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour : MonoBehaviour
{
    public Health playerRef = null;

    private void Awake()
    {
        this.playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
}
