using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private ButtonPlay _playBotton;
    [SerializeField] private ButtonPause _pauseBotton;
    [SerializeField, Min(0.5f)] private float _pause;
    [SerializeField, Min(1)] private float _increaseValue;

    private float _value = 0;

    private WaitForSeconds _delay;
    private Coroutine _changeValueCoroutine;

    public float Value => _value;
    public event Action TimeChanged;

    private void Awake()
    {
        _delay = new WaitForSeconds(_pause);
    }

    private void OnEnable()
    {
        _playBotton.TimerStarted += StartRunning;
        _pauseBotton.TimerPaused += StopRunning;
    }

    private void OnDisable()
    {
        _playBotton.TimerStarted -= StartRunning;
        _pauseBotton.TimerPaused -= StopRunning;
    }

    private void StartRunning()
    {
        _changeValueCoroutine = StartCoroutine(IncreaseTime());
    }

    private void StopRunning()
    {
        if (_changeValueCoroutine != null)
            StopCoroutine(_changeValueCoroutine);
    }

    private IEnumerator IncreaseTime()
    {
        while(true)
        {
            yield return _delay;
            _value += _increaseValue;
            TimeChanged?.Invoke();
        }
    }
}