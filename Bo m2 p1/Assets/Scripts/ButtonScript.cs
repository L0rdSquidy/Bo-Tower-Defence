using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public Button NonoButton;
    public Button SubButton1;
    public Button SubButton2;
    private Transform ParentTransform;
    private Transform towerTransform;
    [SerializeField] private CharSheet charSheet;
    private Subclasses subclasses;
    // Start is called before the first frame update
    void Start()
    {
        ParentTransform = gameObject.transform.parent.transform;
        charSheet = ParentTransform.GetComponent<CharSheet>();
        towerTransform = charSheet.TowerTransform;
        subclasses = towerTransform.GetComponent<Subclasses>();
        button.onClick.AddListener(subclasses.MenuOpen);
        NonoButton.onClick.AddListener(subclasses.MenuClose);
        SubButton1.onClick.AddListener(subclasses.SubClass1);
        SubButton2.onClick.AddListener(subclasses.SubClass2);
    }

}
