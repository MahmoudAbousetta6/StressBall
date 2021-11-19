using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBallHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private List<Condation> condations;

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
        for (int i = 0; i < condations.Count; i++)
            if (condations[i].ApplyCondation(ref radius, ref color.color))
                break;
    }

    private void SetValues()
    {
        ApplyConations();
        mesh.material.color = color.color;
        transform.localScale = Vector3.one * radius;
    }
}