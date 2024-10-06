using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Wave : MonoBehaviour
{
    int waveCount;
    int enemyCount = 10;
    bool waveStart;
    public int killCount;
    public EnemyPathFinding enempath;
    private bool LaneSwitch;
    public GameObject goblin;
    public GameObject kobolt;
    public GameObject orc;
    private GameObject currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager();
       StartCoroutine(StartWave(currentEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        if (killCount == enemyCount)
        {
            enemyCount = enemyCount += 4;
            StartCoroutine(StartWave(currentEnemy));
            killCount = 0;
        }
    }
    public void KillUp()
    {
        killCount ++;
    }
    public void EnemyManager()
    {
        if (waveCount <= 10)
            {
                currentEnemy = goblin;
                Debug.Log(currentEnemy);
            }
            else if (waveCount <= 20)
            {
                currentEnemy = kobolt;
                enemyCount = 10;
            }
            else if (waveCount <= 30) 
            {
                currentEnemy = orc;
                enemyCount = 10;
            }
    }


    IEnumerator StartWave(GameObject enemy)
    {
        yield return new WaitForSeconds(8f);
            Debug.Log("Hello");
            for (int i = 0; i < enemyCount; i++)
            {
                new WaitForSeconds(1f);
                Instantiate(enemy);
                if (LaneSwitch == true)
                {
                    enempath.startpoint = new Vector3(4, -8, 0);
                    LaneSwitch = false;
                } 
                else if(LaneSwitch == false)
                {
                    enempath.startpoint = new Vector3(-4, -8, 0);
                    LaneSwitch = true;
                }
                yield return new WaitForSeconds(1f);
            }
       waveCount ++;
       EnemyManager();
    }
}
