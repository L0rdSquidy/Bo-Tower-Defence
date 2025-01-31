using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetSpawn : MonoBehaviour
{
    [SerializeField] private CharSheet charSheet;
    [SerializeField] private TowerExp expMultiplier;
    [SerializeField] private Towers towerScript;
    public GameObject CharacterSheet;
    [SerializeField] private GameObject CanvasObject;
    private GameObject SUBmenu;
    private Canvas canvas;
    [SerializeField] private Subclasses SubC;
    public GameObject Charasheet;
    public bool SheetIsActive;
    private int SheetSpawned = 0;
    [SerializeField] private Transform TowerTransform;
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindAnyObjectByType<Canvas>();
        CanvasObject = canvas.gameObject;
        TowerTransform = gameObject.transform.parent.transform;
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
            charSheet.towers = TowerTransform.GetComponent<Towers>();
            // SubC.SubclassMenu = SUBmenu;
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
        Debug.Log("hello?");
        yield return new WaitForSeconds(0.2f);
        charSheet.CharDmmg.text = "" + towerScript.TotalDmmg;
        charSheet.CharLevel.text = "" + towerScript.TotalLvL;
        Debug.Log(towerScript.TotalLvL);
        if (!towerScript.HasChosenSub)
        {
            charSheet.CharAff.text = "Null";
            charSheet.CharSubC.text = "";
        }
    }
}
