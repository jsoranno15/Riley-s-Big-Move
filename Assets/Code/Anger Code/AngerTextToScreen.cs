using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngerTextToScreen : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public TextMeshProUGUI missionUI;

    string storyText = "Ahhh! I can’t believe this is actually happening to me. My parents are so mean.\nThey just wake up one day and decide to move to a whole new town. So unfair!!";

    string missionText = "Help Riley release her anger and deal with her negative thoughts about this unfamiliar town.\nFind the key to the gate and survive until the timer runs out.";

    void Start()
    {
        //StartCoroutine(printText(missionText));
        AngerPublicVars.gameRun = true;
    }

    private void Update() {
        if(AngerPublicVars.gameRun) {
            if (!AngerPublicVars.hasKey) {
                missionUI.text = "Find the key";
            }
            else if (!AngerPublicVars.gateUnlock) {
                missionUI.text = "Survive and find the gate";
            }
            else {
                missionUI.text = "Find the gate";
            }
        }
    }

    IEnumerator printText (string text) {
        foreach (char c in text) {
            textUI.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3.0f);
        textUI.text = "";
        AngerPublicVars.gameRun = true;
    }
}
