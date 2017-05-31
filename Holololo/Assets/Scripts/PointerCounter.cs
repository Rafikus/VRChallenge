using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointerCounter : MonoBehaviour {

    private Text text;
    private int points;

    public int Points
    {
        get { return points; }
        set
        {
            points = value;
            text.text = points.ToString();
        }
    }


    // Use this for initialization
    void Start () {
        text = gameObject.GetComponent<Text>();
        text.text = "0";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
