using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmartPhoneController : MonoBehaviour
{
    [Header("Battery Level")]
    [SerializeField] private float _batteryStartValue;
    [SerializeField] private Slider _batteryLevelSlider;
    [SerializeField] private TMP_Text _barretyPercTextValue;

    [Header("Mobile Phone Time")]
    [SerializeField] private int _startHours;
    [SerializeField] private int _startMinutes;
    [SerializeField] private TMP_Text _hoursTextUI;
    [SerializeField] private TMP_Text _minutesTextUI;

    private void Start()
    {
        BatteryLevelSlider(_batteryStartValue);
        _batteryLevelSlider.value = _batteryStartValue;
        
        UpdateSystemTime();
        InvokeRepeating("UpdateSystemTime", 0f, 1f);
    }

    private void UpdateSystemTime()
    {
        DateTime currentTime = DateTime.Now;
        
        _hoursTextUI.text = currentTime.Hour.ToString("00");
        _minutesTextUI.text = currentTime.Minute.ToString("00");
    }

    public void BatteryLevelSlider(float batteryLevel)
    {
        _barretyPercTextValue.text = batteryLevel.ToString("0");
    }
}