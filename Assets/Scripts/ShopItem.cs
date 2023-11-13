using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private Text _price;
    private Text _moneyText;
    private Image _productImage;

    private Text _lvlText;
    private Image _lvlImage;

    private void Start()
    {
        _price = GetComponentsInChildren<Text>()[0];
        _productImage = GetComponentsInChildren<Image>()[1];

        _lvlText = GetComponentsInChildren<Text>()[1];
        _lvlImage = GetComponentsInChildren<Image>()[2];
    }

    private void Buy(Item item)
    {
        if (DB.Money >= item.Price)
        {
            DB.CheckIfItemExists(item);
            DB.Money -= item.Price;
            _moneyText.text = DB.Money + " руб.";
            Storage.Save();
        }
    }

    public void UpdateItem(Item item, Text moneyText)
    {
        if (item.LvlWhenUnlock > DB.Lvl)
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
            _lvlText.enabled = true;
            _lvlText.text = "Разбликируется на " + item.LvlWhenUnlock.ToString();
            _productImage.sprite = Resources.Load<Sprite>(item.ImgUrl);

            _lvlImage.enabled = true;
        }
        else {
            _moneyText = moneyText;
            _lvlImage.enabled = false;
            _lvlText.enabled = false;

            _productImage.sprite = Resources.Load<Sprite>(item.ImgUrl);
            _price.text = item.Price + " руб.";
            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(delegate { Buy(item); });
        }
    }
}
