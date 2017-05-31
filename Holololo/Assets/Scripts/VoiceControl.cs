using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VoiceControl : MonoBehaviour
{
    public void stop()
    {
        Debug.Log("STOP!");
        Time.timeScale = 0;
    }

    public void start()
    {
        Debug.Log("START!");
        Time.timeScale = 1;
    }
}
