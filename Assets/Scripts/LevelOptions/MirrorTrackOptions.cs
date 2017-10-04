﻿using UnityEngine;
public class MirrorTrackOptions : LevelMenuObjectGroup
{
    [SerializeField]
    private LevelMenuButton onButton = null, offButton = null;
    new private void Start()
    {
        base.Start();
        if (null == onButton)
            Debug.LogWarning("Missing MirrorTrackOptions.onButton");
        if (null == offButton)
            Debug.LogWarning("Missing MirrorTrackOptions.offButton");
    }
    new private void OnEnable()
    {
        base.OnEnable();
        onButton.OnButtonPressed += ButtonOnFunction;
        offButton.OnButtonPressed += ButtonOffFunction;
    }
    private void OnDisable()
    {
        onButton.OnButtonPressed -= ButtonOnFunction;
        offButton.OnButtonPressed -= ButtonOffFunction;
    }
    public override void EnableGroup()
    {
        base.EnableGroup();
        onButton.enabled = true;
        offButton.enabled = true;
    }
    public override void DisableGroup()
    {
        base.DisableGroup();
        onButton.enabled = false;
        offButton.enabled = false;
    }
    private void ButtonOnFunction()
    {
    }
    private void ButtonOffFunction()
    {
    }
}