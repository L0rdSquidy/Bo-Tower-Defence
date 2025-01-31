using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject enemy;
    private Towers tower;
    [SerializeField] private float speed = 3;
    [SerializeField] private GameObject FireballExplosion;
    private Vector3 lastEnemPos;
    [SerializeField] private EnemyHP enemyHP;
    [SerializeField] public int damage;
    [SerializeField] private TowerExp expMultiplier;
    [SerializeField] private Transform TowerTransform;

    void Start()
    {
        TowerTransform = transform.parent.transform;
        tower = TowerTransform.GetComponent<Towers>();
        expMultiplier = TowerTransform.GetComponent<TowerExp>();
        if (tower.enemies.Count > 0) enemy = tower.enemies[0];

        tower.GetTotal(damage, expMultiplier.dammageMultiplier);
    }

    void Update()
    {
        if (enemy == null)
        {
            SelfDestruct();
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        lastEnemPos = enemy.transform.position;
    }

    void SelfDestruct()
    {
        transform.position = Vector3.MoveTowards(transform.position, lastEnemPos, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, lastEnemPos) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        enemyHP = other.GetComponent<EnemyHP>();
        if (other.CompareTag("Enemy") && enemyHP != null)
        {
            int d20 = Random.Range(1, 20);
            
            if (tower.selectedSubclass == SubclassType.ThunderMage)
            {
                damage += 1;
            }
            
            enemyHP.HpReduction(damage * d20 / 10 * expMultiplier.dammageMultiplier);
            Debug.Log("HEy");

            if (enemyHP.EnemHp == 0)
            {
                tower.enemies.Remove(other.gameObject);
            }

            if (gameObject.CompareTag("fireball"))
            {
                Instantiate(FireballExplosion, transform.position, Quaternion.identity, tower.transform);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Slash"))
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
