using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public Enemy enemy;
    public Flashlight flashlight;
    public int pagesCollected = 0;
    public TMP_Text pagesCollectedText;

    void Start()
    {
        pagesCollectedText.text = $"Pages collected: {pagesCollected.ToString()}";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Page"))
        {
            pagesCollected++;
            pagesCollectedText.text = $"Pages collected: {pagesCollected.ToString()}";
            collision.gameObject.SetActive(false);
            enemy.HarderAI(pagesCollected);

            flashlight.battery += 10;
            flashlight.batteryText.text = $"Battery: {flashlight.battery.ToString()}";
        }
    }
}
