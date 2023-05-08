using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject store;
    public float nextTimeToSpawn = 0f;
    public float spawnRate = 700f;

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + 1500f/spawnRate;
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
