using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public Enemy enemy;
    public FirstPersonMovement player;
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
            collision.gameObject.SetActive(false); // the page disappears once collected
            enemy.HarderAI(pagesCollected);

            // collecting a page charges the flashlight
            flashlight.battery += 10;
            flashlight.batteryText.text = $"Battery: {flashlight.battery.ToString()}";
        }
        if (pagesCollected == 2) player.canRun = true; // lets the player sprint when 2 or more pages are collected
    }
}
