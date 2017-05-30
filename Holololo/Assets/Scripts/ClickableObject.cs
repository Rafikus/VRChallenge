using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickableObject : MonoBehaviour, IInputClickHandler, IFocusable
{
    public void OnFocusEnter()
    {
        Debug.Log("Focus enter");
    }

    public void OnFocusExit()
    {
        Debug.Log("Focus exit");
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Clicked");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
