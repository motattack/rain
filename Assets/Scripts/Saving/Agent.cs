using System;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Storage _storage;
    private PlayerData playerData;
    
    private void Start()
    {
        _storage = new Storage();
        playerData = new PlayerData();
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Save();
            _animator.Play("Saving");
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Load();
            _animator.Play("Load");
        }
    }

    public void Save()
    {
        playerData.itemIdList = InventoryItems.instance.Save();
        playerData.balance = Hero.instance.balance;
        _storage.Save(playerData);
    }

    public void Load()
    {
        playerData = (PlayerData)_storage.Load(new PlayerData());
        InventoryItems.instance.Load(playerData.itemIdList);
        Hero.instance.SetBalance(playerData.balance);
    }
}
