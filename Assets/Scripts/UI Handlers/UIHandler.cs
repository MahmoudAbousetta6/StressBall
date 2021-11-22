using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System;

/// <summary>
/// Handles values selections.
/// Apply values to the dropdown menus on start the game based on the assigned values in antistress ball scriptable object.
/// Apply new values to the dropdown menus based on antistress ball size selection.
/// </summary>
public class UIHandler : MonoBehaviour
{
    private static UIHandler instance;

    [SerializeField] private List<StressBallDataContainer> stressBallContainer;
    [SerializeField] private TMP_Dropdown sizeDropdown;
    [SerializeField] private TMP_Dropdown radiusDropdown;
    [SerializeField] private TMP_Dropdown colorDropdown;

    private StressBallDataContainer currentSelectedBall;
    private float currentRadius;
    private ColorData currentColor;

    private Action<float, ColorData> onDataChangeEvt = null;

    public StressBallDataContainer CurrentSelectedBall { get => currentSelectedBall; set => currentSelectedBall = value; }
    public float CurrentRadius { get => currentRadius; private set { currentRadius = value; OnDataChange(); } }
    public ColorData CurrentColor { get => currentColor; private set { currentColor = value; OnDataChange(); } }
    public Action<float, ColorData> OnDataChangeEvt { get => onDataChangeEvt; set => onDataChangeEvt = value; }
    public static UIHandler Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        instance ??= this;
    }

    private void Start()
    {
        CreateSizeDropdown();
        CreateRadiusDropdown();
        CreateColorDropdown();

        sizeDropdown.onValueChanged.AddListener(SelectStressBall);
        radiusDropdown.onValueChanged.AddListener(SelectStressBallRadius);
        colorDropdown.onValueChanged.AddListener(SelectStressBallColor);
    }

    private void OnDataChange()
    {
        OnDataChangeEvt?.Invoke(CurrentRadius, CurrentColor);
    }

    private void CreateSizeDropdown()
    {
        sizeDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < stressBallContainer.Count; i++)
        {
            var dataOptions = new TMP_Dropdown.OptionData(stressBallContainer[i].size);
            options.Add(dataOptions);
        }

        sizeDropdown.AddOptions(options);
        CurrentSelectedBall = stressBallContainer[0];
    }

    private void CreateRadiusDropdown()
    {
        radiusDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        
        for (float i = CurrentSelectedBall.radiusMinRange; i <= CurrentSelectedBall.radiusMaxRange + 0.05f; i += CurrentSelectedBall.radiusStep)
        {
            var dataOptions = new TMP_Dropdown.OptionData(i.ToString("#.##"));
            options.Add(dataOptions);
        }

        radiusDropdown.AddOptions(options);
        CurrentRadius = CurrentSelectedBall.radiusMinRange;
    }

    private void CreateColorDropdown()
    {
        colorDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < CurrentSelectedBall.colors.Count; i++)
        {
            var dataOptions = new TMP_Dropdown.OptionData(CurrentSelectedBall.colors[i].colorName);
            options.Add(dataOptions);
        }

        colorDropdown.AddOptions(options);
        CurrentColor = CurrentSelectedBall.colors[0];
    }

    private void SelectStressBall(int value)
    {
        CurrentSelectedBall = stressBallContainer[value];
        CreateRadiusDropdown();
        CreateColorDropdown();
    }

    private void SelectStressBallRadius(int value)
    {
        CurrentRadius = CurrentSelectedBall.radiusMinRange + (CurrentSelectedBall.radiusStep * value);
    }

    private void SelectStressBallColor(int value)
    {
        CurrentColor = CurrentSelectedBall.colors[value];
    }
}