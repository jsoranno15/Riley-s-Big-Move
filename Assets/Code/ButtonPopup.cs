using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPopup : MonoBehaviour
{
    public List<GameObject> Notes;
    private string thisNote;
    private bool firstClick = true;

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(popupNote);
    }

    public void popupNote()
    {
        if (firstClick)
        {
            thisNote = PublicVars.currentNote;
            firstClick = false;
        }
        
        if (thisNote == "firstNote")
        {
            if(Notes[0] != null) 
            {
                bool isActive = Notes[0].activeSelf;
                Notes[0].SetActive(!isActive);
                PublicVars.noteChecked = true;
            }
        }
        else if (thisNote == "Flashlight")
        {
           if(Notes[1] != null) 
            {
                bool isActive = Notes[1].activeSelf;
                Notes[1].SetActive(!isActive);
                PublicVars.noteChecked = true;
            }
        }   
    }

    // IEnumerator mouseLeave()
    // {
    //     yield return new WaitForSeconds(2);
    //     Note.GetComponent<SetNotes>().enabled = true;
    // }
}
