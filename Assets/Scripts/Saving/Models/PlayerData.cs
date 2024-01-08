using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public List<int> itemIdList;
    public int balance;
    
    public PlayerData()
    {
        itemIdList = new List<int>();
        balance = 2500;
    }
}