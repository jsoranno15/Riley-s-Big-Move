using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AngerEnemyCode : MonoBehaviour
{
    // Player Tracking
    NavMeshAgent _navAgent;
    GameObject player;

    public AudioSource _audioSource;
    public AudioClip death;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
        _navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer() {
        while(true) {
            yield return new WaitForSeconds(1.5f);
            _navAgent.destination = player.transform.position;
        }
    }

    private void OnCollisionEnter(Collision other){
        // Enemy Death
        if(other.gameObject.CompareTag("Bullet")){
            StartCoroutine(deathSound());
            Destroy(other.gameObject);
            AngerEnemySpawn.enemyCount--;
            Destroy(gameObject);
        }
    }

    IEnumerator deathSound() {
        _audioSource.Play();
        yield return new WaitForSeconds(.01f);
    }
}