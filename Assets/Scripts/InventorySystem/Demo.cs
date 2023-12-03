using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("item added");
        }
        else
        {
            Debug.Log("item not added");
        }
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);

        if (receivedItem != null)
        {
            Debug.Log("received");
        }
        else
        {
            Debug.Log("not received");
        }
    }
    
    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);

        if (receivedItem != null)
        {
            Debug.Log("used");
        }
        else
        {
            Debug.Log("not uses");
        }
    }
}
