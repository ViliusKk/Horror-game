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
    public int viewDistance = 10;
    public int patrolDistance = 5;
    NavMeshAgent agent;
    Vector3 randomDestination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(RandomDestination), 3f, 3f);
        randomDestination = transform.position;
    }

    void RandomDestination()
    {
        randomDestination.x += Random.Range(-1f,1f) * patrolDistance;
        randomDestination.y += Random.Range(-1f, 1f) * patrolDistance;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);


        if (distance <= viewDistance) agent.SetDestination(target.position);
        else agent.SetDestination(randomDestination);

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

    public void HarderAI(int pagesCollected)
    {
        // Difficulty increases by: increasing enemy's view distance, patrol distance and movement speed.
        if (pagesCollected == 1)
        {
            viewDistance = 20;
            patrolDistance = 10;
            agent.speed += 0.5f;
        }
        else if(pagesCollected == 2)
        {
            viewDistance = 30;
            agent.speed += 1;
        }
        else if(pagesCollected == 3)
        {
            viewDistance = 40;
            patrolDistance = 20;
            agent.speed += 1;
        }
        else
        {
            viewDistance = 50;
            agent.speed += 0.5f;
        }
    }
}
