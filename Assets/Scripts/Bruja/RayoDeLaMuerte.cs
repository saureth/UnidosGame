﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class RayoDeLaMuerte : MonoBehaviour
{
    private LineRenderer linea;
    public GameObject particulas;

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
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit))
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
                    //QUitarle vida al personaje
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