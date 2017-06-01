using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Highlighting : MonoBehaviour, IFocusable, IInputClickHandler
{
    private Renderer render;
    public Shader illuminate;
    public Shader standard;
    public GameObject ball, target;
    private Objects objects;

    void Start ()
    {
        objects = FindObjectOfType<Objects>();
        render = transform.GetChild(0).GetComponent<Renderer>();
    }

    public void OnFocusEnter()
    {
        shaderSet(render, illuminate);
    }

    public void OnFocusExit()
    {
        if (!objects.ball == this.gameObject && !objects.target == this.gameObject)
            shaderSet(render, standard);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(tag == "Ball")
        {
            if (objects.ball != null)
                shaderSet(objects.ball.transform.GetChild(0).GetComponent<Renderer>(), standard);
            shaderSet(this.transform.GetChild(0).GetComponent<Renderer>(), illuminate);
        }
        else if(tag == "Target")
        {
            if (objects.target != null)
                shaderSet(objects.ball.transform.GetChild(0).GetComponent<Renderer>(), standard);
            shaderSet(this.transform.GetChild(0).GetComponent<Renderer>(), illuminate);
        }
    }

    private void shaderSet(Renderer render, Shader shader)
    {
        if (render.materials[1] != null)
            render.materials[1].shader = shader;
        render.materials[0].shader = shader;
    }
}
