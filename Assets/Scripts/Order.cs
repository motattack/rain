using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public int id;

    List<Image> _productImages;
    List<Text> _productCount;

    List<Item> _allItems = new List<Item>();
    List<Item> _required = new List<Item>();

    private Text _reward;
    private int _moneyToRecive;
    private int _expToRecive;

    private void Start()
    {
        _reward = GetComponentsInChildren<Text>()[0];

        _productImages = GetComponentsInChildren<Image>().ToList();
        _productCount = GetComponentsInChildren<Text>().ToList();

        GetComponentInChildren<Button>().onClick.AddListener(delegate { CompleteOrder(); });

        if (DB.Lvl > 0) _allItems.Add(new Item("вискас", "Food/wiskas_icon", 1, Item.Typefood, 10, 1, 5f));
        if (DB.Lvl > 1) _allItems.Add(new Item("молоко", "Food/milk", 1, Item.Typefood, 10, 2, 5f));
        if (DB.Lvl > 2) _allItems.Add(new Item("рыба", "Food/fish", 1, Item.Typefood, 10, 3, 5f));
        if (DB.Lvl > 3) _allItems.Add(new Item("суши", "Food/sushi", 1, Item.Typefood, 10, 4, 5f));

        CreateOrder();
    }

    private void CreateItemForOrder()
    {
        int productIndex = Random.Range(0, _allItems.Count);
        Item product = _allItems[productIndex];

        product.Count = GenerateAmount();

        _allItems.Remove(product);
        _required.Add(product);
    }

    private void CreateOrder()
    {
        if (DB.CurrentOrders[id].Count == 0)
        {
            for (int i = 0; i < GenerateCount(); i++)
            {
                CreateItemForOrder();
            }
        }
        else _required = DB.CurrentOrders[id];



        for (int i = 0; i < _required.Count; i++)
        {
            _productImages[i + 1].sprite = Resources.Load<Sprite>(_required[i].ImgUrl);
            _productCount[i + 2].text = "x" + _required[i].Count.ToString();
        }

        GenerateReward();
        DB.CurrentOrders[id] = _required;
    }

    private void CompleteOrder()
    {
        if (DB.IsEnoughItems(_required))
        {
            foreach (var item in _required)
            {
                DB.RemoveItemWithName(item.Name, item.Count);
            }
            DB.AddExp(_expToRecive);
            DB.Money += _moneyToRecive;
            DB.CurrentOrders[id].Clear();
            Storage.Save();
            Destroy(gameObject);
        }
    }

    private void GenerateReward()
    {
        switch (DB.Lvl)
        {
            case 1:
                _moneyToRecive = Random.Range(6, 15); //6..14
                _expToRecive = Random.Range(1, 3); //1..2
                break;
            case 2:
                _moneyToRecive = Random.Range(9, 21); //9..20
                _expToRecive = Random.Range(1, 5); //1..4
                break;
            default:
                _moneyToRecive = Random.Range(20, 35); //20..34
                _expToRecive = Random.Range(4, 8); //4..7
                break;    
        }
        _reward.text = $"Ты получишь {_expToRecive} опыта и {_moneyToRecive} руб.";
    }

    private int GenerateCount()
    {
        if (DB.Lvl == 1) return 1;
        if (DB.Lvl == 2) return Random.Range(1, 3); //1..2
        if (DB.Lvl == 3) return Random.Range(1, 3); //1..2
        if (DB.Lvl == 4) return Random.Range(2, 4); //2..3

        return 3;
    }

    private int GenerateAmount()
    {
        if (DB.Lvl == 1) return Random.Range(1, 3); //1..2
        if (DB.Lvl == 2) return Random.Range(1, 3); //1..2
        if (DB.Lvl == 3) return Random.Range(1, 4); //1..3
        if (DB.Lvl == 4) return Random.Range(2, 4); //2..3

        return 4;
    }
}