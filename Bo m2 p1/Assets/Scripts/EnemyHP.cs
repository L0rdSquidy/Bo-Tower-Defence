using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float EnemHp = 10;
    [SerializeField]private Wave wave;
    private Cash cash;
    [SerializeField] List<int> values;
    private EnemyHP enemyHP;
    private float LastHealth;
    public int switched;
    // Start is called before the first frame update
    void Start()
    {
        cash = FindAnyObjectByType<Cash>();
        wave = FindAnyObjectByType<Wave>();
    }

    public void HpReduction(float dammage)
    {
        EnemHp -= dammage;	
    }

    // Update is called once per frame
    void Update()
    {
        
            if (EnemHp <= 0)
        {
            if (this.CompareTag("Enemy"))
            {
                cash.CashAdd(values[cash.switched]);
                wave.KillUp();
                Destroy(gameObject);
            }else
            {
                Destroy(gameObject);
            }
        
        }
    
       
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {    
        if (!gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Skel");
            enemyHP = other.GetComponent<EnemyHP>();
            LastHealth = enemyHP.EnemHp;
            if (other.gameObject.CompareTag("Enemy"))
                {
                    enemyHP.HpReduction(EnemHp);
                    HpReduction(LastHealth);
                }

            if (other.gameObject.CompareTag("Skel"))
                {
                    Destroy(gameObject);
                }
        }
    }
}
