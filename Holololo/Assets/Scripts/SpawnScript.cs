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

    public float ballSpawnDelay = 3;
    private float ballCounter;

    public float targetSpawnDelay = 6;
    private float targetCounter;

    public GameObject ballPrefab;
    public GameObject targetPrefab;

    // Use this for initialization
    void Start()
    {
        ballCounter = ballSpawnDelay;
        targetCounter = targetSpawnDelay;
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
        Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
        Debug.Log("Spawned, spawnPosition: " + spawnPosition.ToString());
        GameObject tmp = Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
        if(tmp.tag == "Target")
        {
            tmp.transform.LookAt(Camera.main.transform);
        }
    }
}
