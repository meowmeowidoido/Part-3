using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    
    public SpriteRenderer spriteRenderer;
    public Color start;
    public Color end;
    float interpolation;
 public void SliderHasChangedValue(Single value)
    {

        interpolation = value;
    }

    private void Update()
    {

        spriteRenderer.color=Color.Lerp(start, end, (interpolation/60));
    }
    public void DropDownHasChangedValue(Int32 value)
    {
        Debug.Log(dropdown.options[value].text);
    }
}
