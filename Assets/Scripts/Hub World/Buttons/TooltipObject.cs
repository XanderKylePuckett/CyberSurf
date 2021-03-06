﻿using UnityEngine;
using Xander.NullConversion;
public class TooltipObject : MonoBehaviour
{
    [SerializeField, LabelOverride("Parent")] private bool m_isParent = false;
    [SerializeField, LabelOverride("Disabled")] private bool m_isDisabled = false;
    [SerializeField, LabelOverride("Grab from Parent")] private bool m_grabTextFromParent = false;
    [Multiline, SerializeField] private string m_tooltipText = "";
    private void Awake()
    {
        if (m_grabTextFromParent)
        {
            TooltipObject[] theParents = GetComponentsInParent<TooltipObject>();
            if (theParents.Length > 1)
                m_tooltipText = theParents[1].m_tooltipText;
            else
                m_tooltipText = GetComponentInParent<SelectedObject>().ConvertNull()?.tooltipText ?? m_tooltipText;
        }
        if (m_isParent)
        {
            TooltipObject[] theChildren = GetComponentsInChildren<TooltipObject>();
            foreach (TooltipObject theChild in theChildren)
                if (theChild.m_grabTextFromParent)
                    theChild.m_tooltipText = m_tooltipText;
        }
        else
        {
            gameObject.layer = SelectedObject.Selectable_Layer;
            Collider theCollider = 0 != GetComponents<Collider>().Length ? GetComponent<Collider>() : gameObject.AddComponent<BoxCollider>();
            SelectedObject selectedObject = GetComponent<SelectedObject>();
            if (null == selectedObject)
            {
                selectedObject = gameObject.AddComponent<EventSelectedObject>();
                selectedObject.tooltipOnly = true;
                selectedObject.SetupTooltipOnly();
            }
            selectedObject.tooltipText = m_tooltipText;
            if (theCollider is MeshCollider)
                (theCollider as MeshCollider).convex = true;
            theCollider.isTrigger = true;
            if (m_isDisabled)
                selectedObject.enabled = false;
        }
        Destroy(this);
    }
}