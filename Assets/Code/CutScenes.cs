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

    
    public void AnxietyStory1() {
        SceneManager.LoadScene("AnxietyStory1");
    }
    public void AnxietyStory2() {
        SceneManager.LoadScene("AnxietyStory2");
    }
    public void AnxietyScene() {
        SceneManager.LoadScene("AnxietyHouse");
    }

    public void SadStory1() {
        SceneManager.LoadScene("SadStory1");
    }
    public void SadStory2() {
        SceneManager.LoadScene("SadStory2");
    }
    public void SadScene() {
        SceneManager.LoadScene("SadHouse");
    }

    public void JoyStory1() {
        SceneManager.LoadScene("JoyStory1");
    }
    public void JoyStory2() {
        SceneManager.LoadScene("JoyStory2");
    }
    public void JoyScene() {
        SceneManager.LoadScene("JoyScene");
    }

    public void Exit() {
        Application.Quit();
    }
}
