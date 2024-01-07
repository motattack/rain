using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public static InventoryItems instance;
    [SerializeField] private PickUpObject[] itemList;

    private void Awake()
    {
        instance = this;
        itemList = Resources.FindObjectsOfTypeAll<PickUpObject>();
        Debug.Log(itemList.Length);
    }

    public void Load(List<int> itemIdList)
    {
        Inventory.instance.ClearSlots();
        if (itemIdList != null)
        {
            for (int i = 0; i < itemIdList.Count; i++)
            {
                GameObject itemPrefabInstance = Instantiate(itemList[itemIdList[i]].itemObj);
                itemPrefabInstance.transform.position = Hero.instance.transform.position + new Vector3(0f, 1f, 0f);
            }
        }
    }

    public List<int> Save()
    {
        List<int> idItemList = new List<int>();

        for (int i = 0; i < itemList.Length; i++)
        {
            for (int j = 0; j < Inventory.instance._inventorySlots.Length; j++)
            {
                PickUpObject currentItem = itemList[i];

                if (currentItem == null || currentItem.item == null)
                {
                    Debug.LogError("PickUpObject or its item is null.");
                    continue;
                }
                
                if (Inventory.instance._inventorySlots[j]._item != null && Inventory.instance._inventorySlots[j]._item == currentItem.item)
                {
                    idItemList.Add(i);
                }
            }
        }

        return idItemList;
    }
}