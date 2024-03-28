using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Button _playBotton;
    [SerializeField] private Button _pauseBotton;
    [SerializeField, Min(0.5f)] private float _delaySerialize = 0.5f;
    [SerializeField, Min(1)] private float _increaseValue = 1;

    private float _value = 0;

    private WaitForSeconds _delay;
    private Coroutine _changeValueCoroutine;

    public float Value => _value;
    public event Action TimeChanged;

    private void Awake()
    {
        _delay = new WaitForSeconds(_delaySerialize);
    }

    private void OnEnable()
    {
        _playBotton.onClick.AddListener(StartRunning);
        _pauseBotton.onClick.AddListener(StopRunning);
    }

    private void OnDisable()
    {
        _playBotton.onClick.RemoveListener(StartRunning);
        _pauseBotton.onClick.RemoveListener(StopRunning);
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
        while(enabled)
        {
            yield return _delay;
            _value += _increaseValue;
            TimeChanged?.Invoke();
        }
    }
}