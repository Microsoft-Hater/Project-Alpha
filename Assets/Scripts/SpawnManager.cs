// B00160560
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    // public GameObject powerupPrefab;
    public GameObject enemiesPrefab;
    // will turn this into an array to have multiple items for cover
    // public GameObject coverPrefab;
    public int enemyAlive;
    public int waveNum = 1;


    void Start() {

        SpawnEnemy(waveNum);
        // powerup should spawn on start
        // Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update() {

        // FOR TESTING, TURN OFF WHEN ALPHA IS DONE
        // spawns enemy by pressing E, runs SpawnEnemy method, may be temporary as enemies will spawn on timer or waves
        if(Input.GetKeyDown(KeyCode.E)) {
            SpawnEnemy(1);
        }

        // enemyAlive checks if there are any enemies alive, if not, it will spawn a new wave of enemies
        enemyAlive = FindObjectsOfType<Enemy>().Length;
        if(enemyAlive == 0) {
            waveNum++;
            // after every wave, 3 more enemies will spawn
            SpawnEnemy(waveNum+3);
        }
    }

    // method that spawns enemies at a random position
    void SpawnEnemy(int enemiesToSpawn) {
                // for loop to spawn multiple enemies at once
                for(int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemiesPrefab, GenerateSpawnPosition(), enemiesPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // generates random spawn pos in gameworld, can be used for enemies and powerups
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }
}
