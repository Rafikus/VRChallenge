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
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void setTarget(GameObject g)
    {
        target = g;
        targetVector = new Vector3((target.gameObject.transform.position.x - gameObject.transform.position.x) * 20,
                                   (target.gameObject.transform.position.y - gameObject.transform.position.y) * 20,
                                   (target.gameObject.transform.position.z - gameObject.transform.position.z) * 20);
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().AddForce(targetVector);

    }
    
}
