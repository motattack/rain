using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Item item;
    public GameObject itemObj;

    private void Start()
    {
        itemObj = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.PutInEmptySlot(item, itemObj);
            gameObject.SetActive(false);
        }
    }

    public Sprite GetIcon()
    {
        return item.icon;
    }
}
