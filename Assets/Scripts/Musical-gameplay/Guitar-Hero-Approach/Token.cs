using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{

    float upDownSpeed;
    float lifeTime;
    float deathHour;

    // Start is called before the first frame update
    void Start()
    {
        this.upDownSpeed = TokenCreator.singleton.upDownSpeed;
        this.lifeTime = TokenCreator.singleton.lifeTime;
        deathHour = Time.time + lifeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * upDownSpeed * Time.fixedDeltaTime);
        if (Time.time > deathHour)
        {
            TokenCreator.singleton.Wrong();
            Destroy(this.gameObject);
        }
    }
}
