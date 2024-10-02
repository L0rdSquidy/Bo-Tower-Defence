using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private Vector3 differencefactor;
    public Vector3 startpoint;
    private Vector3 Goingpoint;
    float distance;
    [SerializeField] private List<Vector3> coordinates = new List<Vector3>();
    private Vector3 diraction;
    private int Pointposition;
    [SerializeField] float  speed = 1f;
    void Start()
    {
        
        if(startpoint == new Vector3(4, -8, 0))
        {
            UpdateCoordinates(0, new Vector3(4, -3.25f, 0));
            UpdateCoordinates(1, new Vector3(9, -3.25f, 0));
            UpdateCoordinates(2, new Vector3(9, -1, 0));
            UpdateCoordinates(3, new Vector3(12, -1, 0));
            UpdateCoordinates(4, new Vector3(12, 3.25f, 0));
        }
        transform.position = startpoint; 
        Goingpoint = coordinates[Pointposition];
    }

    
    private void UpdateCoordinates(int index, Vector3 newCoordinates)
    {
        coordinates[index] = newCoordinates;
    }

    // Update is called once per frame
    void Update()
    {  
        StartRunning();
    }

    public void StartRunning()
    {
        differencefactor = Goingpoint - transform.position;
        distance = differencefactor.magnitude;
        diraction = differencefactor.normalized;

        transform.position += diraction * speed * Time.deltaTime;
        if (differencefactor.magnitude < 0.3)
        {
            Goingpoint = coordinates[Pointposition];
            Pointposition ++;
        }
    }
}


