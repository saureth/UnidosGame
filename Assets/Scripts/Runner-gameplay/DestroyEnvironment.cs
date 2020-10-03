using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvironment : MonoBehaviour
{

    public LayerMask destructibleLayer;
    public GameObject dustExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & destructibleLayer) != 0)
        {
            DestroyObject(col.gameObject);
        }
    }

    void DestroyObject(GameObject g)
    {
        Instantiate(dustExplosion, g.transform.position, Quaternion.identity);
        Destroy(g, 0.15f);
    }
}
