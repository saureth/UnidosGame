using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class RayoDeLaMuerte : MonoBehaviour
{
    private LineRenderer linea;
    public GameObject particulas;
    public float cuantoDaño = 4;
    public LayerMask capas;

    private void Start()
    {
        linea = GetComponent<LineRenderer>();
        Inicializar();
    }

    public void Inicializar()
    {
        linea.SetPosition(0, transform.position);
        linea.SetPosition(1, transform.position);
    }
    void FixedUpdate()
    {
        Inicializar();
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit,100, capas))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (hit.transform.GetComponent<AnimatorMovementJaime>().dashing)
                {
                    particulas.SetActive(false);
                    linea.SetPosition(1, transform.position + transform.forward * 100);
                }
                else
                {
                    hit.transform.GetComponent<Health>().DropHealth(cuantoDaño * Time.fixedDeltaTime);
                    hit.transform.GetComponent<AnimatorMovementJaime>().Rayo();
                }
            }
            linea.SetPosition(1, hit.point);
            particulas.SetActive(true);
            particulas.transform.position = hit.point;
        }
        else
        {
            particulas.SetActive(false);
            linea.SetPosition(1, transform.position + transform.forward*100);
        }
    }
}
