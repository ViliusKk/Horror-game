using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public Enemy enemy;
    public int pagesCollected;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Page"))
        {
            pagesCollected++;
            collision.gameObject.SetActive(false);
            enemy.HarderAI();
        }
    }
}
