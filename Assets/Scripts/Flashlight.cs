using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public TMP_Text batteryText;
    public float battery = 40;
    Light spotlight;
    float batteryTimer;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spotlight = GetComponentInChildren<Light>();
        spotlight.enabled = false;

        batteryText.text = battery.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && battery > 50)
        {
            spotlight.enabled = !spotlight.enabled;
            audioSource.Play();
        }

        if (spotlight.enabled) batteryTimer += Time.deltaTime;
        if(batteryTimer >= 5)
        {
            battery--;
            batteryText.text = battery.ToString();
            batteryTimer = 0;
        }

        if(battery <= 50)
        {
            spotlight.intensity = Random.Range(0.7f, 1f);
        }

        if(battery < 0)
        {
            spotlight.enabled = false;
        }
    }
}
