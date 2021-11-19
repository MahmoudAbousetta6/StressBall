using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Oprator { Less, Greater, Equal }


[CreateAssetMenu(fileName = "Radius Condation", menuName = "ScriptableObjects/Condation/Rad", order = 1)]
public class RadiusCondation : Condation
{
    public float condationalRad;
    public Oprator oprator;

    public Color targetColor;
    private Color tempColor;

   override public bool ApplyCondation(ref float radius, ref Color color) 
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

    private void OnLessSelected(float radius) {
        if (radius < condationalRad) tempColor = targetColor;
    }
    private void OnGreaterSelected(float radius) { if (radius > condationalRad) tempColor = targetColor; }

    private void OnEqualSelected(float radius) { if (radius == condationalRad) tempColor = targetColor; }
}
