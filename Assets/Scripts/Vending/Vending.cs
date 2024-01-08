using TMPro;
using UnityEngine;

public class Vending : MonoBehaviour
{
    public static Vending instance;
    [SerializeField] private TMP_Text _balance;
    [SerializeField] private GameObject _vendingUI;
    [SerializeField] private Collider2D _actionArea;

    private void Start()
    {
        instance = this;
        UpdateBalance();
        _vendingUI.SetActive(false);
    }
    
    private void ToggleVendingUI()
    {
        _vendingUI.SetActive(!_vendingUI.activeSelf);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Hero.instance.IsAction())
        {
            ToggleVendingUI();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Hero.instance.ToggleActionIndicator(true);
            UpdateBalance();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Hero.instance.ToggleActionIndicator(false);
        }
    }

    public void UpdateBalance()
    {
        _balance.text = Hero.instance.balance.ToString() + " rur";
    }
}