using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public float xMin = 0;
    public float xMax = 50;
    public float yMin = 0;
    public float yMax = 50;
    public float zMin = 0;
    public float zMax = 50;
    public float minBallRotationSpeed = 0.1f;
    public float maxBallRotationSpeed = 1.0f;

    public int maxBallCount = 4;
    public int maxTargetCount = 4;

    public float ballSpawnDelay = 3;
    private float ballCounter;

    public float targetSpawnDelay = 6;
    private float targetCounter;

    public GameObject ballPrefab;
    public GameObject targetPrefab;
    public GameObject arrowPrefab;

    public ArrayList balls;
    public ArrayList targets;

    // Use this for initialization
    void Start()
    {
        ballCounter = ballSpawnDelay;
        targetCounter = targetSpawnDelay;
        balls = new ArrayList();
        targets = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        ballCounter -= Time.deltaTime;
        targetCounter -= Time.deltaTime;
        if (ballCounter <= 0)
        {
            SpawnElement(ballPrefab);
            ballCounter = ballSpawnDelay;
        }
        if (targetCounter <= 0)
        {
            SpawnElement(targetPrefab);
            targetCounter = targetSpawnDelay;
        }
    }

    public void SpawnElement(GameObject elementToSpawn)
    {
        if (balls.Count < maxBallCount && elementToSpawn.tag == "Ball")
        {
            Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            Debug.Log("Spawned, spawnPosition: " + spawnPosition.ToString());
            GameObject tmp = Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
            tmp.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3)), ForceMode.Force);
            tmp.GetComponent<Rigidbody>().AddTorque(
                new Vector3(
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed),
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed),
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed)),
                ForceMode.Impulse
            );
            balls.Add(tmp);
        }
        else if(targets.Count < maxTargetCount && elementToSpawn.tag == "Target")
        {
            Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            Debug.Log("Spawned, spawnPosition: " + spawnPosition.ToString());
            GameObject tmp = Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
            tmp.transform.LookAt(Camera.main.transform);
            tmp.transform.Rotate(new Vector3(0f, 90f, 90f));
            targets.Add(tmp);
        }
    }
}
