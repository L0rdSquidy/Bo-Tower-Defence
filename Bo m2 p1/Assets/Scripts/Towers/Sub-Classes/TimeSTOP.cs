using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSTOP : MonoBehaviour
{
    private float timeelapsed;
    private bool cooldown = false;
    private timeManager timeManager;
    private AudioSource audioSource;
    private bool audioCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeManager = FindAnyObjectByType<timeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeelapsed += Time.deltaTime;
        if (timeelapsed > 25 && !audioCooldown)
        {
            audioSource.Play();
            audioCooldown = true;
        }
        if (timeelapsed > 30 && !cooldown)	
        {
            timeManager.TimeScaleActive = true;
            cooldown = true;
        }
        if (timeelapsed > 35 && cooldown)
        {
            audioSource.Stop();
            timeManager.TimeScaleActive = false;
            cooldown = false;
            timeelapsed = 0;
            audioCooldown = false;
        }
    }
}
