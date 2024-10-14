using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public int cash = 600;
    [SerializeField] private TMP_Text cashText;
    public int switched;


    public void CashAdd(int AddedCash)
    {
        cash += AddedCash;
    }

    private void Update() 
    {
        cashText.text = "" + cash;
    }

}
