using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private spawnscript spawner;

    void Start()
    {
        // Find the spawner in the scene (it should have the spawnscript)
        spawner = FindObjectOfType<spawnscript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Calculate position for the next platform (same X, Y, but Z ahead)
            float newZ = transform.parent.position.z + 100f; // platform length
            Vector3 newPos = new Vector3(0, 0, newZ); // adjust X if needed

            // Clone the current platform (including its child trigger)
            GameObject newPlatform = Instantiate(transform.parent.gameObject, newPos, Quaternion.identity);

            // Tell the spawner to put obstacles on the new platform
            if (spawner != null)
            {
                spawner.SpawnObstaclesOnPlatform(newPlatform, spawner.obstacleCount);
            }

            // Destroy the current platform after a short delay
            Destroy(transform.parent.gameObject, 20f);
        }
    }
}
