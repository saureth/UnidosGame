using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{

    public float upDownSpeed;
    public float lifeTime;
    float deathHour;

    // Start is called before the first frame update
    void Start()
    {
        deathHour = Time.time + lifeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * upDownSpeed * Time.fixedDeltaTime);
        if (Time.time > deathHour)
        {
            print("¡Incorrecto!");
            Destroy(this.gameObject);
        }
    }
}
