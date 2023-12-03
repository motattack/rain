using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DebugController : MonoBehaviour
{
    private bool showConsole = false;
    [SerializeField] private GameObject console;
    [SerializeField] private GameObject Text;
    private string command;
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) && !showConsole)
        {
            showConsole = !showConsole;
        }
        
        
        console.SetActive(showConsole);
    }

    public void CloseConsole()
    {
        showConsole = false;
        command = Text.GetComponent<TMP_Text>().text;
        TryRunCommand();
        Text.GetComponent<TMP_Text>().SetText(string.Empty);
    }

    private void TryRunCommand()
    {

        
        if (command == "give kitstart\u200B")
        {
            Item item = new Item("вискас", "Food/wiskas_icon", 1, Item.Typefood, 1, 1, 5f);
            
            DB.CheckIfItemExists(item);
            Storage.SaveInventory();
        }

        if (command == "give money\u200B")
        {
            DB.Money = 1000000;
            Storage.SavePlayerData();
        }

        if (command == "reset\u200B")
        {
            Debug.Log(command);
            DB.Items.Clear();
            DB.Money = 0;
            DB.LvlProgress = 0;
            DB.Lvl = 0;
            for (int i = 0; i <= 7; i++)
                DB.Items.Add(DB.GetEmptyItem());
            Storage.Save();
        }
    }
}
