using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item _item;
    public GameObject _itemObj;
    private Image _icon;
    private Button _button;

    private void Start()
    {
        _icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ShowInfo);
    }

    public void PutInSlot(Item item, GameObject obj)
    {
        _icon.sprite = item.icon;
        _item = item;
        _itemObj = obj;
        _icon.enabled = true;
    }

    void ShowInfo()
    {
        if (_item != null)
            ItemInfo.instance.Open(_item, _itemObj, this);
    }

    public void ClearSlot()
    {
        _item = null;
        _itemObj = null;
        _icon.sprite = null;
        _icon.enabled = false;
    }
}