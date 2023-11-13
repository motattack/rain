using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private List<ShopItem> _allItems = new List<ShopItem>();
    private List<Item> _allProductList = new List<Item>();
    private Text _moneyText;

    private void Start()
    {
        _moneyText = GetComponentsInChildren<Text>()[0];
        _moneyText.text = DB.Money + " руб.";

        _allItems = gameObject.GetComponentsInChildren<ShopItem>().ToList();

        FillAllProducts();
        StartCoroutine(FillShop());
    }

    private IEnumerator FillShop()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < _allItems.Count; i++)
        {
            _allItems[i].UpdateItem(_allProductList[i], _moneyText);
        }
    }

    private void FillAllProducts()
    {
        _allProductList.Clear();
        _allProductList.Add(new Item("вискас", "Food/wiskas_icon", 1, Item.Typefood, 1, 1, 5f));
        _allProductList.Add(new Item("молоко", "Food/milk", 1, Item.Typefood, 2, 2, 5f));
        _allProductList.Add(new Item("рыба", "Food/fish", 1, Item.Typefood, 4, 3, 5f));
        _allProductList.Add(new Item("суши", "Food/sushi", 1, Item.Typefood, 4, 4, 5f));
    }
}
