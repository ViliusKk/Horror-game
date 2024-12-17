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

    float timer;

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
        timer += Time.deltaTime;
        //agent.SetDestination(target.position);

        float distance = Vector3.Distance(transform.position, target.position);


        if (distance <= viewDistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(randomDestination);
            //if(timer >= 3)
            //{
            //    timer = 0;
            //    float ranX = Random.Range(-5f, 5f);
            //    float ranY = Random.Range(-5f, 5f);

            //    Vector3 ranPos = new Vector3(transform.position.x - ranX, transform.position.y - ranY, 0);
            //    agent.SetDestination(ranPos);
            //}
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

    public void HarderAI(int pagesCollected)
    {
        print(pagesCollected);
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
