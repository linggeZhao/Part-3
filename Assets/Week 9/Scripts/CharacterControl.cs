using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public Villager[] characters;
    public TMPro.TextMeshProUGUI currentSelection;
    public TMP_Dropdown dropdown;
    public Slider slider;

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
        slider.value = SelectedVillager.transform.localScale.x;
    }

    public void SliderValueChanged(Single value)
    {
        SelectedVillager.size= value;   
        SelectedVillager.transform.localScale = Vector3.one * value;
    }
}
