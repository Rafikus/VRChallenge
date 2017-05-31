using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public float maxHeight = 0.5f;
    public float minHeight = -0.5f;
    public float minBallSpawnRadius = 0.5f;
    public float maxBallSpawnRadius = 5.0f;
    public float minTargetSpawnRadius = 0.5f;
    public float maxTargetSpawnRadius = 5.0f;

    public float minBallRotationSpeed = 0.1f;
    public float maxBallRotationSpeed = 1.0f;

    public int maxBallCount = 40;
    public int maxTargetCount = 20;

    public float ballSpawnDelay = 3;
    private float ballCounter;

    public float targetSpawnDelay = 6;
    private float targetCounter;

    public GameObject ballPrefab;
    public GameObject targetPrefab;
    public GameObject arrowPrefab;

    public ArrayList balls;
    public ArrayList targets;

    private Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        ballCounter = ballSpawnDelay;
        targetCounter = targetSpawnDelay;
        balls = new ArrayList();
        targets = new ArrayList();

        GetComponent<BoxCollider>().transform.localScale = getBoundaries();

        //Spawning beggining targets and balls
        for (int i=0; i<maxTargetCount; i++)
        {
            SpawnElement(targetPrefab);
            SpawnElement(ballPrefab);
        }
    }

    private Vector3 getBoundaries()
    {
        float x = ((maxTargetSpawnRadius > maxBallSpawnRadius) ? maxTargetSpawnRadius : maxBallSpawnRadius) * 2 + 0.5f;
        float y = maxHeight * 2 + 0.5f;
        float z = x;
        return new Vector3(x, y, z);
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

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            balls.Remove(other.gameObject);
            DestroyObject(other.gameObject);
            SpawnElement(ballPrefab);
        }
        else if (other.tag == "Target")
        {
            targets.Remove(other.gameObject);
            DestroyObject(other.gameObject);
            SpawnElement(targetPrefab);
        }

    }
    public void SpawnElement(GameObject elementToSpawn)
    {
        if (balls.Count < maxBallCount && elementToSpawn.tag == "Ball")
        {
            Vector3 spawnPosition = this.transform.position + 
                new Vector3(
                    Random.Range(minBallSpawnRadius, maxBallSpawnRadius) * RandomSign(),
                    Random.Range(minHeight, maxHeight) * RandomSign(), 
                    Random.Range(minBallSpawnRadius, maxBallSpawnRadius) * RandomSign()
                )
            ;

            Debug.Log("Spawned, spawnPosition: " + spawnPosition.ToString());
            GameObject gameObject = Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3)), ForceMode.Force);
            gameObject.GetComponent<Rigidbody>().AddTorque(
                new Vector3(
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed),
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed),
                    Random.Range(minBallRotationSpeed, maxBallRotationSpeed)),
                ForceMode.Impulse
            );
            balls.Add(gameObject);
        }
        else if(targets.Count < maxTargetCount && elementToSpawn.tag == "Target")
        {
            Vector3 spawnPosition = this.transform.position +
                new Vector3(
                    Random.Range(minTargetSpawnRadius, maxTargetSpawnRadius) * RandomSign(),
                    Random.Range(minHeight, maxHeight) * RandomSign(),
                    Random.Range(minTargetSpawnRadius, maxTargetSpawnRadius) * RandomSign()
                )
            ;

            Debug.Log("Spawned, spawnPosition: " + spawnPosition.ToString());
            GameObject gameObject = Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
            gameObject.transform.LookAt(Camera.main.transform);
            gameObject.transform.Rotate(new Vector3(0f, 90f, 90f));
            targets.Add(gameObject);
        }
    }
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    private int RandomSign()
    {
        if (Random.value >= 0.5)
            return 1;
        else return -1;
    }
}
