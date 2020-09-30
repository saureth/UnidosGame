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
    public GameObject guitarraEspalda;
    public GameObject guitarraFrente;
    Vector3 posNueva;
    IEnumerator Start()
    {
        posAnterior = transform.position;
        StartCoroutine(Variador());
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            posNueva = transform.position;
            posNueva.y = 0;
            velocidadActual = (posAnterior - posNueva).sqrMagnitude / 0.1f;
            velocidadRemapeada = Mathf.Clamp(velocidadActual , 0f, 1f);
            animator.SetFloat("velocidad", velocidadRemapeada);
            posAnterior = transform.position;
            posAnterior.y = 0;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    public void Guitarrear(bool guitarrear)
    {
        animator.SetBool("guitarreando", guitarrear);
        guitarraEspalda.SetActive(!guitarrear);
        guitarraFrente.SetActive(guitarrear);
        if (guitarrear)
        {
            Vector3 dirDuende = (BattleStart.batallaActiva.gameObject.transform.position - transform.position).normalized;
            Vector3 derecha = Vector3.Cross(transform.up, dirDuende);
            transform.forward = Vector3.Cross(derecha, transform.up);
        }
    }

    public void CambiarVariante()
    {
        animator.SetInteger("variante", Random.Range(0, 2));
    }
}
