using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickableObject : MonoBehaviour, IInputClickHandler, IFocusable
{
    public void OnFocusEnter()
    {
    }

    public void OnFocusExit()
    {
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(tag == "Ball")
        {
            FindObjectOfType<Objects>().ball = gameObject;
            Debug.Log("Licked ball");
        }
        if(tag == "Target")
        {
            FindObjectOfType<Objects>().target = gameObject;
            Debug.Log("Clicked target");
        }
    }
}
