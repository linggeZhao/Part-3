using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Villager[] characters;
    public TMPro.TextMeshProUGUI currentSelection;
    public TMP_Dropdown dropdown;

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

    private void Update()
    {
        if(SelectedVillager != null)
        {
            currentSelection.text = SelectedVillager.GetType().ToString();
        }
    }

    public void DropDownHasChanged(int value)
    {
        SetSelectedVillager(characters[value]);
    }
}
