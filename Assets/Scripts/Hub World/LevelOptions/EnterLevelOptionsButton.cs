﻿using UnityEngine;
public class EnterLevelOptionsButton : SelectedObject
{
    [SerializeField] private LevelMenuStuff levelMenuScript = null;
    [SerializeField, Tooltip("degrees per second")] private float rotationSpeed = 111.0f;
    [SerializeField] private Material hoverMat = null, noHoverMat = null;
    private MeshRenderer meshRenderer = null;
    new private void Start()
    {
        base.Start();
        meshRenderer = GetComponent<MeshRenderer>();
        if (null == levelMenuScript)
            levelMenuScript = GetComponentInParent<LevelMenuStuff>();
        if (null == noHoverMat)
            noHoverMat = meshRenderer.material;
        if (null == hoverMat)
            hoverMat = noHoverMat;
        meshRenderer.material = noHoverMat;
    }
    new private void Update()
    {
        base.Update();
        transform.Rotate(0.0f, Time.deltaTime * rotationSpeed, 0.0f);
    }
    protected override void SelectedFunction() => meshRenderer.material = hoverMat;
    protected override void DeselectedFunction() => meshRenderer.material = noHoverMat;
    protected override void SuccessFunction() => levelMenuScript.EnterMenu();
}