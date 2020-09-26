using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorJaimeControl : MonoBehaviour
{
    public Animator animator;
    public float velocidadMinimaCaminata;
    public float velocidadMaximaCaminata;

    public float velocidadActual;
    private Vector3 posAnterior;
    private float velocidadRemapeada;

    IEnumerator Start()
    {
        posAnterior = transform.position;
        StartCoroutine(Variador());
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            velocidadRemapeada = Mathf.Clamp(
                (velocidadActual - velocidadMinimaCaminata)/velocidadMaximaCaminata
                , 0f
                , 2f);
            animator.SetFloat("velocidad", velocidadRemapeada);

            velocidadActual = (posAnterior - transform.position).sqrMagnitude / 0.2f;
            posAnterior = transform.position;
        }
    }

    IEnumerator Variador()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        CambiarVariante();
        StartCoroutine(Variador());
    }
    public void Saltar()
    {
        animator.SetTrigger("saltar");
    }

    private void FixedUpdate()
    {
    }

    public void CambiarVariante()
    {
        animator.SetInteger("variante", Random.Range(0, 2));
    }
}
