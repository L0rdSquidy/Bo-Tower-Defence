using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
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
    [SerializeField] private Animator anims;
    [SerializeField] private bool AttackTrigger = false;
    // [SerializeField] TowerExp Exp;
    Vector3 offset = new Vector3(0, 0, 180);
    private void Start() 
    {
        anims = GetComponentInChildren<Animator>();
        // Exp = Exp.GetComponent<TowerExp>();
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
        isInRadius = enemies.Count > 0;
        if (isInRadius && timeelapsed >= cooldown && stamina >= 0 && !Barcooldown)
        {
            stamina -= 1;
            fire();
            timeelapsed = 0;
        }
        
        stamina = Mathf.Max(stamina, 0);

        if (stamina <= staminareq)
        {
            StartCoroutine(Kiregen());
        }
        
    }

    private IEnumerator Kiregen()
    {
        while (stamina < 20)
        {
            if (stamina < 10)
            {
                Barcooldown = true;
            } else if (stamina >= 15)
            {
                Barcooldown = false;
            }
        stamina++;
        yield return new WaitForSeconds(0.05f);
        }
    }
    public void fire()
    {
        anims.Play("attack");
        Instantiate(Fireball, transform.position, Quaternion.identity, transform);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, enemies[0].transform.position - transform.position);
        transform.rotation *= Quaternion.Euler(offset);
    }
}
