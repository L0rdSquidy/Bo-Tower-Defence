using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D20 : MonoBehaviour
{
    public int result;
    // Start is called before the first frame update
    void Start()
    {
        float result = Random.Range(5, 20);
    }
    
    public void RollDaRolla()
    {
        result = Random.Range(5, 20);
        // return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
