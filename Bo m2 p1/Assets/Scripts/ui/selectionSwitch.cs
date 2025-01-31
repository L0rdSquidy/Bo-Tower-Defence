using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionSwitch : MonoBehaviour
{
public List<GameObject> charlist;
public List<bool> selected;
public datamanager data;
public GameObject a;
public GameObject b;


void Start()
{
    data = FindObjectOfType<datamanager>();
    SetActiveCharacter();
}

private void OnMouseDown() 
{
    if (this.gameObject == a)
    {
        data.stitch = Mathf.Max(data.stitch - 1, 0);
    }
    if (this.gameObject == b)
    {
        data.stitch = Mathf.Min(data.stitch + 1, charlist.Count - 1); 
    }
    SetActiveCharacter(); 
}

void Update()
{
    SetActiveCharacter(); 
}

private void SetActiveCharacter()
{
    for (int i = 0; i < charlist.Count; i++)
    {
        selected[i] = (i == data.stitch);
        charlist[i].SetActive(i == data.stitch);  
    }
}
}