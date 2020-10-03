using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
  

    public LayerMask playerLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & playerLayer) != 0)
        {
            // cambiar escena
            SceneManager.LoadScene("Bruja-gameplay");
        }
    }
}
