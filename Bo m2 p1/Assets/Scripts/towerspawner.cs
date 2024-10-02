using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerspawner : MonoBehaviour
{
    public GameObject towerSpawner;
    public selectionSwitch Slitch;
    private CharacterSelection chars;
    public GameObject wizards;
    public GameObject fighter;
    public GameObject druid;
    public GameObject monk;
    public GameObject bard;
    public bool towerselectorActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Slitch = FindAnyObjectByType<selectionSwitch>();
        chars = FindAnyObjectByType<CharacterSelection>();
    }

private void OnMouseDown() 
{
    // Spawn tower selector if not active
    if (!towerselectorActive)
    {
        // Instantiate tower spawner and activate the selector
        towerSpawner = Instantiate(towerSpawner, this.transform.position, Quaternion.identity);
        Slitch = FindAnyObjectByType<selectionSwitch>();
        towerselectorActive = true;
    }

    // Check if the left mouse button is clicked and the tower selector is active
    if (Input.GetKeyDown(KeyCode.Mouse0) && towerselectorActive)
    {
        // Check which character is selected
        if (Slitch.selected[0])
        {
            DestroyTowerSpawner();
            Instantiate(wizards, this.transform.position, Quaternion.identity);
        } 
        else if (Slitch.selected[1])
        {
            DestroyTowerSpawner();
            Instantiate(druid, this.transform.position, Quaternion.identity);
        }
        else if (Slitch.selected[2])
        {
            DestroyTowerSpawner();
            Instantiate(bard, this.transform.position, Quaternion.identity);
        }
        else if (Slitch.selected[3])
        {
            DestroyTowerSpawner();
            Instantiate(fighter, this.transform.position, Quaternion.identity);
        }
        else if (Slitch.selected[4])
        {
            DestroyTowerSpawner();
            Instantiate(monk, this.transform.position, Quaternion.identity);
        }
    }
}

private void DestroyTowerSpawner()
{
    // Ensure tower spawner is destroyed and reference is nullified
    if (towerSpawner != null)
    {
        Destroy(towerSpawner.gameObject);
        towerSpawner = null;
        towerselectorActive = false; // Ensure selector is deactivated
    }
}

    // Update is called once per frame
    void Update()
    {
        chars = FindAnyObjectByType<CharacterSelection>();
        
        
    }
}
