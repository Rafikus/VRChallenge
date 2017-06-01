using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickableObject : MonoBehaviour, IInputClickHandler
{
    private GameObject cursor;
    private Objects objects;

    public void Start()
    {
        objects = FindObjectOfType<Objects>();
        cursor = GameObject.Find("DefaultCursor").gameObject;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(tag == "Ball")
        {
            if (objects.ball != null && objects.target == null)
            {
                objects.target = gameObject;
            }
            else
            {
                objects.ball = gameObject;
            }
            Debug.Log("Licked ball");
        }
        else if(tag == "Target")
        {
            objects.target = gameObject;
            Debug.Log("Clicked target");
        }
        else
        {
            GameObject point = new GameObject();
            point.transform.position = cursor.transform.position;
            objects.target = point;
        }
    }
}
