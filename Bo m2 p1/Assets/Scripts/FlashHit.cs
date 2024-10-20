using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHit : MonoBehaviour
{
    [SerializeField] List<EnemyHP> enemies;
    private float timeelapsed;
    bool InRange;
    [SerializeField] private float atk;
    [SerializeField] private float atkTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.GetComponent<EnemyHP>());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 0)
        {
            InRange = true;
        } else
        {
            InRange = false;
        }
        if (InRange)
        {
            timeelapsed += Time.deltaTime;
        }
        if (timeelapsed >= atkTime)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].HpReduction(atk);
                if (enemies[i].EnemHp <= 0)
                {
                    enemies.Remove(enemies[i]);
                }
            }
            timeelapsed = 0;
        }
    }
}
