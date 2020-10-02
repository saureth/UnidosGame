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
    public bool pushing;
    public float rotacionCamara;

    public bool bloqueado;

    public GameObject camara;

    public bool activo = true;
    void Start()
    {
        camara = GetComponentInChildren<Camera>().gameObject;
        rotacionCamara = camara.transform.localEulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (bloqueado) return;
        transform.Rotate(velRotacion * Time.deltaTime * Input.GetAxis("Mouse X") * Vector3.up);
        rotacionCamara += -velRotacion * Time.deltaTime * Input.GetAxis("Mouse Y");
        rotacionCamara = Mathf.Clamp(rotacionCamara, 0, 40);
        camara.transform.localEulerAngles = (rotacionCamara * Vector3.right);
        velocidad = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).sqrMagnitude;
        animator.SetFloat("velocidad", velocidad);
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("saltar");
        }
        bool dashingOrPushing = dashing || pushing;
        if (Input.GetMouseButtonDown(1) && !dashingOrPushing)
        {
            StartCoroutine(Dashear());
        }
        if (Input.GetMouseButtonDown(0) && !dashingOrPushing)
        {
            StartCoroutine(Golpear());
        }
    }

    public IEnumerator Dashear()
    {
        dashing = true;
        animator.SetTrigger("dash");
        yield return new WaitForSeconds(1);
        dashing = false;
    }

    public void Bloquear()
    {
        animator.SetFloat("velocidad", 0);
        bloqueado = true;
    }

    public void Desbloquear()
    {
        bloqueado = false;
    }


    void UnDashing()
    {
        dashing = false;
    }
    void UnPushing()
    {
        pushing = false;
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

    public IEnumerator Golpear()
    {
        pushing = true;
        animator.SetTrigger("golpear");
        yield return new WaitForSeconds(1);
        pushing = false;
    }

    public void Rayo(bool yaRayo)
    {
        if (yaRayo)
        {
            return;
        }
        animator.SetTrigger("rayo");
    }
}
