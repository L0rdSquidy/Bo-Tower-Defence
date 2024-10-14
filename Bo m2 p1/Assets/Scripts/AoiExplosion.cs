using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoiExplosion : MonoBehaviour
{
    private EnemyHP enemyHP;
    private int dammage = 2;
    private TowerExp expMultiplier;
    
    // Start is called before the first frame update
    void Start()
    {
        expMultiplier = GetComponentInParent<TowerExp>();
        Invoke(nameof(OnDestroy), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        enemyHP = other.GetComponent<EnemyHP>();
        expMultiplier.ExpAdding(10);
        if (other.CompareTag("Enemy"))
        {
            int d20 = Random.Range(1, 20);
            enemyHP.HpReduction(dammage * d20 / 10);
        }
    }
}
