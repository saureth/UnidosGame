using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchPlayer : MonoBehaviour
{
    public PlayerRunnerBehaviour pl;
    public PlayerMovementWJump2 pm;
    public EnemyMovement em;
    public Animator enemyAnim;
    public LayerMask playerLayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & playerLayer) != 0)
        {
            pm.isMoving = false;
            em.isMoving = false;
            enemyAnim.SetBool("caminando", false);
            enemyAnim.SetTrigger("puño");
            StartCoroutine(DamagePlayer(2));
            // animar madremonte para hacer daño
        }
    }

    private IEnumerator DamagePlayer(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            pl.TakeDamage(100f);
    }


}
