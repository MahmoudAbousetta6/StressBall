using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Color Condation", menuName = "ScriptableObjects/Condation/Color", order = 1)]

public class ColorCondation : Condation
{
    public Color condationalColor;
    public Oprator oprator;

    public float targetRadius;
    private float tempRadius;

    override public bool ApplyCondation(ref float radius, ref Color color)
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

    private void OnEqualSelected(Color color) { if (color == condationalColor) tempRadius = targetRadius; }
}
