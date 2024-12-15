using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int scareDistance = 3;
    public Transform target;
    public Image scaryImage;


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
        scaryImage.gameObject.SetActive(true);
    }
}
