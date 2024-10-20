using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerExp : MonoBehaviour
{
    public float exp;
    [SerializeField] public float expReq;
    [SerializeField] public int levels;
    public float dammageMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExpAdding(float ExpAds)
    {
       exp += ExpAds; 
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= expReq)
        {
            exp = 0;
            levels ++;
            expReq = expReq * 1.5f;
            dammageMultiplier += levels * 0.1f;
        }
    }
}
