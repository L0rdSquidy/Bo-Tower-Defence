using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class catWalk : MonoBehaviour
{
    [SerializeField] private Vector3 differencefactor;
    public Vector3 startpoint;
    private Vector3 Goingpoint;
    float distance;
    [SerializeField] private List<Vector3> coordinates = new List<Vector3>();
    private Vector3 diraction;
    [SerializeField] private int Pointposition;
    [SerializeField] private int lookposition;
    [SerializeField] float  speed = 1f;
    [SerializeField] private float timeelapsed;
    Vector3 offset = new Vector3(0, 0, -2);
    void Start()
    {
        transform.position = startpoint; 
        Goingpoint = coordinates[Pointposition];
        
    }

    // Update is called once per frame
    void Update()
    {  
        timeelapsed += Time.deltaTime;
        if (timeelapsed > Random.Range(6, 9) && timeelapsed < 13)
        {
            speed = 0.5f;
        } 
         if (timeelapsed > Random.Range(13, 15))
        {
            speed = 1;
            timeelapsed = 0;
        }
        lookposition = Mathf.Max(lookposition, 0);
        lookposition = Pointposition -1;
        if (lookposition < 0)
        {
            lookposition = 0;
        }
         if (Pointposition ==  3)
            {
                Pointposition = 0;
            }
        StartRunning();   
    }

    public void StartRunning()
    {
        differencefactor = Goingpoint - transform.position;
        distance = differencefactor.magnitude;
        diraction = differencefactor.normalized;
        
        transform.position += diraction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, coordinates[lookposition] - transform.position);
        transform.rotation *= Quaternion.Euler(offset);
        if (differencefactor.magnitude < 0.1)
        {
            Goingpoint = coordinates[Pointposition];
            
            Pointposition ++;
        }
            
            
        }
    }

