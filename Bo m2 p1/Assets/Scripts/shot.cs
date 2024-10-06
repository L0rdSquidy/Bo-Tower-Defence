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
    [SerializeField] private TowerExp expMultiplier;
    [SerializeField] private Transform TowerTransform;

    void Start()
    {
        TowerTransform = gameObject.transform.parent.transform;
        enemy = TowerTransform.GetComponent<Towers>().enemies[0].gameObject;
        tower = TowerTransform.GetComponent<Towers>();
        expMultiplier = TowerTransform.GetComponent<TowerExp>();
        
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
            int d20 = Random.Range(1, 20);
            enemyHP.HpReduction(dammage * d20 / 10 * expMultiplier.dammageMultiplier);
            Debug.LogWarning(d20);

            if (enemyHP.EnemHp == 0)
            {
                tower.enemies.Remove(other.gameObject);
            }

            if (this.gameObject.CompareTag("fireball"))
            {
                Instantiate(FireballExplosion, transform.position, Quaternion.identity, tower.transform);
                Destroy(this.gameObject);
            } else if(gameObject.CompareTag("Slash"))
            {
                Destroy(this.gameObject, 0.5f);
            }
            
        }
        
    }
}
