using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class catPet : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private float timeelapsed;
    private bool cooldown;
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }
    private void OnMouseDown() 
    {
        if (!cooldown)
        {
        Debug.Log("Meow");
        audioSource.Play();
        StartCoroutine(StopMeow()); 
        }
        
    }

    IEnumerator StopMeow()
    {
        cooldown = true;
        yield return new WaitForSeconds(3);
        audioSource.Stop();
        cooldown = false;
    }
    // Update is called once per frame
}
