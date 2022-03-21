using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad = "Level1";
    
    private void OnCollisionEnter(Collision other){
        if(PublicVars.keyNum > 0 && other.gameObject.CompareTag("Player")){
            PublicVars.keyNum--;
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
