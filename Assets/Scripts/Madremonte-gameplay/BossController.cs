using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BossController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Vector3 initialPosition;
    public Animator animBruja;
    public Estados estado;
    public float distanciaSeguir;
    public float distanciaAtacar;
    public GameObject rayos;
    public float delayTiempoRayos=7;
    public float tiempoRayos=5;
    public float tiempoAtacando = 2;
    public float tiempoEntreRayos = 20;
    private Health saludJaime;
    public float dañoGolpes = 1;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        saludJaime = target.GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        animBruja.SetBool("caminando", false);
        initialPosition = transform.position;
        StartCoroutine(ControlEstados());
        InvokeRepeating("LanzaRayos", tiempoEntreRayos, tiempoEntreRayos);
    }

    void LanzaRayos()
    {
        if (estado!= Estados.atacando)
        { 
            CambiarEstado(Estados.rayos);
        }

    }

    IEnumerator ControlEstados()
    {
        while (true)
        {
            switch (estado)
            {
                case Estados.idle:
                    animBruja.SetBool("caminando", false);
                    if (agent.hasPath)
                    {
                        agent.isStopped = true;
                    }

                    if ((transform.position - target.position).sqrMagnitude < distanciaAtacar.Cuadrado())
                    {
                        CambiarEstado(Estados.atacando);
                    }else if ((transform.position - target.position).sqrMagnitude < distanciaSeguir.Cuadrado())
                    {
                        CambiarEstado(Estados.seguir);
                    }
                    break;
                case Estados.seguir:
                    animBruja.SetBool("caminando", true);
                    agent.isStopped = false;
                    
                    agent.SetDestination(target.position);
                    if ((transform.position-target.position).sqrMagnitude < distanciaAtacar.Cuadrado())
                    {
                        CambiarEstado(Estados.atacando);
                    }
                    break;
                case Estados.rayos:
                    agent.isStopped = true;
                    animBruja.SetBool("caminando", false);
                    animBruja.SetTrigger("rayo");
                    yield return new WaitForSeconds(delayTiempoRayos);
                    rayos.SetActive(true);
                    yield return new WaitForSeconds(tiempoRayos);
                    rayos.SetActive(false);
                    CambiarEstado(Estados.regresando);
                    break;
                case Estados.atacando:
                    agent.isStopped = true;
                    animBruja.SetBool("caminando", false);
                    animBruja.SetBool("atacando", true);
                    yield return new WaitForSeconds(tiempoAtacando/2f);
                    if ((transform.position - target.position).sqrMagnitude < distanciaAtacar.Cuadrado())
                    {
                        saludJaime.DropHealth(dañoGolpes);
                    }
                    yield return new WaitForSeconds(tiempoAtacando / 2f);
                    if ((transform.position - target.position).sqrMagnitude > distanciaAtacar.Cuadrado())
                    {
                        CambiarEstado(Estados.seguir);
                    }
                    break;
                case Estados.regresando:
                    animBruja.SetBool("caminando", true);
                    agent.isStopped = false;
                    agent.SetDestination(initialPosition);

                    if ((transform.position - initialPosition).sqrMagnitude < 1)
                    {
                        CambiarEstado(Estados.idle);
                    }
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void CambiarEstado(Estados e)
    {
        if (estado == Estados.atacando)
        {
            animBruja.SetBool("atacando", false);
        }
        estado = e;

    }

    private void OnDrawGizmosSelected()
    {

#if UNITY_EDITOR
        Handles.color = Color.black;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaSeguir);
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaAtacar);
#endif
    }

}

public enum Estados
{
    idle,
    seguir,
    rayos,
    atacando, 
    regresando
}

public static class Extenciones
{
    public static float Cuadrado(this float f) => f * f;
}