using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public GameObject deskPrefab;
    public GameObject shopPrefab;

    public bool inventoryOpened;
    public bool deskOpened;
    public bool shopOpened;
    private GameObject _inventory;
    private GameObject _desk;
    private GameObject _shop;

    public void OpenInventory()
    {
        if (deskOpened) {
            Destroy(_desk);
            deskOpened = false;
        }
        else if (shopOpened)
        {
            Destroy(_shop);
            shopOpened = false;
        }
        else 
        {
            if (inventoryOpened)
            {
                Destroy(_inventory);
                inventoryOpened = false;
            }
            else
            {
                _inventory = Instantiate(inventoryPrefab);
                _inventory.transform.SetParent(gameObject.transform);
                _inventory.GetComponent<RectTransform>().offsetMin = new Vector2(100, 59);
                _inventory.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
                _inventory.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                inventoryOpened = true;
            }
        }
    }

    public void OpenShop()
    {
        if(!inventoryOpened && !deskOpened && !shopOpened)
        {
            _shop = Instantiate(shopPrefab);
            _shop.transform.SetParent(gameObject.transform);
            _shop.GetComponent<RectTransform>().offsetMin = new Vector2(100, 59);
            _shop.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
            _shop.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            shopOpened = true;
        }
    }

    public void OpenDesk()
    {
        if (!inventoryOpened && !deskOpened && !shopOpened)
        {
            _desk = Instantiate(deskPrefab);
            _desk.transform.SetParent(gameObject.transform);
            _desk.GetComponent<RectTransform>().offsetMin = new Vector2(100, 59);
            _desk.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
            _desk.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            deskOpened = true;
        }
    }
}