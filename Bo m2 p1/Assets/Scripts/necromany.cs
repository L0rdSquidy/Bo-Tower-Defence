using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necromany : MonoBehaviour
{
    private float timeelapsed;
    [SerializeField] private bool SkelSwitch;
    [SerializeField] private GameObject Skel;
    public EnemyPathFinding enempath;

    void Update()
    {
        timeelapsed += Time.deltaTime;
        if (timeelapsed >= 3f)
        {
            Instantiate(Skel);
            if (SkelSwitch == true)
            {
                SkelSwitch = false;
                enempath.startpoint = new Vector3(0, 6.5f, 0);
            }else if (SkelSwitch == false)
            {
                enempath.startpoint = new Vector3(0, 5.5f, 0);
                SkelSwitch = true;
            }
            timeelapsed = 0;
        }
    }
}