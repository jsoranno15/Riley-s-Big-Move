using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item: MonoBehaviour
{
    public enum ItemType
    {
        Key, // 0
        Note, // 1
        Flashlight, // 2
        Empty, //999
    }

    public ItemType itemType;
    public int amount;
    public int id;

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Key:
                return true;
            case ItemType.Flashlight:
            case ItemType.Note:
                return false;
        }
    }

    public static ItemType GetItemType(int identifier)
    {
        switch (identifier)
        {
            default:
            case 0: return ItemType.Key;
            case 1: return ItemType.Note;
            case 2: return ItemType.Flashlight;
            case 999: return ItemType.Empty;
        }
    }
}
