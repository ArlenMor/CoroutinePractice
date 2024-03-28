using System;
using TMPro;
using UnityEngine;


public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Timer _timer;

    private void Start()
    {
        _timerText.text = _timer.Value.ToString("");
    }

    private void OnEnable()
    {
        _timer.TimeChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= UpdateValue;
    }

    private void UpdateValue()
    {
        _timerText.text = _timer.Value.ToString("");
    }
}