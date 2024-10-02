using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class shot : MonoBehaviour
{
    public GameObject enemy;
    private Towers tower;
    [SerializeField] private float speed = 3;
    [SerializeField] private GameObject FireballExplosion;
    private Vector3 lastEnemPos;
    [SerializeField] private EnemyHP enemyHP;
    [SerializeField] int dammage;
    private D20 d20;

    void Start()
    {
        enemy = GetComponentInParent<Towers>().enemies[0].gameObject;
        tower = FindObjectOfType<Towers>();
        d20 = FindObjectOfType<D20>();

    }
    void Update()
    {
        if(enemy == null)
        {
            SelfDestruct();
        }
      
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
            lastEnemPos = enemy.transform.position;
       
    }

    void SelfDestruct()
    {
        transform.position = Vector3.MoveTowards(transform.position, lastEnemPos, speed * Time.deltaTime);
        Debug.Log(Vector3.Distance(transform.position, lastEnemPos));
        if (Vector3.Distance(transform.position, lastEnemPos) <= 0.1f&& this.gameObject.CompareTag("fireball"))
        {
        Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        enemyHP = other.GetComponent<EnemyHP>();
        Debug.LogWarning(enemyHP);
        if (other.CompareTag("Enemy"))
        {
            d20.RollDaRolla();
            enemyHP.HpReduction(dammage * d20.result / 10);
            if (enemyHP.EnemHp == 0)
            {
                tower.enemies.Remove(other.gameObject);
            }
            
            
            if (this.gameObject.CompareTag("fireball"))
            {
                Instantiate(FireballExplosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            } else if(gameObject.CompareTag("Slash"))
            {
                Destroy(this.gameObject, 0.5f);
            }
            
        }
        
    }
}
