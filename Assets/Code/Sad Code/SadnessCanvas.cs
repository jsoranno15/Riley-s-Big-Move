using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SadnessCanvas : MonoBehaviour
{
    public TextMeshProUGUI itemCounter;
    public TextMeshProUGUI objective;
    public TextMeshProUGUI note;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemCounter.text = "Items Found: " + SadPublicVars.itemCount + "/5";

        if (SadPublicVars.clicked){
            objective.text = "I really miss my mom...";
        }
        if (SadPublicVars.hasNecklace){
            note.text = "This was my mom's favorite necklace. She wore it the day she left. I wonder how it got here.";
        }

    }

    
   
 
}
