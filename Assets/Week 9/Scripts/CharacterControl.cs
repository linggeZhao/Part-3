using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public TMP_Text selectionText;
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }

    void Update()
    {
        if (SelectedVillager != null)
        {
            selectionText.text = SelectedVillager.GetType().Name;
        }
        else
        {
            selectionText.text = "No Selection";
        }
    }
}
