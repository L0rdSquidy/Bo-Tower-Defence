using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] int waveCount;
    int enemyCount = 10;
    public int killCount;
    public EnemyPathFinding enempath;
    public EnemyPathFinding enemyPathW10;
    public EnemyPathFinding enemyPathFindingW20;
    private bool LaneSwitch;
    [SerializeField] private TMP_Text WaveText;
    public GameObject goblin;
    public GameObject kobolt;
    public GameObject orc;
    private GameObject currentEnemy;
    private Cash cash;
    private float SpawnSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        WaveText.text = "" + waveCount;
        EnemyManager();
    cash = FindAnyObjectByType<Cash>();
       StartCoroutine(StartWave(currentEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        if (killCount >= enemyCount)
        {
            enemyCount = enemyCount += 4;
            WaveText.text = "" + waveCount;
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
                SpawnSpeed = 1;
                currentEnemy = goblin;
                Debug.Log(currentEnemy);
            }
            else if (waveCount <= 20)
            {
                SpawnSpeed = 2;
                currentEnemy = kobolt;
                enemyCount = 10;
                cash.switched = 1;
            }
            else
            {
                SpawnSpeed = 3;
                currentEnemy = orc;
                enemyCount = 10;
                cash.switched = 2;
            }
    }


    IEnumerator StartWave(GameObject enemy)
    {
        yield return new WaitForSeconds(8f);
            Debug.Log("Hello");
            for (int i = 0; i < enemyCount; i++)
            {
                new WaitForSeconds(SpawnSpeed);
                Instantiate(enemy);
                Debug.Log(enemy);
                if (LaneSwitch == true)
                {
                    if (waveCount <= 10)
                    {
                        enempath.startpoint = new Vector3(4, -8, 0);
                        LaneSwitch = false;
                    }
                    else if (waveCount <= 20)
                    {
                        enemyPathW10.startpoint = new Vector3(4, -8, 0);
                        LaneSwitch = false;
                    }
                    else 
                    {
                        enemyPathFindingW20.startpoint = new Vector3(4, -8, 0);
                        LaneSwitch = false;
                    }       
                    
                } 
                else if(LaneSwitch == false)
                {
                    if (waveCount <= 10)
                    {
                        enempath.startpoint= new Vector3(-4, -8, 0);
                        LaneSwitch = true;
                    }
                    else if (waveCount <= 20)
                    {
                        enemyPathW10.startpoint = new Vector3(-4, -8, 0);
                        LaneSwitch = true;
                    }
                    else
                    {
                        enemyPathFindingW20.startpoint= new Vector3(-4, -8, 0);
                        LaneSwitch = true;
                    }   
                   
                }
                yield return new WaitForSeconds(SpawnSpeed);
            }
       waveCount ++;
       EnemyManager();
    }
}
