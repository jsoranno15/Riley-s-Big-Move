using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngerTimer : MonoBehaviour
{
    float timeLimit = 180.0f;
    bool stopTimer = true;

    public TextMeshProUGUI timerUI;

    AudioSource _audioSource;
    public AudioClip timesUp;

    private void Start() {
        StartCoroutine(StartTimer());
        _audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (!stopTimer) {
            if (timeLimit > 0) {
                timeLimit -= Time.deltaTime;
                UpdateTimerUI(timeLimit);
            }
            else {
                timeLimit = 0.0f;
                if(!AngerPublicVars.gateUnlock) {
                    _audioSource.PlayOneShot(timesUp);
                }
                AngerPublicVars.gateUnlock = true;
                stopTimer = true;
                UpdateTimerUI(timeLimit);
            }
            
        }
    }

    IEnumerator StartTimer() {    
        while(true) {
            yield return new WaitForSeconds(0.5f);
            if (AngerPublicVars.gameRun == true) {
                stopTimer = false;
            }
            else {
                stopTimer = true;
            }
        }
    }

    void UpdateTimerUI(float timeVal) {
        int minutes = (int)(timeLimit / 60);
        int seconds = (int)(timeLimit % 60);
        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
