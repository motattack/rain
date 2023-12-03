using System.Collections.Generic;
using UnityEngine;

public class DB : MonoBehaviour
{
    public static List<Item> Items = new List<Item>();
    public static int Lvl;
    public static float LvlProgress;
    public static float[] ExpMultiplier = new float[8];
    public static List<List<Item>> CurrentOrders = new List<List<Item>>();
    public static int Money;

    private void Start()
    {
        CurrentOrders.Add(new List<Item>());
        CurrentOrders.Add(new List<Item>());
        
        // Storage.ClearDataBase();
        Items = Storage.LoadInventory();

        var playerData = Storage.LoadPlayerData();
        Money = playerData.money;
        LvlProgress = playerData.lvlProgress;
        Lvl = playerData.lvl;

        ExpMultiplier[1] = 0.04f;
        ExpMultiplier[2] = 0.03f;
        ExpMultiplier[3] = 0.03f;
        ExpMultiplier[4] = 0.02f;
        ExpMultiplier[5] = 0.02f;
        ExpMultiplier[6] = 0.01f;
        ExpMultiplier[7] = 0.01f;
    }
    
    public static void AddExp(int exp)
    {
        LvlProgress += exp * ExpMultiplier[Lvl];

        if (LvlProgress >= 1)
        {
            Lvl++;
            LvlProgress = 0;
        }
    }
    
    public static bool IsEnoughItems(List<Item> required)
    {
        int itemsToComplete = required.Count;
        for (int i = 0; i < required.Count; i++)
        {
            foreach(Item item in Items)
            {
                if(item.Name == required[i].Name)
                {
                    if(item.Count >= required[i].Count)
                    {
                        itemsToComplete--;
                    }
                }
            }
        }
        if (itemsToComplete == 0) return true;
        else return false;
    }
    
    public static void RemoveItemWithName(string name, int count)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == name)
            {
                if (Items[i].Count <= count)
                {
                    Items[i] = GetEmptyItem();
                } else
                {
                    Items[i].Count -= count;
                }
            }
        }
        Storage.Save();
    }

    public static Item GetHandItem()
    {
        return new Item(Items[0].Name, Items[0].ImgUrl, Items[0].Count, Items[0].Type, Items[0].Price, Items[0].LvlWhenUnlock, Items[0].GetHashCode());;
    }

    public static Item GetEmptyItem()
    {
        return new Item("empty", "Food/empty", 0, 0, 0, 0, 0);
    }

    public static void RemoveItem()
    {
        if (Items[0].Count == 1)
        {
            Items[0] = GetEmptyItem();
        }
        else
        {
            Items[0].Count -= 1;
        }
        Storage.Save();
    }

    public static void CheckIfItemExists(Item item)
    {
        bool exist = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (item.Name == Items[i].Name)
            {
                Items[i].Count += item.Count;
                exist = true;
                break;
            }
        }
        if (!exist)
        {
            AddItemToInventory(item);
        }
        Storage.Save();
    }

    public static void AddItemToInventory(Item item)
    {
        bool added = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == "empty")
            {
                Items[i] = item;
                added = true;
                break;
            }
        }

        if (!added)
        {
            Items.Add(item);
        }
    }
}
