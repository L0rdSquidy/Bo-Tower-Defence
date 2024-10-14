using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetSpawn : MonoBehaviour
{
    [SerializeField] private CharSheet charSheet;
    [SerializeField] private TowerExp expMultiplier;
    [SerializeField] private Towers towerScript;
    [SerializeField] private GameObject CharacterSheet;
    [SerializeField] private GameObject CanvasObject;
    private Canvas canvas;
    private GameObject Charasheet;
    public bool SheetIsActive;
    private int SheetSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindAnyObjectByType<Canvas>();
        CanvasObject = canvas.gameObject;
    }
    private void OnMouseDown() 
    {
        
        if (!SheetIsActive)
        {
            if (SheetSpawned == 0)
            {
                SheetSpawned++;
            Charasheet = Instantiate(CharacterSheet, new Vector3(900, 500,0), Quaternion.identity, CanvasObject.transform);
            charSheet = Charasheet.GetComponent<CharSheet>();
            } else
            {
                Charasheet.SetActive(true);
            } 
            StartCoroutine(Characsheet());
            SheetIsActive = true;
            
        }
        if (!Charasheet.active)
        {
            SheetIsActive = false;
        }
        
        
    }

    IEnumerator Characsheet()
    {
        yield return new WaitForSeconds(0.2f);
        charSheet.CharDmmg.text = "" + towerScript.TotalDmmg;
        charSheet.CharLevel.text = "" + towerScript.TotalLvL;
        if (!towerScript.HasChosenSub)
        {
            charSheet.CharAff.text = "Null";
            charSheet.CharSubC.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
