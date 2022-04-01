using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryLite : MonoBehaviour
{
    private Inventory inventory;
    public List<bool> slotExists;
    public List<GameObject> inventorySlots;
    private bool open = false;

    public GameObject inventoryDisplay;

    public static InventoryLite Instance { get; private set; }

    public void SetInventory(Inventory inventory) { this.inventory = inventory; }

    public void UpdateInventory(Inventory freshInventory) { this.inventory = freshInventory; }

    // Update is called once per frame
    void Update()
    {
        //Check if slots in the inventory are true or not.
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            if (slotExists[i] == true) 
            { 
                inventorySlots[i].SetActive(true);
                
                //Update info
                inventorySlots[i].transform.GetChild(0).GetComponent<Text>().text = inventory.GetItemList()[i].itemType.ToString(); //Pretty much changing the button name to match whats in there
                inventorySlots[i].transform.GetChild(1).GetComponent<Text>().text = inventory.GetItemList()[i].amount.ToString(); //Changing the amount to show the number of items in that slot.
            }
            else { inventorySlots[i].SetActive(false); }

            if (inventorySlots[i].transform.GetChild(0).GetComponent<Text>().text == "Key" && inventorySlots[i].transform.GetChild(1).GetComponent<Text>().text == "4")
            {
                //this.GetComponent<SimpleQuestExample>().objective.text = "You have obtained all the keys! Quest Complete!";
            }
        }

        if (Input.GetKeyDown(KeyCode.I) && !open) 
        { 
            inventoryDisplay.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined; //Cursor is opened and in game window
            open = true; 
        }
        else if (Input.GetKeyDown(KeyCode.I) && open) 
        { 
            inventoryDisplay.SetActive(false); 
            Cursor.lockState = CursorLockMode.Locked; //Cursor is locked.
            open = false; 
        }
    }
}