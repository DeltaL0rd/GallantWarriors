using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTimer : MonoBehaviour
{
    public Timer timer;

    private void OnEnable()
    {
        timer.timerIsRunning = false;
    }
}
