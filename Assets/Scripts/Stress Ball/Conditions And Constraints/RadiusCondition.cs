using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object to handle the radius condition's constraints and result.
/// </summary>
[CreateAssetMenu(fileName = "Radius Condition", menuName = "ScriptableObjects/Condition/Rad", order = 2)]
public class RadiusCondition : Condition
{
    public float conditionalRadius;
    public Oprator oprator;

    public Color targetColor;
    private Color tempColor;

    override public bool ApplyCondition(ref float radius, ref Color color)
    {
        tempColor = color;
        switch (oprator)
        {
            case Oprator.Less:
                OnLessSelected(radius);
                break;
            case Oprator.Greater:
                OnGreaterSelected(radius);
                break;
            case Oprator.Equal:
                OnEqualSelected(radius);
                break;
        }
        bool isApplied = color != tempColor;
        color = tempColor;
        return isApplied;
    }

    private void OnLessSelected(float radius)
    {
        if (radius < conditionalRadius)
            tempColor = targetColor;
    }
    private void OnGreaterSelected(float radius)
    {
        if (radius > conditionalRadius)
            tempColor = targetColor;
    }

    private void OnEqualSelected(float radius)
    {
        if (radius == conditionalRadius)
            tempColor = targetColor;
    }
}