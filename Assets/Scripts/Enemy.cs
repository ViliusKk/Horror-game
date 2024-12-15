using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int scareDistance = 3;
    public Transform target;
    public Image scaryImage;
    NavMeshAgent agent;
    public int viewDistance = 10;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    void Update()
    {
        //agent.SetDestination(target.position);

        float distance = Vector3.Distance(transform.position, target.position);


        if (distance <= viewDistance)
        {
            agent.SetDestination(target.position);
        }
        if (distance < scareDistance)
        {
            Jumpscare();
            enabled = false;
        }
    }

    void Jumpscare()
    {
        scaryImage.gameObject.SetActive(true);
    }
}
