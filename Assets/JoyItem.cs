using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyItem : MonoBehaviour
{
    public string Description;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag=="Player")
        {
            FindObjectOfType<ItemHandler>().UpdateItemScore(this.gameObject);
        }
    }
}
