using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public Towers towers;
    [SerializeField] Vector3 differencefactor;
    public Vector3 startpoint;
    [SerializeField] private Vector3 Goingpoint;
    Vector3 diraction;
    private float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        towers = FindAnyObjectByType<Towers>();
        if (towers.enemies.Count != 0)
        {
            Goingpoint = towers.enemies[0].transform.position;
            transform.position += diraction * speed * Time.deltaTime;
        }
        differencefactor = Goingpoint - transform.position;
        // distance = differencefactor.magnitude;
        diraction = differencefactor.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hello???");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
