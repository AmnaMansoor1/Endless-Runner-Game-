using UnityEngine;

public class ScoreTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ScoreTrigger entered by: " + other.name); // See who enters

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered score trigger – attempting to add score");
            Playerscript player = other.GetComponent<Playerscript>();
            if (player != null)
            {
                player.AddScore();
                Debug.Log("AddScore called successfully");
            }
            else
            {
                Debug.LogWarning("Player does not have Playerscript component!");
            }

            // Destroy the trigger so it only counts once
            Destroy(gameObject);
        }
    }
}