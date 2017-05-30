using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour {
    public float xMin = 0;
    public float xMax = 50;
    public float yMin = 0;
    public float yMax = 50;
    public float zMin = 0;
    public float zMax = 50;

    public float spawnDelay = 3;
    private float counter = 3;

    public GameObject prefabElement;
    // Use this for initialization
    void Start () {
        counter = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        counter -= Time.deltaTime;
        if(counter <= 0) {
            SpawnElement();
            counter = spawnDelay;
        }
	}

    public void SpawnElement() {
        Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
        Debug.Log("BallSpawned, spawnPosition: " + spawnPosition.ToString());
        Instantiate(prefabElement, spawnPosition, Quaternion.identity);
    }
}
