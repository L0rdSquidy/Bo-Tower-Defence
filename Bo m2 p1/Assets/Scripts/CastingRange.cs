using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anims;
    void Start()
    {
        anims = GetComponent<Animator>();
        Debug.Log ("Attack!");
        anims.Play("attack");
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        anims.Play("attack");
        Debug.Log ("Attack!");
    }
}
