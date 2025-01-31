using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subclasses : MonoBehaviour
{
    public GameObject SubclassMenu;
    [SerializeField] private GameObject subclass1;
    [SerializeField] private GameObject subclass2;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private TowerExp exp;
    public Color normalColor = Color.black;
    public Color Sub1lightColor = Color.red;
    public CharSheet charSheet;
    public Color Sub2lightColor = Color.blue;
    private int subnumbering = 0;
    [SerializeField] private Color targetColor;
    [SerializeField] Transform SheetTransform;
    public float colorTransitionSpeed = 15f; 
    [SerializeField] private Towers towers;
    private SheetSpawn sheetSpawn;
    private Cash cash;

    void Start()
    {
        cash = FindAnyObjectByType<Cash>();
        exp = GetComponent<TowerExp>();
        sheetSpawn = GetComponentInChildren<SheetSpawn>();
        spriteRenderer = sheetSpawn.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            targetColor = normalColor;
            spriteRenderer.color = normalColor;
        }
    }

    public void MenuOpen()
    {
        if (exp.levels > 6 || cash.cash > 100000)
        {
            if (subnumbering == 0)
            {
                SubclassMenu = charSheet.SubCMenu;
                SubclassMenu.SetActive(true);
            } 
        }
    }

    public void MenuClose()
    {
        SubclassMenu.SetActive(false);
    }

    public void SubClass1()
    {
        Instantiate(subclass1, transform.position, Quaternion.identity);
        targetColor = Sub1lightColor;
        towers.selectedSubclass = SubclassType.FireMage;
        subnumbering = 1;
        MenuClose();
    }

    public void SubClass2()
    {
        Instantiate(subclass2, transform.position, Quaternion.identity);
        targetColor = Sub2lightColor;
        towers.selectedSubclass = SubclassType.IceMage;
        subnumbering = 2;
        MenuClose();
    }

    void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorTransitionSpeed * Time.deltaTime);
    }
}
