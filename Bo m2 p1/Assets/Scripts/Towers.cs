using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public List<GameObject> enemies;
    private float timeelapsed;
    public bool isInRadius;
    public GameObject Fireball;
    [SerializeField] private float cooldown;
    [SerializeField] private float stamina;
    [SerializeField] private bool Barcooldown;
    [SerializeField] private float staminareq;
    private void Start() 
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.CompareTag("Enemy"))
        {
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
        if (isInRadius && timeelapsed >= cooldown && stamina >= 0 && !Barcooldown)
        {
            stamina -= 1;
            fire();
            timeelapsed = 0;
        }
        if (stamina <0)
        {
            stamina = 0;
        }
        if (stamina <= staminareq)
        {
            StartCoroutine(Kiregen());
        }
        
    }

    private IEnumerator Kiregen()
    {
        while (stamina < 200)
        {
            if (stamina < 100)
            {
                Barcooldown = true;
            } else if (stamina > 200)
            {
                Barcooldown = false;
            }
        stamina++;
        yield return new WaitForSeconds(0.05f);
        }
    }
    public void fire()
    {
        Instantiate(Fireball, transform.position, Quaternion.identity, transform);
    }
}
