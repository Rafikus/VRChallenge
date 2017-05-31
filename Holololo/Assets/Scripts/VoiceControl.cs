using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VoiceControl : MonoBehaviour, ISpeechHandler
{
    public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
    {
        switch (eventData.RecognizedText.ToLower())
        {
            case "stop":
                Debug.Log("STOP!");
                Time.timeScale = 0;
                break;
            case "start":
                Debug.Log("START!");
                Time.timeScale = 1;
                break;
        }
    }
}
