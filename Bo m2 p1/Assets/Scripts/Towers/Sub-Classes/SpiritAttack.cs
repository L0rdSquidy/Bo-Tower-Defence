using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAttack : MonoBehaviour
{
    [SerializeField] private List<EnemyPathFinding> Enemies;
    [SerializeField] List<EnemyHP> enemiesHp;
    [SerializeField] private GameObject SpiritAtk;
    private float timeelapsed;
    [SerializeField] float SpititRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Enemies.Add(other.GetComponent<EnemyPathFinding>());
            enemiesHp.Add(other.GetComponent<EnemyHP>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesHp.Count > 0)
        {
            timeelapsed += Time.deltaTime;
            for (int i = 0; i < enemiesHp.Count; i++)
            {
                if (enemiesHp[i].EnemHp <= 0)
                {
                    enemiesHp.Remove(enemiesHp[i]);
                    Enemies.Remove(Enemies[i]);
                }
            }
        }
        if (timeelapsed >= SpititRate && Enemies.Count != 0)
        {
            Instantiate(SpiritAtk, Enemies[0].gameObject.transform.position, Quaternion.identity);
            timeelapsed = 0;
        }
        
    }
}
