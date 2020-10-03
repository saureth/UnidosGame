using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gema : MonoBehaviour
{
    public Vector3 velocidad;
    public Animator madreMonte;


    void Update()
    {
        transform.Rotate(velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            madreMonte.SetTrigger("activar");
            Invoke("DesactivarGema",21);
        }
    }

    void DesactivarGema()
    {
        SceneManager.LoadScene("RunnerScene");
        gameObject.SetActive(false);
    }
}
