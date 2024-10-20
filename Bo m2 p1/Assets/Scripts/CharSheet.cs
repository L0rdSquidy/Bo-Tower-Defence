using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharSheet : MonoBehaviour
{
    public TMP_Text CharDmmg;
    public TMP_Text CharLevel;
    public TMP_Text CharSubC;
    public TMP_Text CharAff;
    public List<GameObject> CharEffects;
    public Towers towers;
    public Transform TowerTransform;
    [SerializeField] private Subclasses SubMenus;
    public GameObject SubCMenu;
    private TowerExp towerExp;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        TowerTransform = towers.gameObject.transform;
        SubMenus = TowerTransform.GetComponent<Subclasses>();
        towerExp = TowerTransform.GetComponent<TowerExp>();
        SubMenus.charSheet = gameObject.GetComponent<CharSheet>();
        CharDmmg = CharEffects[0].gameObject.GetComponent<TMP_Text>();
        CharLevel = CharEffects[1].gameObject.GetComponent<TMP_Text>();
        CharAff = CharEffects[2].gameObject.GetComponent<TMP_Text>();
        CharSubC = CharEffects[3].gameObject.GetComponent<TMP_Text>();
        
        StartCoroutine(SetSubClassMenu());
    }

    IEnumerator SetSubClassMenu()
    {
        yield return new WaitForSeconds(0.1f);
        SubMenus.SubclassMenu = SubCMenu;
        Debug.Log(SubMenus.SubclassMenu);
    }

    private void Update() 
    {
        slider.maxValue = towerExp.expReq;
        slider.value = towerExp.exp;
    }
   public void CharacsheetDeletion()
    {
        gameObject.SetActive(false);    
    }
}
