using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attached to the antistress ball.
/// Apply conditions and the selected values to the antistress ball.
/// </summary>
public class StressBallHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private List<Condition> Conditions;

    private ColorData color;
    private float radius;

    private void Start()
    {
        UIHandler.Instance.OnDataChangeEvt += OnDataChange;
    }

    private void OnDataChange(float _radius, ColorData _color)
    {
        radius = _radius;
        color = _color;
        SetValues();
    }

    private void ApplyConations()
    {
        for (int i = 0; i < Conditions.Count; i++)
            if (Conditions[i].ApplyCondition(ref radius, ref color.color))
                break;
    }

    private void SetValues()
    {
        ApplyConations();
        mesh.material.color = color.color;
        transform.localScale = Vector3.one * radius;
    }
}