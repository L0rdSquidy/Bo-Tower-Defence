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
            cash.CashAdd(values[cash.switched]);
            wave.KillUp();
            Destroy(gameObject);
        }
    }
}
