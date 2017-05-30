using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private GameObject target;
    private Vector3 targetVector;

    void Start()
    {
    }

    void Update () {
		if(target != null)
        {
            gameObject.transform.position += targetVector * Time.deltaTime * 0.2f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Target")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void setTarget(GameObject g)
    {
        target = g;
        targetVector = new Vector3(target.gameObject.transform.position.x - gameObject.transform.position.x,
                                   target.gameObject.transform.position.y - gameObject.transform.position.y,
                                   target.gameObject.transform.position.z - gameObject.transform.position.z);
        Debug.Log("Target: " + target.transform.position.ToString());
        Debug.Log("This: " + gameObject.transform.position.ToString());
    }
    
}
