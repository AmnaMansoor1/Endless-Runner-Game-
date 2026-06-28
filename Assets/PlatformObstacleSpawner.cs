using UnityEngine;

public class PlatformObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 5;
    public float yOffset = 2.5f;
    public float checkRadius = 0.7f;
    public LayerMask obstacleLayerMask = -1; // Will be set to ignore Platform layer

    void Start()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        float halfWidth = transform.localScale.x / 2;
        float minZ = transform.position.z - 40;
        float maxZ = transform.position.z - 10;

        for (int i = 0; i < obstacleCount; i++)
        {
            float SPx = Random.Range(transform.position.x - halfWidth, transform.position.x + halfWidth);
            float SPz = Random.Range(minZ, maxZ);
            Vector3 SP = new Vector3(SPx, transform.position.y + yOffset, SPz);

            // Check only layers NOT excluded (obstacleLayerMask should exclude Platform)
            if (!Physics.CheckSphere(SP, checkRadius, obstacleLayerMask))
            {
                Instantiate(obstaclePrefab, SP, Quaternion.identity);
            }
            else
            {
                Debug.Log("Position blocked: " + SP);
            }
        }
    }
}