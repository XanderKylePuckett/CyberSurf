﻿using UnityEngine;
using TMPro;
public class AiOptions : LevelMenuObjectGroup
{
    [SerializeField] private LevelMenuButton plusButton = null, minusButton = null;
    [SerializeField] private TextMeshPro aiText = null;
    [SerializeField] private int defaultValue = 0;
    private int tempValue;
    private void OnEnable()
    {
        plusButton.OnButtonPressed += ButtonPlusFunction;
        minusButton.OnButtonPressed += ButtonMinusFunction;
    }
    private void OnDisable()
    {
        plusButton.OnButtonPressed -= ButtonPlusFunction;
        minusButton.OnButtonPressed -= ButtonMinusFunction;
    }
    public override void EnableGroup()
    {
        base.EnableGroup();
        plusButton.enabled = true;
        minusButton.enabled = true;
    }
    public override void DisableGroup()
    {
        base.DisableGroup();
        plusButton.enabled = false;
        minusButton.enabled = false;
    }
    private void ButtonPlusFunction()
    {
        if (tempValue < 1)
            ++tempValue;
        UpdateDisplay();
    }
    private void ButtonMinusFunction()
    {
        if (tempValue > 0)
            --tempValue;
        UpdateDisplay();
    }
    public override void ConfirmOptions()
    {
        base.ConfirmOptions();
        GameManager.AI_Number = tempValue;
    }
    public override void DefaultOptions()
    {
        base.DefaultOptions();
        tempValue = defaultValue;
        UpdateDisplay();
    }
    public override void ResetOptions()
    {
        base.ResetOptions();
        tempValue = GameManager.AI_Number;
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        aiText.SetText(tempValue.ToString());
    }
}