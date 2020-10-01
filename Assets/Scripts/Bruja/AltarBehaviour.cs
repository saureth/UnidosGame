using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarBehaviour : MonoBehaviour
{
    public Health brujaRef = null;
    public float cooldown = 60f;
    public bool hit = false;
    public float hitDamage = 1f;
    public AnimatorMovementJaime jaime;

    private void Awake()
    {
        this.brujaRef = GameObject.FindGameObjectWithTag("Bruja").GetComponent<Health>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hit && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Le pegó con la gema");
            hit = true;
            this.brujaRef.DropHealth(hitDamage);
            jaime.Golpear();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        //Debug.Log("Entró en espera el altar");
        yield return new WaitForSeconds(cooldown);
        hit = false;
        //Debug.Log("Salió de espera el altar");
    }

}
