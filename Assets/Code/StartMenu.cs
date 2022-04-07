using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start Game Button
    public void StartGame() {
        SceneManager.LoadScene("IntroStory1");
    }

    // Instructions Button
    public void Instructions() {
        SceneManager.LoadScene("Instructions");
    }

    // Exit Game Button
    public void Exit() {
        Application.Quit();
    }
}
