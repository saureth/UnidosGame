using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarBehaviour : MonoBehaviour
{
    public Health brujaRef = null;
    public float cooldown = 60f;
    public bool hit = false;
    public float hitDamage = 1f;

    private void Awake()
    {
        this.brujaRef = GameObject.FindGameObjectWithTag("Bruja").GetComponent<Health>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hit && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Le pegó con la gema");
            hit = true;
            this.brujaRef.DropHealth(hitDamage);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        hit = false;
    }

}
