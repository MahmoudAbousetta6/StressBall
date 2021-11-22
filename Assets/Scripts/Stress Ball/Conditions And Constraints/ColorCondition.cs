using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object to handle the color condition's constraints and result.
/// </summary>
[CreateAssetMenu(fileName = "Color Condition", menuName = "ScriptableObjects/Condition/Color", order = 1)]
public class ColorCondition : Condition
{
    public Color ConditionalColor;
    public Oprator oprator;

    public float targetRadius;
    private float tempRadius;

    override public bool ApplyCondition(ref float radius, ref Color color)
    {
        tempRadius = radius;
        switch (oprator)
        {
            case Oprator.Equal:
                OnEqualSelected(color);
                break;
        }
        bool isApplied = radius != tempRadius;
        radius = tempRadius;
        return isApplied;
    }

    private void OnEqualSelected(Color color)
    {
        if (color == ConditionalColor)
            tempRadius = targetRadius;
    }
}