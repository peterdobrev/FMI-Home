using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The GameObject to spawn
    public List<Transform> spawnPoints; // List of possible spawn points

    // Call this function to spawn the object at a random spawn point
    public void SpawnRandom()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Object to spawn is not set.");
            return;
        }

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Spawn points are not set.");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        objectToSpawn.transform.position = spawnPoint.position;
        objectToSpawn.SetActive(true);
    }
}
