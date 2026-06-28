using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject obstaclePrefab;    // Your obstacle prefab
    public GameObject initialPlatform;   // Assign the first platform in the Inspector (optional)
    public int obstacleCount = 5;
    void Start()
    {
        // If initialPlatform is assigned, spawn obstacles on it
        if (initialPlatform != null)
        {
            SpawnObstaclesOnPlatform(initialPlatform, obstacleCount);
        }
        else
        {
            // Otherwise, try to find a platform by tag
            GameObject platform = GameObject.FindGameObjectWithTag("Platform");
            if (platform != null)
                SpawnObstaclesOnPlatform(platform, obstacleCount);
        }
    }

    // Call this method whenever you want obstacles on a specific platform
    public void SpawnObstaclesOnPlatform(GameObject platform, int obstacleCount)
    {
        float halfWidth = platform.transform.localScale.x / 2;
        float halfLength = platform.transform.localScale.z / 2;  // use full length

        for (int i = 0; i < obstacleCount; i++)
        {
            float SPx = Random.Range(platform.transform.position.x - halfWidth, platform.transform.position.x + halfWidth);
            float SPz = Random.Range(platform.transform.position.z - halfLength, platform.transform.position.z + halfLength);
            Vector3 SP = new Vector3(SPx, 2.5f, SPz);

            if (!Physics.CheckSphere(SP, 0.7f))
            {
                Instantiate(obstaclePrefab, SP, Quaternion.identity);
            }
        }
    }
}
