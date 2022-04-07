using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadJoyLevel : MonoBehaviour
{
    public string levelToLoad;
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
