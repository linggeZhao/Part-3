using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer sr;
    public Color start;
    public Color end;
    float interpolation;
   public void SliderValueChanged(float value)
    {
        interpolation = value;
    }
    public void DropDownHasChanged(int value)
    {
        Debug.Log(dropdown.options[value]);
    }

    private void Update()
    {
        sr.color = Color.Lerp(start, end, (interpolation/60));
    }
}
