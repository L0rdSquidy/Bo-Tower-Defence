using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoiExplosion : MonoBehaviour
{
    [SerializeField] private EnemyHP enemyHP;
    private D20 d20;
    private int dammage = 2;
    // Start is called before the first frame update
    void Start()
    {
        d20 = FindObjectOfType<D20>();
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
        
        if (other.CompareTag("Enemy"))
        {
            d20.RollDaRolla();
            enemyHP.HpReduction(dammage * d20.result / 10);
        }
    }
}
