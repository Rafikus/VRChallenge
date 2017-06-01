using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickableObject : MonoBehaviour, IInputClickHandler, IFocusable
{
    private GameObject cursor;
    private Objects objects;
    private Renderer render;
    private Shader illuminate;
    private Shader standard;

    public void Start()
    {
        objects = FindObjectOfType<Objects>();
        cursor = GameObject.Find("DefaultCursor").gameObject;
        render = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        illuminate = Shader.Find("Self-Illumin/Outlined Diffuse");
        standard = Shader.Find("Standard");
    }

    public void OnFocusEnter()
    {
        if(render.materials[1] != null)
            render.materials[1].shader = illuminate;
        render.materials[0].shader = illuminate;
    }

    public void OnFocusExit()
    {
        if (render.materials[1] != null)
            render.materials[1].shader = standard;
        render.materials[0].shader = standard;
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
