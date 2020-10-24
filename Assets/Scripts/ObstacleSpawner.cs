using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public int gridXLength;
    public int gridZLength;
    public float gridOffset;
    public Vector3 gridStartPoint = Vector3.zero;

    void Start()
    {
        SpawnGridObstacle();
    }

    void SpawnGridObstacle()
    {
        for (int x = 0; x < gridXLength; x++)
        {
            for (int z = 0; z < gridZLength; z++)
            {
                int randomIndex = Random.Range(0, obstacles.Length);
                Vector3 jitter = new Vector3(Random.Range(-4, 4), 0.0f, Random.Range(-4, 4));
                Vector3 spawnPos = new Vector3(x * gridOffset + jitter.x, 0.0f, z * gridOffset + jitter.z) + gridStartPoint;
                float randomDirection = Random.Range(0.0f, 360.0f);
                GameObject clone = Instantiate(obstacles[randomIndex], spawnPos, Quaternion.Euler(transform.rotation.x, randomDirection, transform.rotation.z));
            }
        }
    }
}
