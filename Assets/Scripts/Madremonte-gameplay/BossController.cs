using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    float lookRadius;
    Transform target;
    NavMeshAgent agent;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        lookRadius = GetComponent<SphereCollider>().radius;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
    }
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (!agent.hasPath) initialPosition = transform.position;
            agent.SetDestination(col.transform.position);
        }
    }
    void OnTriggerExit(Collider col)
    {
        StopCoroutine(WaitToReachDestination());
        StartCoroutine(WaitToReachDestination());
    }
    IEnumerator WaitToReachDestination()
    {
        while(agent.hasPath)
        {
            yield return null;
        }
        Debug.Log("!ª");
        agent.SetDestination(initialPosition);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
