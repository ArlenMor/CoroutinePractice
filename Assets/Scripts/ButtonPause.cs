using System;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public event Action TimerPaused;

    public void OnClick()
    {
        TimerPaused?.Invoke();
    }
}