using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo instance;
    private Image _background;
    private Image _icon;
    private TMP_Text _title;
    private TMP_Text _description;
    private Button _exitButton;
    private Button _useButton;
    private Button _dropButton;

    private Item _infoItem;
    private GameObject _itemObj;
    private InventorySlot _curSlot;

    private void Start()
    {
        instance = this;

        _background = GetComponent<Image>();
        _title = transform.GetChild(0).GetComponent<TMP_Text>();
        _description = transform.GetChild(1).GetComponent<TMP_Text>();
        _icon = transform.GetChild(2).GetComponent<Image>();
        _exitButton = transform.GetChild(3).GetComponent<Button>();
        _useButton = transform.GetChild(4).GetComponent<Button>();
        _dropButton = transform.GetChild(5).GetComponent<Button>();

        _exitButton.onClick.AddListener(Close);
        _useButton.onClick.AddListener(Use);
        _dropButton.onClick.AddListener(Drop);
    }

    public void ChangeInfo(Item item)
    {
        _title.text = item.Name;
        _description.text = item.Description;
        _icon.sprite = item.icon;
    }

    public void Use()
    {
        UseOfItems.instance.Use(_infoItem);
    }

    public void Drop()
    {
        Vector3 dropPos = new Vector3(Hero.instance.transform.position.x + 2f, Hero.instance.transform.position.y,
            Hero.instance.transform.position.z);
        _itemObj.SetActive(true);
        _itemObj.transform.position = dropPos;
        
        _curSlot.ClearSlot();
        Close();
    }

    public void Open(Item item, GameObject obj, InventorySlot curSlot)
    {
        ChangeInfo(item);
        _infoItem = item;
        _itemObj = obj;
        _curSlot = curSlot;
        gameObject.transform.localScale = Vector3.one;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}