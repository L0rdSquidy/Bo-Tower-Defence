using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public List<GameObject> enemies;
    private float timeelapsed;
    public bool isInRadius;
    public GameObject Fireball;
    private void Start() 
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.CompareTag("Enemy"))
        {
        // isInRadius = true;
        enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
        enemies.Remove(other.gameObject);
        }
    }

    private void Update() 
    {
        timeelapsed += Time.deltaTime;
        
        if (enemies.Count == 0)
        {
            isInRadius = false;
        } else if (enemies.Count != 0)
        {
            isInRadius = true;
        }
        if (isInRadius && timeelapsed >= 2)
        {
            fire();
            timeelapsed = 0;
        }
        
    }
    public void fire()
    {
        
        Instantiate(Fireball, transform.position, Quaternion.identity);
    }
}
