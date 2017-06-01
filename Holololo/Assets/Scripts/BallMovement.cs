using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private GameObject target;
    private Vector3 targetVector;
    private PointerCounter counter;
    public int power = 20;
    public float minBallRotationSpeed = 0.1f;
    public float maxBallRotationSpeed = 1.0f;

    void Start()
    {
        counter = FindObjectOfType<PointerCounter>();
    }

    void Update () {
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.tag == "Target")
        {
            counter.Points++;
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();
            StartCoroutine(DestroyTarget(collision.gameObject, 0.2f));
            StartCoroutine(DestroyTarget(gameObject, 0.2f));
            
        }
        if(collision.transform.tag == "Ball")
        {
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(gameObject.transform.position.x + collision.gameObject.transform.position.x,
                                                                                      gameObject.transform.position.y + collision.gameObject.transform.position.y,
                                                                                      gameObject.transform.position.z + collision.gameObject.transform.position.z) / 2, 1f);
            Debug.Log("Balls Collided");
        }
    }

    public void setTarget(GameObject g)
    {
        target = g;
        targetVector = new Vector3(target.gameObject.transform.position.x - gameObject.transform.position.x,
                                   target.gameObject.transform.position.y - gameObject.transform.position.y,
                                   target.gameObject.transform.position.z - gameObject.transform.position.z);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().AddForce(targetVector.normalized * power);
        gameObject.GetComponent<Rigidbody>().AddTorque(
                new Vector3(
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed),
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed),
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed)
                ),
                ForceMode.Impulse
            );
    }

    IEnumerator DestroyTarget(GameObject gO, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        Destroy(gO);
    }
    
}
