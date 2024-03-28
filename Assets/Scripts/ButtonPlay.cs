using System;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public event Action TimerStarted;

    public void OnClick()
    {
        TimerStarted?.Invoke();
    }
}
