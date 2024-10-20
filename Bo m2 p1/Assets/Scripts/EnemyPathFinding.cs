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
    private timeManager timeManager;
    private float TimeScale;
    [SerializeField] private List<Vector3> coordinates = new List<Vector3>();
    [SerializeField] private List<Quaternion> rotations= new List<Quaternion>();
    [SerializeField] private List<Quaternion> rotationsPath2= new List<Quaternion>();
    private List<Quaternion> CurrentRotationsrotations= new List<Quaternion>();
    private Vector3 diraction;
    private int Pointposition;
    public float  speed = 1f;
    private float SpeedSet;
    public bool IsSlowedDown = false;
    float timeelapsed;
    void Start()
    {
        SpeedSet = speed;
        timeManager = FindAnyObjectByType<timeManager>();
        
        if(startpoint.Equals(new Vector3(4, -8, 0)))
        {
            CurrentRotationsrotations = rotations;
            UpdateCoordinates(0, new Vector3(4, -3.25f, 0));
            UpdateCoordinates(1, new Vector3(9, -3.25f, 0));
            UpdateCoordinates(2, new Vector3(9, -1, 0));
            UpdateCoordinates(3, new Vector3(12, -1, 0));
            UpdateCoordinates(4, new Vector3(12, 3.25f, 0));
        }
        if (startpoint.Equals(new Vector3(-4, -8, 0)))
        {
            CurrentRotationsrotations = rotationsPath2;
        }
        if (startpoint.Equals(new Vector3(0, 6.5f, 0)))
        {
            CurrentRotationsrotations = rotations;
            UpdateCoordinates(1, new Vector3(12, 3.25f, 0));
            UpdateCoordinates(2, new Vector3(12, -1, 0));
            UpdateCoordinates(3, new Vector3(9, -1, 0));
            UpdateCoordinates(4, new Vector3(9, -3.25f, 0));
            UpdateCoordinates(5, new Vector3(4, -3.25f, 0));
            UpdateCoordinates(6, new Vector3(4, -13, 0));
        }
        if (startpoint.Equals(new Vector3(0, 5.5f, 0)))
        {
            CurrentRotationsrotations = rotationsPath2;
        }
        transform.position = startpoint; 
        Goingpoint = coordinates[Pointposition];
    }

    
    private void UpdateCoordinates(int index, Vector3 newCoordinates)
    {
        coordinates[index] = newCoordinates;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("NatureExplosion") && !IsSlowedDown)
        {
            speed *= 0.7f;
            IsSlowedDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        TimeScale = timeManager.TimeScaling;
        if (IsSlowedDown)
        {
            timeelapsed += Time.deltaTime;
            if (timeelapsed > 5)
            {
                IsSlowedDown = false;
                timeelapsed = 0;
            }
        }
        StartRunning();
         if (this.CompareTag("Enemy"))
        {
            if (timeManager.TimeScaleActive)
            {
                speed *= TimeScale;
            }
            if (!timeManager.TimeScaleActive && !IsSlowedDown)
            {
                speed = SpeedSet;
            }
            
        }
        
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
            transform.rotation = CurrentRotationsrotations[Pointposition];
            Pointposition ++;
        }
    }
}


