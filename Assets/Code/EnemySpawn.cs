using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public static int enemyCount = 0;
    
    float spawnInterval = 1.0f;
    float timeCounter = 0.0f;

    private void Update() {
        timeCounter += Time.deltaTime;

        if (timeCounter >= spawnInterval && enemyCount < 10) {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            enemyCount++;
            timeCounter = 0.0f;
        }
    }
}
