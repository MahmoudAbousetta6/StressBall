using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stress Ball Data", menuName = "ScriptableObjects/StressBall/Data", order = 1)]
public class StressBallDataContainer : ScriptableObject
{
    public string size;
    public float radiusMinRange;
    public float radiusMaxRange;
    public float radiusStep;

    public List<ColorData> colors;
}

[System.Serializable]
public struct ColorData
{
    public string colorName;
    public Color color;
}