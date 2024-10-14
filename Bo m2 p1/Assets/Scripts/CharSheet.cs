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
    private float timeelapsed;
    // Start is called before the first frame update
    void Start()
    {
        CharDmmg = CharEffects[0].gameObject.GetComponent<TMP_Text>();
        CharLevel = CharEffects[1].gameObject.GetComponent<TMP_Text>();
        CharAff = CharEffects[2].gameObject.GetComponent<TMP_Text>();
        CharSubC = CharEffects[3].gameObject.GetComponent<TMP_Text>();
    }

   public void CharacsheetDeletion()
    {
        gameObject.SetActive(false);    
    }
}
