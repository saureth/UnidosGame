using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMovementJaime : MonoBehaviour
{
    public Animator animator;
    public float velocidad;
    public GameObject tipleEspalda;
    public GameObject tipleFrente;
    public float velRotacion;
    public bool dashing;

    public GameObject camara;

    public bool activo = true;
    void Start()
    {
        camara = GetComponentInChildren<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velRotacion * Time.deltaTime * Input.GetAxis("Mouse X") * Vector3.up);
        camara.transform.Rotate(-velRotacion * Time.deltaTime * Input.GetAxis("Mouse Y") * Vector3.right);
        velocidad = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).sqrMagnitude;
        animator.SetFloat("velocidad", velocidad);
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("saltar");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("dash");
            dashing = true;
            Invoke("UnDashing", 3);
        }
    }


    void UnDashing()
    {
        dashing = false;
    }

    public void Desactivar()
    {
        activo = false;
        animator.SetFloat("velocidad", 0);
        animator.SetFloat("horizontal", 0);
        animator.SetFloat("vertical", 0);
    }
    public void Guitarrear(bool b)
    {
        tipleEspalda.SetActive(!b);
        tipleFrente.SetActive(b);
        animator.SetBool("guitarreando", b);
    }
    [ContextMenu("Guitarrear")]
    public void GuitarCambio()
    {
        Guitarrear(!animator.GetBool("guitarreando"));
    }

    public void Activar()
    {
        animator.SetBool("guitarreando", false);
        activo = true;
    }
}
