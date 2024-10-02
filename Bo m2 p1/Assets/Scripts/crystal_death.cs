using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal_death : MonoBehaviour
{    
    private float CrystalHealth = 10;
    private Wave wave;
    // Start is called before the first frame update
    void Start()
    {
        wave = FindAnyObjectByType<Wave>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("hello this works");
        if (other.CompareTag("Enemy"))
        {  
            wave.KillUp();
            CrystalHealth -= 1;
            Destroy(other.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
