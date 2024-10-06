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
    
    
    void Start()
    {
        chars = FindAnyObjectByType<CharacterSelection>();
    }

private void OnMouseDown() 
{
    
    if (!towerselectorActive)
    {
        towerSpawner = Instantiate(towerSpawner, this.transform.position, Quaternion.identity, transform);
        Slitch = FindAnyObjectByType<selectionSwitch>();
        chars = FindAnyObjectByType<CharacterSelection>();
        towerselectorActive = true;
    }
    if (Input.GetKeyDown(KeyCode.Mouse0) && towerselectorActive)
    {
        GameObject[] units = {wizards, druid, bard, fighter, monk};
        for (int i = 0; i < units.Length; i++)
            {
                if (Slitch.selected[i])
                {
                    DestroyTowerSpawner();
                    Instantiate(units[i], this.transform.position, Quaternion.identity, transform);
                    break; 
                }
            }
    }
}

private void DestroyTowerSpawner()
{
    
    if (towerSpawner != null)
    {
        Destroy(towerSpawner.gameObject);
        towerSpawner = null;
        towerselectorActive = false; 
    }
}
}
