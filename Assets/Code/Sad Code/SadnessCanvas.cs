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

        if (SadPublicVars.clicked && SadPublicVars.objectIndex == 0){
            objective.text = "My childhood home... Where did my mom go...";
        }

        if (SadPublicVars.hasNecklace && SadPublicVars.objectIndex == 1){
            objective.text = "";
            note.text = "This was my mom's favorite necklace. I wish she didn't make us move away from here. I want to go home.";
        }


        if (SadPublicVars.clicked && SadPublicVars.objectIndex == 1){
            objective.text = "I wonder how the necklace got here. Maybe if I think about my dog she will appear too!";
            note.text = "";
        }

        if (SadPublicVars.hasDog  && SadPublicVars.objectIndex == 2){
            objective.text = "";
            note.text = "No! Luna why couldn't you stay longer. I missed you so much... Why am I here. Luna was my favorite part of this house.";
        }

        if (SadPublicVars.clicked && SadPublicVars.objectIndex == 2){
            objective.text = "This is all making me very sad. I wonder what else my mind wants me to see...";
            note.text = "";
        }

        if (SadPublicVars.hasBall  && SadPublicVars.objectIndex == 3){
            objective.text = "";
            note.text = "My old soccer ball. I miss my friends on the team. It will be so difficult making new friends... I'm too shy.";
        }

        if (SadPublicVars.clicked && SadPublicVars.objectIndex == 3){
            objective.text = "I feel like crying. I wish Teddy was here to comfort me...";
            note.text = "";
        }

        if (SadPublicVars.hasBall  && SadPublicVars.objectIndex == 4){
            objective.text = "";
            note.text = "Teddy! I knew you would never let me down. I should have never said I was too old to take you with me. I'm sorry Teddy.";
        }

        if (SadPublicVars.clicked && SadPublicVars.objectIndex == 4){
            objective.text = "I want to see my parents now. Let me think of a key and a door to get out of here.";
            note.text = "";
        }

        if (SadPublicVars.hasBear  && SadPublicVars.objectIndex == 5){
            objective.text = "";
            note.text = "I'm so happy I found the key! Let's get out of here Teddy.";
        }

    }

    
   
 
}
