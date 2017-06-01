using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Highlighting : MonoBehaviour, IFocusable
{
    private Renderer render;
    public Shader illuminate;
    public Shader standard;
    
    void Start ()
    {
        render = gameObject.transform.GetChild(0).GetComponent<Renderer>();
    }

    public void OnFocusEnter()
    {
        if (render.materials[1] != null)
            render.materials[1].shader = illuminate;
        render.materials[0].shader = illuminate;
    }

    public void OnFocusExit()
    {
        if (render.materials[1] != null)
            render.materials[1].shader = standard;
        render.materials[0].shader = standard;
    }
}
