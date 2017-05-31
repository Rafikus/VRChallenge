using System;
using UnityEngine;
using UnityEngine.UI;

public class PointerCounter : MonoBehaviour {

    private Text pointsText;
    private Text timeText;
    private int points;

    public int Points
    {
        get { return points; }
        set
        {
            points = value;
            pointsText.text = points.ToString();
        }
    }

    // Use this for initialization
    void Start () {
        pointsText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        timeText = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        pointsText.text = "0";
    }
	
	// Update is called once per frame
	void Update () {
        TimeSpan t = TimeSpan.FromSeconds(UnityEngine.Time.time);
        timeText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
}
