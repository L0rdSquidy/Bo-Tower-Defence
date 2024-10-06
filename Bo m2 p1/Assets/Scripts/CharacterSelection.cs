using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
public selectionSwitch Slitch;
public bool wizard = false;
public bool fighter = false;
public bool bard = false;
public bool druid = false;
public bool monk = false;


void Start()
{
    Slitch = FindObjectOfType<selectionSwitch>();
}

// Update is called once per frame
void Update()
{
    ResetClasses();
    if (Slitch.charlist[0]) wizard = true;
    if (Slitch.charlist[1]) druid = true;
    if (Slitch.charlist[2]) bard = true;
    if (Slitch.charlist[3]) fighter = true;
    if (Slitch.charlist[4]) monk = true;
}

void ResetClasses()
{
    wizard = false;
    fighter = false;
    bard = false;
    druid = false;
    monk = false;
}

}
