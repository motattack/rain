using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VendingButton : MonoBehaviour
{
    [SerializeField] private VendingItem _vendingItem;
    [SerializeField] private TMP_Text _price;
    private GameObject _spawnArea;
    
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Buy);
        
        _spawnArea = GameObject.FindWithTag("SpawnArea");
        
        Image _buttonImage = GetComponentInChildren<Image>();
        if(_vendingItem.item != null)
            _buttonImage.sprite = _vendingItem.item.GetIcon();
        else
        {
            Color imageColor = _buttonImage.color;
            imageColor.a = 0f;
            _buttonImage.color = imageColor;
        }

        _price.text = _vendingItem.price.ToString();
        Debug.Log(_vendingItem.price.ToString());
    }

    public void Buy()
    {
        if (_vendingItem != null)
        {
            if (Hero.instance.Purchase(_vendingItem.price))
            {
                SpawnItemInSpawnArea();
                Vending.instance.UpdateBalance();
            }
        }
    }
    
    private void SpawnItemInSpawnArea()
    {
        if (_spawnArea != null)
        {
            Collider2D spawnCollider = _spawnArea.GetComponent<Collider2D>();
            if (spawnCollider != null)
            {
                Vector3 spawnPosition = GetRandomPositionInsideCollider(spawnCollider);
                Instantiate(_vendingItem.item, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomPositionInsideCollider(Collider2D collider)
    {
        Vector3 center = collider.bounds.center;
        Vector3 size = collider.bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);
        float randomZ = Random.Range(center.z - size.z / 2, center.z + size.z / 2);

        return new Vector3(randomX, randomY, randomZ);
    }
}
