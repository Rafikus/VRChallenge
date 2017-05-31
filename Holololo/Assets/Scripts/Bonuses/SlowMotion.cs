using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = .6f;
	}

    void OnDestroy()
    {
        Time.timeScale = 1f;
    }

}
