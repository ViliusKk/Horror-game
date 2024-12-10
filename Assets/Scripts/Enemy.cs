using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scareDistance = 3;
    public Transform target;


    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < scareDistance)
        {
            Jumpscare();
            enabled = false;
        }
    }

    void Jumpscare()
    {
        print("boo");
    }
}
