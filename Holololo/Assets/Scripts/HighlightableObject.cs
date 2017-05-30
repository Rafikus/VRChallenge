using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class HighlightableObject : MonoBehaviour, IFocusable
{
    private Material[] defaultMaterials;

    private void Start()
    {
        defaultMaterials = GetComponent<Renderer>().materials;
    }

    public void OnFocusEnter()
    {
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            // Highlight the material when gaze enters using the shader property.
            defaultMaterials[i].SetFloat("_Highlight", .5f);
            Debug.Log("Focus enter");
        }
    }
    public void OnFocusExit()
    {
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            // Remove highlight on material when gaze exits.
            defaultMaterials[i].SetFloat("_Highlight", 0f);
            Debug.Log("Focus exit");
        }
    }
}