using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorLoad : MonoBehaviour
{
    public string levelToLoad = "Street";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { SceneManager.LoadScene(levelToLoad); }
    }
}
