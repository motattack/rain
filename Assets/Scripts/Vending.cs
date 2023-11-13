using UnityEngine;

public class Vending : MonoBehaviour
{
    private GameObject _player;
    private GameObject _inventory;
    private SpriteRenderer _vendingSpriteRenderer;
    private bool _allowClick = false;

    private void Start()
    {
        _vendingSpriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindWithTag("Player");
        _inventory = GameObject.FindWithTag("Inventory");
    }

    public void OnMouseDown()
    {
        if (_allowClick)
        {
            _inventory.GetComponent<Menu>().OpenShop();
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 2f)
        {
            _allowClick = true;
            _vendingSpriteRenderer.sprite = Resources.Load<Sprite>("Market/vending");
        }
        else
        {
            _allowClick = false;
            _vendingSpriteRenderer.sprite = Resources.Load<Sprite>("Market/vendingDis");
        }
    }
}
