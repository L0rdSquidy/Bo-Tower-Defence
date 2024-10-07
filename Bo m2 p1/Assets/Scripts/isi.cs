using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isi : MonoBehaviour
{
    [SerializeField] private Animator anims;

    private void Start() 
    {
        anims = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            anims.Play("attack");
            Debug.Log ("Attack!");
        }
    }
}
