﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionAF : MonoBehaviour
{
    private Dropdown dropDown;
    [HideInInspector] public int _afValue;

    void Awake()
    {
        dropDown = GetComponent<Dropdown>();
        dropDown.value = _afValue;
    }

    public void AFChanged (int value)
    {
        _afValue = value;

        //Disabled
        if (value == 0)
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;

        //Enabled
        else if (value == 1)
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;

        //Force Enable
        else if (value == 2)
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
    }
}