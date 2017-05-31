using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private GameObject target;
    private Vector3 targetVector;
    public int power = 20;

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
        targetVector = new Vector3((target.gameObject.transform.position.x - gameObject.transform.position.x) * power,
                                   (target.gameObject.transform.position.y - gameObject.transform.position.y) * power,
                                   (target.gameObject.transform.position.z - gameObject.transform.position.z) * power);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().AddForce(targetVector);

    }
    
}
