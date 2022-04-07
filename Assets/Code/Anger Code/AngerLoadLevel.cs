using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngerLoadLevel : MonoBehaviour
{
    public string levelToLoad = "SadHouse";
    
    private void OnCollisionEnter(Collision other) {
        if(AngerPublicVars.hasKey && other.gameObject.CompareTag("Player") && AngerPublicVars.gateUnlock) {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
