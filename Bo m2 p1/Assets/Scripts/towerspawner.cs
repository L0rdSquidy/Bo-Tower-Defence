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
    private bool TowerGotSpawned;
    public HighlightColor highlightColor;
    private Cash cash;
    
    
    void Start()
    {
        chars = FindAnyObjectByType<CharacterSelection>();
        cash = FindAnyObjectByType<Cash>();
        // highlightColor.GetComponent<HighlightColor>();
    }

private void OnMouseDown() 
{
    if (!TowerGotSpawned)
    {
        if (!towerselectorActive && cash.cash >= 300)
    {
        cash.CashAdd(-300); 
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
                    TowerGotSpawned = true;
                    Destroy(highlightColor);
                    Debug.Log(highlightColor);
                    Debug.Log(TowerGotSpawned);
                    break; 
                }
            }
    }
    }
    
}

private void DestroyTowerSpawner()
{
    
    if (towerSpawner != null)
    {
        towerSpawner.gameObject.SetActive(false);
        towerselectorActive = false; 
    }
}
}
