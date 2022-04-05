using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerEnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject spawn_1;
    public GameObject spawn_2;
    public GameObject spawn_3;
    public GameObject spawn_4;
    public GameObject spawn_5;
    
    GameObject spawnPoint;

    public static int enemyCount = 0;
    
    float spawnInterval = 1.0f;
    float timeCounter = 0.0f;

    private void Start() {
        spawnPoint = spawn_1;
    }

    private void Update() {
        timeCounter += Time.deltaTime;

        if (timeCounter >= spawnInterval && enemyCount < 20) {
            spawnPoint = selectSpawn();
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            enemyCount++;
            timeCounter = 0.0f;
        }
    }

    GameObject selectSpawn () {
        int spawn_num = Random.Range(1,5);
        switch (spawn_num) {
            case 1: return spawn_1;
            case 2: return spawn_2;
            case 3: return spawn_3;
            case 4: return spawn_4;
            case 5: return spawn_5;
            default: return spawn_1;
        }
    }
}
