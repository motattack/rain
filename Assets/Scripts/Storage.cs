using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private static string inventoryPath = Application.persistentDataPath + "/inventory.path";
    private static string playerDataPath = Application.persistentDataPath + "/playerData.path";
    private static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void Save()
    {
        SaveInventory();
        SavePlayerData();
    }

    public static void SaveInventory()
    {
        FileStream stream = new FileStream(inventoryPath, FileMode.Create);
        binaryFormatter.Serialize(stream, DB.Items);
        stream.Close();
    }

    public static List<Item> LoadInventory()
    {
        if (File.Exists(inventoryPath)) {
            FileStream stream = new FileStream(inventoryPath, FileMode.Open);
            
            List<Item> items = (List<Item>)binaryFormatter.Deserialize(stream);
            stream.Close();

            return items;
        } else
        {
            List<Item> startItems = new List<Item>();

            startItems.Add(DB.GetEmptyItem());
            startItems.Add(new Item("телефон", "Tools/phone", 0, Item.Typeflow, 0, 0, 0f));
            startItems.Add(DB.GetEmptyItem());
            startItems.Add(DB.GetEmptyItem());
            startItems.Add(DB.GetEmptyItem());
            startItems.Add(DB.GetEmptyItem());
            startItems.Add(DB.GetEmptyItem());

            return startItems;
        }
    }

    public static void SavePlayerData()
    {
        FileStream stream = new FileStream(playerDataPath, FileMode.Create);
        PlayerData playerData = new PlayerData(DB.Money, DB.Lvl, DB.LvlProgress);
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(playerDataPath))
        {
            FileStream stream = new FileStream(playerDataPath, FileMode.Open);

            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(stream);
            stream.Close();

            return playerData;
        } else return new PlayerData(1000000, 1, 0);
    }
    public static void ClearDataBase()
    {
        if (File.Exists(inventoryPath)) { File.Delete(inventoryPath); }
        if (File.Exists(playerDataPath)) { File.Delete(playerDataPath); }
    }
}
