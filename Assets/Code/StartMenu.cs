using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("StartMenu");
    }

    public void LevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

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
