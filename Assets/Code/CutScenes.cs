using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{
    public void IntroStory1() {
        SceneManager.LoadScene("IntroStory1");
    }
    public void IntroStory2() {
        SceneManager.LoadScene("IntroStory2");
    }

    public void AngerStory1() {
        SceneManager.LoadScene("AngerStory1");
    }
    public void AngerStory2() {
        SceneManager.LoadScene("AngerStory2");
    }
    public void AngerScene() {
        SceneManager.LoadScene("AngerScene");
    }

    
    public void AnxietyStory() {
        SceneManager.LoadScene("AnxietyHouse");
    }

    public void Exit() {
        Application.Quit();
    }
}
