using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    private Image _slotImage;
    private Image _itemImage;
    private TMP_Text _countText;

    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { Click(); });
    }

    public void FillSlot(int id)
    {
        _id = id;
        Item item = DB.Items[id];
        
        _slotImage = GetComponent<Image>();
        _itemImage = GetComponentsInChildren<Image>()[1];
        _countText = GetComponentInChildren<TMP_Text>();

        if (item.Count > 0) _countText.text = "x" + item.Count.ToString();
        else _countText.text = string.Empty;

        _itemImage.sprite = Resources.Load<Sprite>(item.ImgUrl);
    }

    private void Click()
    {
        if (Inventory.SelectedSlot == null)
        {
            _slotImage.sprite = Resources.Load<Sprite>("Canvas/placeHolderSelected");
            Inventory.SelectedSlot = this;
        }
        else if (Inventory.SelectedSlot == this)
        {
            _slotImage.sprite = Resources.Load<Sprite>("Canvas/placeHolder");
            Inventory.SelectedSlot = null;
        }
        else
        {
            Inventory.SelectedSlot._slotImage.sprite = Resources.Load<Sprite>("Canvas/placeHolder");

            (DB.Items[Inventory.SelectedSlot._id], DB.Items[_id]) = (DB.Items[_id], DB.Items[Inventory.SelectedSlot._id]);

            Inventory.SelectedSlot.FillSlot(Inventory.SelectedSlot._id);
            FillSlot(_id);
            
            Inventory.SelectedSlot = null;
        }
    }
}
