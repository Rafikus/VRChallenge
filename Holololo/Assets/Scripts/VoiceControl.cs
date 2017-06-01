using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VoiceControl : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenu;

    public void stop()
    {
        Debug.Log("STOP!");
        Time.timeScale = 0;
        pauseMenu = Instantiate(pauseMenuPrefab);
    }

    public void start()
    {
        Debug.Log("START!");
        Time.timeScale = 1;
        if (pauseMenu != null)
            DestroyObject(pauseMenu);
    }
}
