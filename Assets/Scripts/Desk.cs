using UnityEngine;

public class Desk : MonoBehaviour
{
    private GameObject _player;
    private GameObject _inventory;
    private SpriteRenderer _deskSpriteRenderer;
    private bool _allowClick = false;

    public void Start()
    {
        _deskSpriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindWithTag("Player");
        _inventory = GameObject.FindWithTag("Inventory");
    }

    public void OnMouseDown()
    {
        if (_allowClick)
        {
            _inventory.GetComponent<Menu>().OpenDesk();
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 2f)
        {
            _allowClick = true;
            _deskSpriteRenderer.sprite = Resources.Load<Sprite>("Room/deskSelected");
        } else
        {
            _allowClick = false;
            _deskSpriteRenderer.sprite = Resources.Load<Sprite>("Room/desk");
        }
    }
}