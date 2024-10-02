using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float EnemHp = 10;
    [SerializeField]private Wave wave;
    // Start is called before the first frame update
    void Start()
    {
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
            wave.KillUp();
            Destroy(gameObject);
        }
    }
}
