using System.Collection;
using System.Collection.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    public GameObject powerupPrefab;
    public GameObject enemiesPrefab;
    // will turn this into an array to have multiple items for cover
    public GameObject coverPrefab;


    void Start() {
        // powerup should spawn on start
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update() {

        // spawns enemy by pressing E, runs SpawnEnemy method, may be temporary as enemies will spawn on timer or waves
        if(Input.GetKeyDown(KeyCode.E)) {
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        Vector3 spawnPos = GenerateSpawnPosition();

        Instantiate(enemiesPrefab, spawnPos, enemiesPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        // generates random spawn pos in gameworld, can be used for enemies and powerups
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}