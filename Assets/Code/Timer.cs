using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timeLimit = 60.0f;
    
    bool stopTimer = false;

    void Start()
    {
        
    }

    void Update() {
        if (!stopTimer) {
            if (timeLimit > 0) {
                timeLimit -= Time.deltaTime;
            }
            else {
                timeLimit = 0.0f;
                PublicVars.timeEnd = true;
                stopTimer = true;
            }
        }
    }

    void TimerUICalc (float timeVal) {
        int minute = (int)(timeLimit/60.0f);
    }
}
