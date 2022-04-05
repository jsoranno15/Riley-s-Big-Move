using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngerTimer : MonoBehaviour
{
    float timeLimit = 60.0f;
    bool stopTimer = false;

    public TextMeshProUGUI timerUI;

    void Update() {
        if (!stopTimer) {
            if (timeLimit > 0) {
                timeLimit -= Time.deltaTime;
                UpdateTimerUI(timeLimit);
            }
            else {
                timeLimit = 0.0f;
                PublicVars.timeEnd = true;
                stopTimer = true;
                UpdateTimerUI(timeLimit);
                timerUI.text = "Door Unlocked!";
            }
            
        }
    }

    void UpdateTimerUI (float timeVal) {
        int minutes = (int)(timeLimit / 60);
        int seconds = (int)(timeLimit % 60);
        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
