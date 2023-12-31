using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public Transform slotsParent;
    public InventorySlot[] _inventorySlots;

    private bool _isOpened;

    private void Awake()
    {
        instance = this;

        _inventorySlots = new InventorySlot[20];
    }

    private void Start()
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            _inventorySlots[i] = slotsParent.GetChild(i).GetComponent<InventorySlot>();
        }
    }

    public void PutInEmptySlot(Item item, GameObject obj)
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (_inventorySlots[i]._item == null)
            {
                _inventorySlots[i].PutInSlot(item, obj);
                return;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_isOpened)
                Close();
            else
                Open();
        }
    }

    public void ClearSlots()
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (_inventorySlots[i] != null && _inventorySlots[i]._item != null)
                Delete(i);
        }
    }

    public void Delete(int id)
    {
        _inventorySlots[id].ClearSlot();
    }

    void Open()
    {
        gameObject.transform.localScale = Vector3.one;
        _isOpened = true;
    }

    void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
        _isOpened = false;
        ItemInfo.instance.Close();
    }
}