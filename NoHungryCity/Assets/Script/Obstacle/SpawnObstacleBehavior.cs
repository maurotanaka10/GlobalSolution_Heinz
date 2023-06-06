using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleBehavior : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject carPrefab;

    [SerializeField] private float startDelay;
    [SerializeField] private float spawnInterval;

    private void Awake()
    {
        InvokeRepeating("SpawnCarObstacles", startDelay, spawnInterval);
    }

    private void SpawnCarObstacles()
    {
        int spawnPos = Random.Range(0, spawnPoints.Length);

        Instantiate(carPrefab, spawnPoints[spawnPos].position, spawnPoints[spawnPos].transform.rotation);
    }
}
