using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedor : MonoBehaviour
{
    public Vector3 velocidad;
    public float tiempoVida= 8f;
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime);
    }
}
