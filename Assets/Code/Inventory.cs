using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    private int i = 0;

    public Inventory()
    {
        itemList = new List<Item>(9);

        //AddItem(new Item { itemType = Item.ItemType.Key, amount = 1, id = 0 });
    }

    public void AddItem(Item item)
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Player");
        if (item.isStackable())
        {
            bool inInventory = false;
            foreach (Item storedItem in itemList)
            {
                if (storedItem.itemType == item.itemType)
                {
                    storedItem.amount += item.amount;
                    inInventory = true;
                }
            }
            if (!inInventory) { replaceEmpty(inventory, item); }
        } else { replaceEmpty(inventory, item); }
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void UseItem(int slot)
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Player");
        if (itemList[slot].amount > 1)
        {
            itemList[slot].amount -= 1;
        }
        else if (itemList[slot].amount == 1)
        {
            itemList[slot] = new Item {itemType = Item.ItemType.Empty, amount = 1, id = 999};
            inventory.GetComponent<InventoryLite>().slotExists[slot] = false;
        }
    }

    private void replaceEmpty(GameObject inventory, Item item)
    {
        bool empty = false;
        int place = 0;

        //find empty item if there is any
        for (int j = 0; j < itemList.Count; j++)
        {
            if (itemList[j].itemType == Item.ItemType.Empty)
            {
                empty = true;
                place = j;
                break;
            }
        }
        
        //add item to empty slot if any
        if (empty)
        {
            itemList[place] = item;
            inventory.GetComponent<InventoryLite>().slotExists[place] = true;
            i += 1;
        }
        else
        {
            if(itemList.Count < 8)
            {
                itemList.Add(item);
                inventory.GetComponent<InventoryLite>().slotExists[i] = true;
                i += 1;
            }
            else
            {
                Debug.Log("Cannot add item to Inventory! Inventory Full.");
            }
        }
        
    }
}

